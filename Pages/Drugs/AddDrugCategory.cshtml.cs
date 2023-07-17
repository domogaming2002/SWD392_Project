using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.BussinessLayer.Repository;

namespace SWD392_Project.Pages.Drugs
{
    public class AddDrugCategoryModel : PageModel
    {
        public Models.CategoryDrug DrugCategory { get; set; }

        private ICategoryDrugRepository _categoryRepository;
        public AddDrugCategoryModel(ICategoryDrugRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Models.CategoryDrug drugCategory)
        {
            _categoryRepository.AddDrugCategory(drugCategory);
            return RedirectToPage("/Drugs/ListDrug");
        }
    }
}
