using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swgoh_counters.api.Commands
{
    public class AddUserCommand
    {
        public string AllyCode { get; set; }
        public string Email { get; set; }
        public string FirebaseUid { get; set; }
        public string Username { get; set; }
    }
}
