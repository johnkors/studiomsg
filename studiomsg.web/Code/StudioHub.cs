using Microsoft.AspNet.SignalR;

namespace studiomsg.web.Code
{
    public class StudioHub : Hub
    {
        public void Send(string message, string type)
        {
            Clients.All.broadcastMessage(message, type);
        }

        public void Connected(string clientName)
        {
            Clients.All.connected(clientName);
        }

        public void Disconnected(string clientName)
        {
            Clients.All.disconnected(clientName);
        }
    }
}