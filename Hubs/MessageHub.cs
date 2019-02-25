using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AspNetCore.SignalR
{
    public class MessageHub: Hub
    {
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("RecieveMessage", message);
        }

        
    }
}