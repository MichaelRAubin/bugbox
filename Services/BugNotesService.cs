using System;
using System.Collections.Generic;
using bugbox.Data;
using bugbox.Models;

namespace bugbox.Services
{
    public class BugNotesService
    {
        private readonly FakeDb _repo;

        public List<BugNote> GetBugNoteByID(string id)
        {
            var bugNotes = _repo.BugNotes.FindAll(bn => bn.BugId == id);
            if (bugNotes == null) { throw new Exception("Invalid Bug Note ID"); }
            return bugNotes;
        }
        public BugNotesService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}