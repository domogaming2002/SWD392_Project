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
        public void AddCategory(CategoryMedicine category)
        {
            if (!IsExisted(category))
            {
                _context.CategoryMedicines.Add(category);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("This category is already existed!");
            }
        }
        public bool IsExisted(CategoryMedicine category)
        {
            CategoryMedicine existedCategory = _context.CategoryMedicines.FirstOrDefault(o => o.CategoryMedicineName.Equals(category.CategoryMedicineName));
            if (existedCategory != null)
                return true;
            else
                return false;
        }
    }
}
