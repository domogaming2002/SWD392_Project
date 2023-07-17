using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.DataLayer.Manager;
using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.Repository
{
    public class ReportRepository : IReportRepository
    {
        ReportManager manager;
        SWD_ProjectContext _context;

        public ReportRepository(SWD_ProjectContext context)
        {
            _context = context;
            manager = new ReportManager(_context);
        }
        public bool Create(Report report)
        {
            return manager.Create(report);
        }
        public List<Report>? GetListReport()
        {
            return manager.GetListReport();
        }
        public Report? GetReportById(int reportId)
        {
            return manager.GetReportById(reportId);
        }

        public List<Report> GetListReportByName(string reportName)
        {
            return manager.GetListReportByName(reportName);
        }
    }
}
