using Enclave.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enclave.Models
{

    internal enum Phase
    {
        Dawn,
        Morning,
        Noon,
        Afternoon,
        Dusk,
        Night,
        Full_Moon,
        Witching_Hour
    }

    internal class Enclave
    {
        private static EnclaveHub _EnclaveHub;
        private List<Character> _characters;
        public Enclave()
        {
            if (_EnclaveHub == null) _EnclaveHub = new EnclaveHub();
            
        }

    }
}