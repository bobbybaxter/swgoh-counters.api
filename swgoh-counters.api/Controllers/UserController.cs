using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swgoh_counters.api.Commands;
using swgoh_counters.api.Controllers;
using swgoh_counters.api.Models;

namespace swgoh_counters.api.DataAccess
{
    [Route("api/user")]
    //[ApiController,Authorize]
    [ApiController]
    public class UserController : FirebaseEnabledController
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

        // GET: api/user/allyCode/123456789
        [HttpGet("allyCode/{allyCode}")]
        public User GetUserByAllyCode(string allyCode)
        {
            return _repo.GetUserByAllyCode(allyCode);
        }

        // GET: api/user/firebase/123456789ABCDEFG
        [HttpGet("firebase/{firebaseUid}")]
        public User GetUserByFirebaseUid(string firebaseUid)
        {
            return _repo.GetUserByFirebaseUid(firebaseUid);
        }

        // GET: api/user/1
        [HttpGet("{userId}")]
        public User GetUserById(int userId)
        {
            return _repo.GetUserById(userId);
        }

        // POST: api/user
        [HttpPost]
        public User PostUser()
        {
            AddUserCommand newUser = new AddUserCommand()
            {
                FirebaseUid = FirebaseId,
                Email = FirebaseEmail
            };

            return _repo.Create(newUser);
        }

        // PUT: api/user/5
        [HttpPut("{userId}")]
        public bool PutUser(UpdateUserCommand user, int userId)
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
