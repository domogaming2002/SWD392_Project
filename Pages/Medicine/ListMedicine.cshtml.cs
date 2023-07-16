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
        public void OnGet(int categoryID)
        {
            if(categoryID == 0)
            {
                medicines = _medicineRepository.GetListMedicine();
            }
            else
            {
                medicines = _medicineRepository.GetListMedicineByCategoryId(categoryID);

            }
            GetData();
        }

        private void GetData()
        {
            categoryMedicines = _categoryMedicine.GetListMedicineCategory();
        }
        public void OnPostUpdate(string medicineName, int categoryId, int medicineQuantity, string medicineUnit, string medicineDescription, int medicineId)
        {

            Models.Medicine medicine = _medicineRepository.GetMedicineById(medicineId);
            if(medicine == null)
            {
                TempData["messageResponse"] = "Medicine Id not correct";
                OnGet(0);
                return;
            }
            if(string.IsNullOrEmpty(medicineName) || string.IsNullOrEmpty(medicineUnit) || string.IsNullOrEmpty(medicineDescription))
            {
                TempData["messageResponse"] = "Update fail";
                OnGet(0);
                return;
            }
            if(medicineName.Length > 50  || medicineQuantity < 0 || medicineUnit.Length > 50 || medicineDescription.Length > 50 )
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
