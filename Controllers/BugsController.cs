using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bugbox.Models;
using bugbox.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly BugsService _bs;

        // GET api/bugs
        [HttpGet]
        public ActionResult<IEnumerable<Bug>> Get()
        {
            return _bs.GetBugs();
        }

        // GET api/bugs/ID number
        [HttpGet("{id}")]
        public ActionResult<Bug> Get(string id)
        {
            try
            {
                Bug bug = _bs.GetBugByID(id);
                return Ok(bug);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult<Bug> Post([FromBody] Bug bugData)
        {
            try
            {
                Bug myBug = _bs.AddBug(bugData);
                return Ok(myBug);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public BugsController(BugsService bs)
        {
            _bs = bs;
        }
    }
}
