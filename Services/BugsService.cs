using System;
using System.Collections.Generic;
using bugbox.Data;
using bugbox.Models;

namespace bugbox.Services
{
    public class BugsService
    {
        private readonly FakeDb _repo;

        public List<Bug> GetBugs()
        {
            return _repo.Bugs;
        }

        internal Bug GetBugByID(string id)
        {
            var bug = _repo.Bugs.Find(b => b.Id == id);
            if (bug == null) { throw new Exception("Invalid Bug ID"); }
            return bug;
        }

        public List<BugNote> GetBugNotes(string id)
        {
            var bugNotes = _repo.BugNotes.FindAll(bn => bn.BugId == id);
            if (bugNotes == null) { throw new Exception("Invalid Bug Note ID"); }
            return bugNotes;
        }
        public Bug AddBug(Bug bugData)
        {
            bugData.Id = Guid.NewGuid().ToString();
            bugData.ReportedDate = DateTime.Now;
            _repo.Bugs.Add(bugData);
            return bugData;
        }

        public Bug EditBug(Bug bugData)
        {
            var bug = _repo.Bugs.Find(b => b.Id == bugData.Id);
            if (bug == null || bug.ClosedDate != null) { throw new Exception("Bug cannot be edited"); }
            bug.Title = bugData.Title;
            bug.Description = bugData.Description;
            bug.LastModified = DateTime.Now;
            bug.ClosedDate = null;
            return bug;
        }

        public Bug CloseBug(string id)
        {
            var bug = _repo.Bugs.Find(b => b.Id == id);
            if (bug == null) { throw new Exception("Invalid Bug ID"); }
            if (bug.ClosedDate != null) { throw new Exception("Bug already closed"); }
            bug.ClosedDate = DateTime.Now;
            return bug;
        }

        public BugsService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}