using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorAppMysql.Server.DtoModels;

using BlazorAppMysql.Server;
using BlazorAppMysql.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorAppMysql.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VoteController : ControllerBase
    {
        private readonly PropositionVoterContext _context;

        public VoteController(PropositionVoterContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public List<Vote> GetPropositions()
        {
            IQueryable<Vote> v = _context.Vote.Select(x => x);
            return v.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        //[Route("Create")]
        public async Task<IActionResult> Add(Vote proposition)
        {
            var response = new ResponseSingle<int>();
            _context.Add(proposition);
            await _context.SaveChangesAsync();
            //      return NoContent();
            return Ok(response);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
