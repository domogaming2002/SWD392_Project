using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.Medicine
{
    public class ListMedicineModel : PageModel
    {
        IMedicineRepository _medicineRepository;
        ICategoryMedicineRepository _categoryMedicine;

        public List<Models.Medicine> medicines { get; set; }
        public List<CategoryMedicine> categoryMedicines { get; set; }
        public ListMedicineModel(IMedicineRepository medicineRepository, ICategoryMedicineRepository categoryMedicineRepository)
        {
            _medicineRepository = medicineRepository;
            _categoryMedicine = categoryMedicineRepository;
        }
        public void OnGet()
        {
            GetData();
        }

        private void GetData()
        {
            categoryMedicines = _categoryMedicine.GetListMedicineCategory();
        }
    }
}
