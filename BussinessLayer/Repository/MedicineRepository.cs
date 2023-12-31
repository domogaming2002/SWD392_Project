﻿using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.DataLayer.Manager;
using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        MedicineManager manager;
        SWD_ProjectContext _context;

        public MedicineRepository(SWD_ProjectContext context)
        {
            _context = context;
            manager = new MedicineManager(_context);
        }
        public bool Create(Medicine medicine)
        {
            return manager.Create(medicine);
        }

        public bool Delete(Medicine medicine)
        {
            return manager.Delete(medicine);
        }

        public List<Medicine>? GetListMedicine()
        {
            return manager.GetListMedicine();
        }

        public List<Medicine> GetListMedicineByCategoryId(int cateId)
        {
            return manager.GetListMedicineByCategoryId(cateId);
        }

        public Medicine? GetMedicineById(int medicineId)
        {
            return manager.GetMedicineById(medicineId);
        }

        public List<Medicine> GetListMedicineByName(string medicineName)
        {
            return manager.GetListMedicineByName(medicineName);
        }

        public bool Update(Medicine medicine)
        {
            return manager.Update(medicine);
        }
        public List<Medicine> GetRunOutMedicine()
        {
            return manager.GetRunOutMedicine();
        }
    }
}
