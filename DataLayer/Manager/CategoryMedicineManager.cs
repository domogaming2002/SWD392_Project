using Microsoft.EntityFrameworkCore;
using SWD392_Project.Models;

namespace SWD392_Project.DataLayer.Manager
{
    public class CategoryMedicineManager
    {
        SWD_ProjectContext _context;
        public CategoryMedicineManager(SWD_ProjectContext context)
        { _context = context; }

        public List<CategoryMedicine>? GetListMedicineCategory()
        {
            return _context.CategoryMedicines.ToList();
        }
    }
}
