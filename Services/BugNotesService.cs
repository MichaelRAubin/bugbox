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

        public BugNote AddBugNote(BugNote bugNoteData)
        {
            var bug = _repo.Bugs.Find(b => b.Id == bugNoteData.BugId);
            if (bug.ClosedDate != null)
            {
                throw new Exception("This bug is already closed.");
            }
            bugNoteData.Id = Guid.NewGuid().ToString();
            bugNoteData.Timestamp = DateTime.Now;
            bug.LastModified = DateTime.Now;
            _repo.BugNotes.Add(bugNoteData);
            return bugNoteData;
        }

        public BugNote EditBugNote(BugNote bugNoteData) //TODO need to add logic to check for open bug
        {
            var bugNote = _repo.BugNotes.Find(b => b.Id == bugNoteData.Id);
            if (bugNoteData == null) { throw new Exception("Note cannot be edited"); }
            bugNoteData.Body = bugNoteData.Body;
            return bugNoteData;
        }
        public BugNotesService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}