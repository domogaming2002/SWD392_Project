using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.Drugs
{
    public class AddDrugModel : PageModel
    {
        [BindProperty]
        public int CategoryId { get; set; }
        private ICategoryDrugRepository _categoryRepository;
        private IDrugRepository _drugRepository;
        public Models.Drug Drug { get; set; }
        public ICollection<CategoryDrug> Categories { get; set; }
        public int DrugId { get; set; }
        public int roleId { get; set; }

        public AddDrugModel(ICategoryDrugRepository categoryRepository, IDrugRepository drugRepository)
        {
            _categoryRepository = categoryRepository;
            _drugRepository = drugRepository;
        }
        public void OnGet()
        {
            //DrugId = _drugRepository.GetNextId();
            Categories = _categoryRepository.GetCategories();
        }

        public IActionResult OnPost(Models.Drug drug)
        {
            //drug.CreatedBy = 1;
            roleId = HttpContext.Session.GetInt32("roleId") ?? 0;
            drug.CreatedBy = roleId;
            drug.CategoryDrugId = CategoryId;
            _drugRepository.AddDrug(drug);
            Categories = _categoryRepository.GetCategories();
            return RedirectToPage("/Drugs/ListDrug");
        }
    }
}
