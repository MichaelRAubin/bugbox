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

        // GET api/bugs/id#
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

        // POST api/bugs
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

        // PUT api/bugs/id#
        [HttpPut("{id}")]
        public ActionResult<Bug> Put(string id, [FromBody] Bug bugData)
        {
            try
            {
                Bug myBug = _bs.EditBug(bugData);
                return Ok(myBug);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/bugs/id#
        [HttpDelete("{id}")]
        public ActionResult<Bug> Delete(string id)
        {
            try
            {
                var bug = _bs.CloseBug(id);
                return Ok(bug);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        public BugsController(BugsService bs)
        {
            _bs = bs;
        }

    }

}

