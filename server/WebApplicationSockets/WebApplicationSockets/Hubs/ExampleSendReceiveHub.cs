using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

// example 1

namespace WebSocketsExample.Hubs
{
    public class ExampleSendReceiveHub : Hub
    {
        public async Task SendData(string message)
        {
            await Clients.All.SendAsync("ReceiveData", $"server received message: {message}");
        }
    }
}