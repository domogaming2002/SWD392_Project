using Microsoft.EntityFrameworkCore;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.DataLayer.Manager;
using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.Repository
{
    public class DrugRepository : IDrugRepository
    {
        private DrugManager manager;
        private SWD_ProjectContext _context;
        public DrugRepository(SWD_ProjectContext context)
        {
            _context = context;
            manager = new DrugManager(_context);
        }

        public void AddDrug(Drug drug)
        {
            manager.AddDrug(drug);
        }

        public ICollection<Drug> GetDrugs()
        {
            return manager.GetDrugs();
        }

        public int GetNextId()
        {
            return manager.GetNextId();
        }

        public bool IsLowStock(List<Drug> drugs)
        {
            return manager.IsLowStock(drugs);
        }
    }
}
