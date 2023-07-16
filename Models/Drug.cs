using System;
using System.Collections.Generic;

namespace SWD392_Project.Models
{
    public partial class Drug
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; } = null!;
        public int CategoryDrugId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public virtual CategoryDrug CategoryDrug { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}
