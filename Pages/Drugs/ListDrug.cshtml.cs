using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.BussinessLayer.Repository;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.Drugs
{
    public class ListDrugModel : PageModel
    {
        private IDrugRepository _drugRepository;

        private ICategoryDrugRepository _categoryRepository;
        public ICollection<CategoryDrug> Categories { get; set; }
        public ICollection<Drug> Drugs { get; set; }

        public ListDrugModel(ICategoryDrugRepository categoryRepository, IDrugRepository drugRepository)
        {
            _categoryRepository = categoryRepository;
            _drugRepository = drugRepository;
        }
        public void OnGet()
        {
            Categories = _categoryRepository.GetCategories();
            Drugs = _drugRepository.GetDrugs();
        }
    }
}
