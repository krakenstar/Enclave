using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Enclave.Hubs
{
    public class EnclaveHub : Hub
    {
        private Enclave.Models.Enclave _enclave;

        public async void JoinEnclave(string enclaveID, string userID)
        {
            await Groups.Add(Context.ConnectionId, enclaveID);
            Clients.Group(enclaveID).serverLogMessage(userID + " have joined enclaveID: " + enclaveID);
            _enclave = Enclave.Models.Enclave.Get(enclaveID);
            _enclave.NextPhase(null);
        }

        public void SendServerMessage(string message)
        {
            Clients.All.serverLogMessage(message);
        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
        
    }
}