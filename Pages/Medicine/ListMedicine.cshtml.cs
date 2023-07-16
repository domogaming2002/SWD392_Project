using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.BussinessLayer.Repository;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.Medicine
{
    public class ListMedicineModel : PageModel
    {
        IMedicineRepository _medicineRepository;
        ICategoryMedicineRepository _categoryMedicine;

        public List<Models.Medicine> medicines { get; set; }
        public List<CategoryMedicine> categoryMedicines { get; set; }
        public List<Models.Medicine> runOutMedicines { get; set; }
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
        private void GetRunOut()
        {
            runOutMedicines = _medicineRepository.GetRunOutMedicine();
        }
        public IActionResult OnPostCreateMedicine()
        {
            string medicineName = HttpContext.Request.Form["medicineName"];

            int categoryId = Int32.Parse(HttpContext.Request.Form["categoryId"]);
            int quantity = Int32.Parse(HttpContext.Request.Form["medicineQuantity"]);
            string unit = HttpContext.Request.Form["medicineUnit"];
            string description = HttpContext.Request.Form["medicineDescription"];

            try
            {

            }
            catch (Exception e)
            {

                string ex = e.Message;
            }

            // TODO: Xử lý giá trị của hai trường input này

            return RedirectToPage();
        }
    }
}
