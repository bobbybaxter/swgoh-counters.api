using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swgoh_counters.api.Models
{
    public class CounterSquad
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LeaderName { get; set; }
        public string Toon2Name { get; set; }
        public string Toon3Name { get; set; }
        public string Toon4Name { get; set; }
        public string Toon5Name { get; set; }
        public string Subs { get; set; }
        public string Description { get; set; }
        public string CounterStrategy { get; set; }
        public bool IsLeaderRequired { get; set; }
        public bool IsToon2Required { get; set; }
        public bool IsToon3Required { get; set; }
        public bool IsToon4Required { get; set; }
        public bool IsToon5Required { get; set; }
    }
}
