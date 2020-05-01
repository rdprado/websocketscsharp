using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

// example 1

namespace WebSocketsExample.Hubs
{
    public class ExampleSendReceiveHub : Hub
    {
        public async Task SendData(string message)
        {
            await Clients.All.SendAsync("ReceiveData", $"server received message: {message}");
            var transportType = Context.Features.Get<IHttpTransportFeature>()?.TransportType;
            Console.WriteLine($"Transport type: {transportType}");
        }
    }
}