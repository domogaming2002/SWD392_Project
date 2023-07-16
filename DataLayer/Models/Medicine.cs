using System;
using System.Collections.Generic;

namespace SWD392_Project.Models
{
    public partial class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = null!;
        public int CategoryMedicineId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public virtual CategoryMedicine CategoryMedicine { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}
