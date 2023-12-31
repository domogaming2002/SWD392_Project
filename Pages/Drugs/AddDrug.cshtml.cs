using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Models;
using System.ComponentModel.DataAnnotations;

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
        public int userId { get; set; }

        public AddDrugModel(ICategoryDrugRepository categoryRepository, IDrugRepository drugRepository)
        {
            _categoryRepository = categoryRepository;
            _drugRepository = drugRepository;
        }
        public void OnGet()
        {
            Categories = _categoryRepository.GetCategories();
        }

        public IActionResult OnPost(Models.Drug drug)
        {
            try
            {
                userId = HttpContext.Session.GetInt32("userId") ?? 0;
                drug.CreatedBy = userId;
                drug.CategoryDrugId = CategoryId;
                _drugRepository.AddDrug(drug);
                Categories = _categoryRepository.GetCategories();
                return RedirectToPage("/Drugs/ListDrug");
            }
            catch (Exception e)
            {
                Categories = _categoryRepository.GetCategories();
                TempData["ErrorMessage"] = "An error occurred while adding the drug. Please check and try again later.";
                return Page();
            }

        }
    }
}
