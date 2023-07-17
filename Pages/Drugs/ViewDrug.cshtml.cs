using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Helper;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.Drugs
{
    public class ViewDrugModel : PageModel
    {
        private IDrugRepository _drugRepository;

        private ICategoryDrugRepository _categoryRepository;
        public ICollection<CategoryDrug> Categories { get; set; }
        public Drug Drug { get; set; }
        public ViewDrugModel(ICategoryDrugRepository categoryRepository, IDrugRepository drugRepository)
        {
            _categoryRepository = categoryRepository;
            _drugRepository = drugRepository;
        }
        public void OnGet(int drugId)
        {
            Categories = _categoryRepository.GetCategories();
            Drug = _drugRepository.GetDrugById(drugId);
        }
        public IActionResult OnPostUpdate(int drugId, string name, int categoryId, string unit, int quantity, double price, string description)
        {
            Drug d = new Drug();
            d.DrugId = drugId;
            d.DrugName = name;
            d.CategoryDrugId = categoryId;
            d.Unit = unit;
            d.Quantity = quantity;
            d.Price = (decimal)price;
            d.Description = description;    
            d.CreatedAt = DateTime.Now;
            d.CreatedBy = (int)SessionHelper.GetIdFromSession(HttpContext.Session, "userId");
            _drugRepository.UpdateDrug(d);
            return Redirect("/Drugs/ListDrug");
        }
        public IActionResult OnPostDelete(int drugId)
        {
            _drugRepository.DeleteDrug(drugId);
            return Redirect("/Drugs/ListDrug");
        }
    }
}
