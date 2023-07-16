using System;
using System.Collections.Generic;

namespace SWD392_Project.Models
{
    public partial class CategoryDrug
    {
        public CategoryDrug()
        {
            Drugs = new HashSet<Drug>();
        }

        public int CategoryDrugId { get; set; }
        public string CategoryDrugName { get; set; } = null!;

        public virtual ICollection<Drug> Drugs { get; set; }
    }
}
