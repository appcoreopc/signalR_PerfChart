using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using PerfBoardCast.Counters;

namespace PerfBoardCast
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartPerformanceCounterCollection();
        }

        private void StartPerformanceCounterCollection()
        {
            var task = Task.Factory.StartNew(() =>
            {
                var perfService = new PerCounterService();
                while (true)
                {
                    var result = perfService.GetResults();
                    Clients.All.newCounters(result);
                    Task.Delay(5000);
                }

            }, TaskCreationOptions.LongRunning);            
        }

        public void Hello()
        {
          Clients.All.hello();
        }

        public void Send(string message)
        {
            Clients.All.subscribeMessage(message);
        }
    }
}