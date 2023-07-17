using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.DataLayer.Manager;
using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.Repository
{
    public class CategoryDrugRepository : ICategoryDrugRepository
    {
        private CategoryDrugManager manager;
        private SWD_ProjectContext _context;
        public CategoryDrugRepository(SWD_ProjectContext context)
        {
            _context = context;
            manager = new CategoryDrugManager(_context);
        }

        public void AddDrugCategory(CategoryDrug category)
        {
            manager.AddDrugCategory(category);
        }

        public ICollection<CategoryDrug> GetCategories()
        {
            return manager.GetCategories();
        }
    }
}
