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

        public Bug GetBugByID(string id)
        {
            var bug = _repo.Bugs.Find(b => b.Id == id);
            if (bug == null) { throw new Exception("Invalid Bug ID"); }
            return bug;
        }

        public Bug AddBug(Bug bugData)
        {
            var exists = _repo.Bugs.Find(b => b.Title == bugData.Title);
            if (exists != null)
            {
                throw new Exception("This bug already exists.");
            }
            bugData.Id = Guid.NewGuid().ToString();
            bugData.ReportedDate = DateTime.Now;
            _repo.Bugs.Add(bugData);
            return bugData;
        }



        public BugsService(FakeDb repo)
        {
            _repo = repo;
        }
    }
}