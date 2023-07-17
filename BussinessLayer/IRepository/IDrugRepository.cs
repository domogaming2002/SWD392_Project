using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface IDrugRepository
    {
        public void AddDrug(Drug drug);
        public ICollection<Drug> GetDrugs();
        public Drug GetDrugById(int id);
        public void DeleteDrug(int id);
        public void UpdateDrug(Drug drug);
    }
}
