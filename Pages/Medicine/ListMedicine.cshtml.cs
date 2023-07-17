using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.BussinessLayer.Repository;
using SWD392_Project.Helper;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.Medicine
{
    public class ListMedicineModel : PageModel
    {
        IMedicineRepository _medicineRepository;
        ICategoryMedicineRepository _categoryMedicine;
        IUserRepository _userRepository;

        public List<Models.Medicine> medicines { get; set; }
        public List<CategoryMedicine> categoryMedicines { get; set; }
        public List<Models.Medicine> runOutMedicines { get; set; }
        public ListMedicineModel(IMedicineRepository medicineRepository, ICategoryMedicineRepository categoryMedicineRepository, IUserRepository userRepository)
        {
            _medicineRepository = medicineRepository;
            _categoryMedicine = categoryMedicineRepository;
            _userRepository = userRepository;
        }
        public void OnGet(int categoryID)
        {
            if (categoryID == 0)
            {
                medicines = _medicineRepository.GetListMedicine();
            }
            else
            {
                medicines = _medicineRepository.GetListMedicineByCategoryId(categoryID);

            }
            GetData();
            GetRunOut();
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

            if (string.IsNullOrEmpty(HttpContext.Request.Form["categoryId"]))
            {
                TempData["messageResponse"] = "Add fail";
                return RedirectToPage();
            }
            int categoryId = Int32.Parse(HttpContext.Request.Form["categoryId"]);
            int quantity = Int32.Parse(HttpContext.Request.Form["medicineQuantity"]);
            string unit = HttpContext.Request.Form["medicineUnit"];
            string description = HttpContext.Request.Form["medicineDescription"];

            int? userId = SessionHelper.GetIdFromSession(HttpContext.Session, "userId");

            if (string.IsNullOrEmpty(medicineName) || string.IsNullOrEmpty(unit) || string.IsNullOrEmpty(description))
            {
                TempData["messageResponse"] = "Add fail";
                return RedirectToPage();
            }
            if (medicineName.Length > 50 || quantity < 0 || unit.Length > 50 || description.Length > 50 || categoryId == 0)
            {
                TempData["messageResponse"] = "Add fail";
                return RedirectToPage();

            }

            Models.Medicine medicine = new Models.Medicine();
            medicine.MedicineName = medicineName;
            medicine.CategoryMedicineId = categoryId;
            medicine.Quantity = quantity;
            medicine.Unit = unit;
            medicine.Description = description;
            medicine.CreatedAt = DateTime.Now;
            medicine.CreatedBy = userId.Value;

            try
            {
                _medicineRepository.Create(medicine);
            }
            catch (Exception e)
            {

                string ex = e.Message;
            }

            return RedirectToPage();
        }
        public void OnPostUpdate(string medicineName, int categoryId, int medicineQuantity, string medicineUnit, string medicineDescription, int medicineId)
        {

            Models.Medicine medicine = _medicineRepository.GetMedicineById(medicineId);
            if (medicine == null)
            {
                TempData["messageResponse"] = "Medicine Id not correct";
                OnGet(0);
                return;
            }
            if (string.IsNullOrEmpty(medicineName) || string.IsNullOrEmpty(medicineUnit) || string.IsNullOrEmpty(medicineDescription))
            {
                TempData["messageResponse"] = "Update fail";
                OnGet(0);
                return;
            }
            if (medicineName.Length > 50 || medicineQuantity < 0 || medicineUnit.Length > 50 || medicineDescription.Length > 50)
            {
                TempData["messageResponse"] = "Update fail";
                OnGet(0);
                return;
            }
            medicine = new Models.Medicine()
            {
                MedicineId = medicineId,
                MedicineName = medicineName,
                CategoryMedicineId = categoryId,
                Quantity = medicineQuantity,
                Unit = medicineUnit,
                Description = medicineDescription,
            };
            _medicineRepository.Update(medicine);
            if (!_medicineRepository.Update(medicine))
            {
                TempData["messageResponse"] = "Medicine Id not correct";
                OnGet(0);
                return;
            }
            OnGet(0);

        }
        public void OnPostDelete(int medicineId)
        {
            Models.Medicine medicine = _medicineRepository.GetMedicineById(medicineId);
            if (medicine == null)
            {
                TempData["messageResponse"] = "Medicine Id not correct";
                OnGet(0);
                return;
            }
            _medicineRepository.Delete(medicine);
            if (!_medicineRepository.Delete(medicine))
            {
                TempData["messageResponse"] = "Medicine Id not correct";
                OnGet(0);
                return;
            }
            OnGet(0);
        }

    }
}
