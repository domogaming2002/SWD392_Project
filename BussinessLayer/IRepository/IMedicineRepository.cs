using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface IMedicineRepository
    {
        List<Medicine>? GetListMedicine();
        Medicine? GetListMedicineById(int medicineId);
        Boolean Create(Medicine medicine);
        Boolean Delelte(Medicine medicine);
        Boolean Update(Medicine medicine);
        List<Medicine> GetListMedicineByName(string medicineName);
        List<Medicine> GetListMedicineByCategoryId(int cateId);
        List<Medicine> GetRunOutMedicine();
    }
}
