using SWD392_Project.Models;

namespace SWD392_Project.DataLayer.Manager
{
    public class CategoryDrugManager
    {
        private SWD_ProjectContext _context;
        public CategoryDrugManager(SWD_ProjectContext context)
        {
            _context = context;
        }

        public ICollection<CategoryDrug> GetCategories()
        {
            try
            {
                return _context.CategoryDrugs.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddDrugCategory(CategoryDrug category)
        {
            try
            {
                _context.CategoryDrugs.Add(category);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
