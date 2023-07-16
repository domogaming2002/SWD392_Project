using Microsoft.EntityFrameworkCore;
using SWD392_Project.Models;
using System.Security.Claims;

namespace SWD392_Project.DataLayer.Manager
{
    public class MedicineManager
    {
        SWD_ProjectContext _context;
        public MedicineManager(SWD_ProjectContext context)
        { _context = context; }

        public List<Medicine>? GetListMedicine()
        {
            return _context.Medicines.Include(m => m.CategoryMedicine).Where(s => s.IsDelete == false).ToList();
        }

        public Medicine? GetListMedicineById(int medicineId)
        {
            return _context.Medicines.Include(m => m.CategoryMedicine).FirstOrDefault(s => s.MedicineId == medicineId && s.IsDelete == false);
        }

        public Boolean Create(Medicine medicine)
        {
            try
            {
                _context.Medicines.Add(medicine);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }


        }

        public Boolean Delelte(Medicine medicine)
        {
            try
            {
                Medicine? medicine1 = GetListMedicineById(medicine.MedicineId);
                medicine1.IsDelete = true;
                _context.Medicines.Update(medicine1);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean Update(Medicine medicine)
        {
            try
            {
                Medicine? medicine1 = GetListMedicineById(medicine.MedicineId);
                medicine1.MedicineName = medicine.MedicineName;
                medicine1.MedicineName = medicine.MedicineName;
                medicine1.CategoryMedicineId = medicine.CategoryMedicineId;
                medicine1.Unit = medicine.Unit;
                medicine1.Description = medicine.Description;
                _context.Medicines.Update(medicine1);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Medicine> GetListMedicineByName(string medicineName)
        {
            return _context.Medicines.Include(m => m.CategoryMedicine)
                .Where(m => m.MedicineName.ToLower().Contains(medicineName.ToLower()) && m.IsDelete == false).ToList();
        }

        public List<Medicine> GetListMedicineByCategoryId(int cateId)
        {
            return _context.Medicines.Include(m => m.CategoryMedicine)
                .Where(m => m.CategoryMedicineId == cateId && m.IsDelete == false).ToList();
        }
        public List<Medicine> GetRunOutMedicine()
        {
            List<Medicine> runOutMedicines = _context.Medicines
                                                    .Where(o => o.Quantity <= 15).ToList();
            return runOutMedicines;
        }
    }
}
