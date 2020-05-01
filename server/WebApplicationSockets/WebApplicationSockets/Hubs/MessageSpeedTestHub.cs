using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

// example 1

namespace WebSocketsExample.Hubs
{
    public class MessageSpeedTestHub : Hub
    {
        public void StartTest(int messages)
        {
            int i = 0;
            while (i < messages)
            {
                Clients.All.SendAsync("ReceiveData", $"server sending message", new
                {
                    data1 = "data1-aspiodfhusdhfpishdapfhsadpfhsdpfipsdhfpuishdaifhasdi",
                    data2 = "data1",
                    data3 = "data1-uiahsf ihasdifhisoadfpisad hfiusadfuisd ifuhad spif aspdf hpiasiud fiud sifuh sdaiuf spiaf iusad hifhsd apf hasif hia",
                    data4 = "data1",
                    data5 = "data1",
                    data6 = "data1",
                });
                i++;
            }
        }
    }
}