using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace UIClient
{
    public class SpeedTestSpeedTestProxy
    {
        string hubName = string.Empty;
        public HubConnection connection;
        public Action<string> SpeedTestMessageReceived = delegate { };

        public struct DataReceived
        {
            public string data1;
            public string data2;
            public string data3;
            public string data4;
            public string data5;
            public string data6;
        }

        public SpeedTestSpeedTestProxy(string hubName)
        {
            this.hubName = hubName;

            connection = new HubConnectionBuilder()
                       .WithUrl("https://localhost:5001/" + hubName + "?clientName=WPF")
                        .AddMessagePackProtocol()
                        .WithAutomaticReconnect()
                        .ConfigureLogging(factory =>
                        {
                            factory.AddFilter("Console", level => level >= LogLevel.Trace);
                        })
                        .Build();

            connection.Closed += Connection_Closed;
            connection.Reconnected += Connection_Reconnected;

            // subscribe to server calls

            connection.On("ReceiveData", (string response, DataReceived data) => {
                SpeedTestMessageReceived(response);
            });

        }

        private Task Connection_Reconnected(string arg)
        {
            Console.WriteLine($"CONNECTION RECONNECTED - { hubName }");
            return Task.CompletedTask;
        }

        private Task Connection_Closed(Exception arg)
        {
            Console.WriteLine($"CONNECTION CLOSED - { hubName }");
            return Task.CompletedTask;
        }


        public async Task StartConnection()
        {
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartTest(int messageCount)
        {
            try
            {
                connection.InvokeAsync("StartTest", messageCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
}
}
