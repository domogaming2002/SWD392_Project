using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.DataLayer.Manager;
using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.Repository
{
    public class CategoryMedicineRepository : ICategoryMedicineRepository
    {
        CategoryMedicineManager manager;
        SWD_ProjectContext _context;

        public CategoryMedicineRepository(SWD_ProjectContext context)
        {
            _context = context;
            manager = new CategoryMedicineManager(_context);
        }
        public List<CategoryMedicine>? GetListMedicineCategory()
        {
            return manager.GetListMedicineCategory();
        }
        public void AddCategory(CategoryMedicine category)
        {
            manager.AddCategory(category);
        }
    }
}
