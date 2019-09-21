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

        // POST api/notes
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

        // PUT api/notes/id#
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] BugNote bugNoteData)
        {
            try
            {
                BugNote myBugNote = _bn.EditBugNote(bugNoteData);
                return Ok(myBugNote);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public BugNotesController(BugNotesService bn)
        {
            _bn = bn;
        }
    }
}

