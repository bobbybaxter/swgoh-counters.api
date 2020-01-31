using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swgoh_counters.api.Commands;
using swgoh_counters.api.Models;

namespace swgoh_counters.api.DataAccess
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        // GET: api/user
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _repo.GetAll();
        }

        // GET: api/user/123456789
        [HttpGet("{allyCode)")]
        public User GetUser(string allyCode)
        {
            return _repo.Get(allyCode);
        }

        // POST: api/user
        [HttpPost]
        public bool PostUser(AddUserCommand user)
        {
            return _repo.Create(user);
        }

        // PUT: api/user/5
        [HttpPut("{userId}")]
        public bool PutUser(User user, int userId)
        {
            return _repo.Update(user, userId);
        }

        // DELETE: api/user/5
        [HttpDelete("{userId}")]
        public bool DeleteUser(int userId)
        {
            return _repo.Delete(userId);
        }
    }
}
