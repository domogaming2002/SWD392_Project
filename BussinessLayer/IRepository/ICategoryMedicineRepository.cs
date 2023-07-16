using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface ICategoryMedicineRepository
    {
        List<CategoryMedicine>? GetListMedicineCategory();
        void AddCategory(CategoryMedicine category);
    }
}
