using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorAppMysql.Server.DtoModels;
using BlazorAppMysql.Server.DBModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorAppMysql.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropositionController : ControllerBase
    {
        private readonly PropositionVoterContext _context;

        public PropositionController(PropositionVoterContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

      
        [HttpPost]
        //[Route("Create")]
        public async Task<IActionResult> Post(Proposition proposition)
        {
            _context.Add(proposition);
            await _context.SaveChangesAsync();
            return NoContent();
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
