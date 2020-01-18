using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swgoh_counters.api.Models
{
    public class Counter
    {
        public string Id { get; set; }
        public string OpponentTeamId { get; set; }
        public string CounterTeamId { get; set; }
        public bool IsHardCounter { get; set; }
        public string BattleType { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
    }
}
