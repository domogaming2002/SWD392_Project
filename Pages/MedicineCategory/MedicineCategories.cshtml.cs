using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.MedicineCategory
{
    public class MedicineCategoriesModel : PageModel
    {
        ICategoryMedicineRepository categoryMedicineRepository;
        public List<CategoryMedicine> categories { set; get; }
        public void OnGet()
        {
            GetData();
        }
        public MedicineCategoriesModel(ICategoryMedicineRepository categoryMedicineRepository)
        {
            this.categoryMedicineRepository = categoryMedicineRepository;

        }
        public void GetData()
        {
            categories = categoryMedicineRepository.GetListMedicineCategory();

        }
        public IActionResult OnPostCreateMedicine()
        {
            // get input "medicineNameCategory" 
            string medicineNameCategory = HttpContext.Request.Form["medicineNameCategory"];

            // get input "description" 
            string description = HttpContext.Request.Form["description"];

            try
            {
                CategoryMedicine category = new CategoryMedicine();
                category.CategoryMedicineName = medicineNameCategory;
                category.Description = description;
                categoryMedicineRepository.AddCategory(category);
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
