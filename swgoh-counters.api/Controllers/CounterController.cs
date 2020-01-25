using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swgoh_counters.api.Commands;
using swgoh_counters.api.DataAccess;
using swgoh_counters.api.Models;

namespace swgoh_counters.api.Controllers
{
    [Route("api/counter")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        readonly CounterRepository _repo;

        public CounterController(CounterRepository repo)
        {
            _repo = repo;
        }

        // GET: api/counter
        [HttpGet]
        public IEnumerable<Counter> GetAllCounters()
        {
            return _repo.GetAll();
        }

        // GET: api/counter/501ST-v-BH_BOSSK
        [HttpGet("{counterId}")]
        public Counter GetCounter(string counterId)
        {
            return _repo.Get(counterId);
        }

        // POST: api/counter
        [HttpPost]
        public bool PostCounter(AddCounterCommand counter)
        {
            return _repo.Create(counter);
        }

        // PUT: api/counter/501ST-v-BH_BOSSK
        [HttpPut("{counterId}")]
        public bool PutCounter(AddCounterCommand counter, string counterId)
        {
            return _repo.Update(counter, counterId);
        }

        // DELETE: api/counter/501ST-v-BH_BOSSK
        [HttpDelete("{counterId}")]
        public bool DeleteCounter(string counterId)
        {
            return _repo.Delete(counterId);
        }
    }
}