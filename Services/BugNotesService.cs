using System;
using System.Collections.Generic;
using bugbox.Data;
using bugbox.interfaces;
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

        public BugNote AddBugNote(BugNote bugNoteData)
        {
            var bug = _repo.Bugs.Find(b => b.Id == bugNoteData.BugId);
            if (bug.ClosedDate != null)
            {
                throw new Exception("This bug is already closed.");
            }
            bugNoteData.Id = Guid.NewGuid().ToString();
            bugNoteData.Timestamp = DateTime.Now;
            _repo.BugNotes.Add(bugNoteData);
            return bugNoteData;
        }
        public BugNotesService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}