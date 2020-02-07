using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swgoh_counters.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string AllyCode { get; set; }
        public string Email { get; set; }
        public string FirebaseUid { get; set; }
        public string Username { get; set; }
    }
}
