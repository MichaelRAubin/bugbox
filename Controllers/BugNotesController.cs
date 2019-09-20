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
    public class BugNotesController : ControllerBase
    {
        private readonly BugNotesService _bn;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/id/notes
        [HttpGet("{id}/Notes")]
        public ActionResult<BugNote> Get(string id)
        {
            try
            {
                List<BugNote> bugNotes = _bn.GetBugNoteByID(id);
                return Ok(bugNotes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<BugNote> Post([FromBody] BugNote bugNoteData)
        {
            try
            {
                BugNote myBugNote = _bn.AddBugNote(bugNoteData);
                return Ok(myBugNote);
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

        public BugNotesController(BugNotesService bn)
        {
            _bn = bn;
        }
    }
}

