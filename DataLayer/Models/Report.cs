using System;
using System.Collections.Generic;

namespace SWD392_Project.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; } = null!;
        public DateTime Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDelete { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}
