using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swgoh_counters.api.Models;
using swgoh_counters.api.Repositories;

namespace swgoh_counters.api.Controllers
{
    [Route("api/counterSquad")]
    [ApiController]
    public class CounterSquadController : ControllerBase
    {
        private readonly CounterSquadRepository _repo = new CounterSquadRepository();

        // GET: api/counterSquad
        [HttpGet]
        public IEnumerable<CounterSquad> GetAllCounterSquads()
        {
            return _repo.GetAll();
        }

        // GET: api/counterSquad/BOSSK
        [HttpGet("{counterSquadId}")]
        public CounterSquad GetCounterSquad(string counterSquadId)
        {
            return _repo.Get(counterSquadId);
        }

        // POST: api/counterSquad
        [HttpPost]
        public bool PostCounterSquad(CounterSquad counterSquad)
        {
            return _repo.Create(counterSquad);
        }

        // PUT: api/counterSquad/BOSSK
        [HttpPut("{counterSquadId}")]
        public bool PutCounterSquad(CounterSquad counterSquad, string counterSquadId)
        {
            return _repo.Update(counterSquad, counterSquadId);
        }

        // DELETE: api/counterSquad/BOSSK
        [HttpDelete("{counterSquadId}")]
        public bool DeleteCounterSquad(string counterSquadId)
        {
            return _repo.Delete(counterSquadId);
        }
    }
}
