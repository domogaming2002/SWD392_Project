using Microsoft.EntityFrameworkCore;
using SWD392_Project.Models;

namespace SWD392_Project.DataLayer.Manager
{
    public class DrugManager
    {
        private SWD_ProjectContext _context;
        public DrugManager(SWD_ProjectContext context)
        {
            _context = context;
        }

        public int GetNextId()
        {
            try
            {
                return _context.Drugs.OrderByDescending(x => x.DrugId).First().DrugId + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddDrug(Drug drug)
        {
            try
            {
                drug.IsDelete = false;
                drug.CreatedAt = DateTime.Now;
                _context.Drugs.Add(drug);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool IsLowStock(List<Drug> drugs)
        {
            foreach (Drug drug in drugs)
            {
                if (drug.Quantity <= 15)
                {
                    return true;
                }
            }
            return false;
        }

        public ICollection<Drug> GetDrugs()
        {
            try
            {
                return _context.Drugs.Where(d => d.IsDelete == false).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Drug GetDrugById(int id)
        {
            return _context.Drugs
                .Include(d => d.CategoryDrug)
                .Include(d => d.CreatedByNavigation)
                .FirstOrDefault(d => d.DrugId == id);
        }

        public void DeleteDrug(int id)
        {
            Drug d = _context.Drugs.FirstOrDefault(p => p.DrugId == id);
            d.IsDelete = true;
            _context.Update(d);
            _context.SaveChanges();
        }

        public void UpdateDrug(Drug drug)
        {
            Drug d = _context.Drugs.FirstOrDefault(p => p.DrugId == drug.DrugId);
            d.DrugName = drug.DrugName; 
            d.Price = drug.Price; 
            d.Quantity = drug.Quantity; 
            d.Unit = drug.Unit; 
            d.CategoryDrugId = drug.CategoryDrugId;
            d.CreatedAt = drug.CreatedAt;
            d.CreatedBy = drug.CreatedBy;
            d.Description = drug.Description;
            _context.Update(d);
            _context.SaveChanges();
        }
    }
}
