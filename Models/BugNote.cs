using System;
using bugbox.interfaces;

namespace bugbox.Models
{
    public class BugNote : IBugNote
    {
        public string Id { get; set; }
        public string BugId { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}