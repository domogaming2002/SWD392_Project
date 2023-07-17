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
                return _context.Drugs.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
