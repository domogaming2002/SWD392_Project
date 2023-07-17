using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface IDrugRepository
    {
        public int GetNextId();
        public void AddDrug(Drug drug);
        public bool IsLowStock(List<Drug> drugs);
        public ICollection<Drug> GetDrugs();

    }
}
