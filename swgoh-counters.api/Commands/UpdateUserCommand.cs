using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swgoh_counters.api.Commands
{
    public class UpdateUserCommand
    {
        public int Id { get; set; }
        public string AllyCode { get; set; }
        public string Username { get; set; }
    }
}
