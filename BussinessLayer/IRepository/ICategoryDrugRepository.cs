using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface ICategoryDrugRepository
    {
        public ICollection<CategoryDrug> GetCategories();
        public void AddDrugCategory(CategoryDrug category);
    }
}
