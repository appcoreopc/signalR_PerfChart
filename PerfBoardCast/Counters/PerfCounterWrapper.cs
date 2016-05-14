using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerfBoardCast.Counters
{
    public class PerfCounterWrapper
    {
        private PerformanceCounter _counter;

        public string Name { get; set; }
        public float Value
        {
            get
            {
                return _counter.NextValue();
            }
        }

        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {

          
            _counter = new PerformanceCounter(name, category, counter, readOnly: true);

            Name = name;
        }
    }



    public class PerCounterService
    {
        List<PerfCounterWrapper> _counters; 
        public PerCounterService()
        {
            _counters = new List<PerfCounterWrapper>();
          
            //_counters.Add(new PerfCounterWrapper("Processor",
            //   "% Processor Time", "_Total"));

            _counters.Add(new PerfCounterWrapper("Memory",
               "Available MBytes", ""));

            //_counters.Add(new PerfCounterWrapper("Disk",
            // "PhysicalDisk", "% Disk Time", "_Total"));
        }

        public dynamic GetResults()
        {
            return _counters.Select(c => new
            { name = c.Name, value = c.Value });
        }
    }
}