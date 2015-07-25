using Enclave.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace Enclave.Models
{

    public enum Phase: int
    {
        Dawn,
        Morning,
        Noon,
        Afternoon,
        Dusk,
        Night,
        Full_Moon,
        Witching_Hour,
        First_Phase = Dawn,
        Last_Phase = Witching_Hour
    }

    public class Enclave
    {
        private List<Character> _characters;
        private int _day = 0;
        private Phase _phase = Phase.Dawn;
        private object _turnLock = new object();
        private Timer _phaseTimer;
        private static List<Enclave> _Enclaves;
        public string ID { get; private set; }

        private Enclave(string id)
        {
            ID = id;
        }
        /// <summary>
        /// create or get the unique instance with that name.
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        public static Enclave Get(string instanceName)
        {
            if (_Enclaves == null) _Enclaves = new List<Enclave>();
            
            if (!_Enclaves.Exists(x => x.ID == instanceName))                
                _Enclaves.Add(new Enclave(instanceName));

            return _Enclaves.Find(x => x.ID == instanceName);
        }

        public void NextPhase(object enclave)
        {
            if (!HasGameEnded())
            {
                lock (_turnLock)
                {

                    if (_phase++ > Phase.Last_Phase)
                    {
                        _day++;
                        _phase = Phase.First_Phase;
                    }
                    ProcessPhase();
                }
            }
            else
            {
                EndGame();
            }           
        }

        private void ProcessPhase()
        {
            //message hub;
            int PHASE_ROUNDTIME = 1000 * 3;
            _phaseTimer = new System.Threading.Timer(NextPhase, null, PHASE_ROUNDTIME, Timeout.Infinite);
        }
        private void EndGame()
        {
            //message hub;
        }

        private bool HasGameEnded()
        {
            if (_day > 10) return true;

            return false;
        }
    }
}