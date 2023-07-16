using System;
using System.Collections.Generic;

namespace SWD392_Project.Models
{
    public partial class CategoryMedicine
    {
        public CategoryMedicine()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int CategoryMedicineId { get; set; }
        public string CategoryMedicineName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
