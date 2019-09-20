using System;

namespace bugbox.interfaces
{
    interface IBug
    {
        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTime ReportedDate { get; set; }
        DateTime LastModified { get; set; }
        DateTime ClosedDate { get; set; }
    }
}