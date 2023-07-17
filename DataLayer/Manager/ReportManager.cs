using Microsoft.EntityFrameworkCore;
using SWD392_Project.Models;

namespace SWD392_Project.DataLayer.Manager
{
    public class ReportManager
    {
        SWD_ProjectContext _context;
        public ReportManager(SWD_ProjectContext context)
        { _context = context; }

        public List<Report>? GetListReport()
        {
            return _context.Reports.Include(m => m.CreatedByNavigation).Where(s => s.IsDelete == false).ToList();
        }

        public Report? GetReportById(int reportId)
        {
            return _context.Reports.Include(m => m.CreatedByNavigation).FirstOrDefault(s => s.ReportId == reportId && s.IsDelete == false);
        }

        public Boolean Create(Report report)
        {
            try
            {
                _context.Reports.Add(report);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Report> GetListReportByName(string reportName)
        {
            return _context.Reports.Include(m => m.CreatedByNavigation)
                .Where(m => m.ReportName.ToLower().Contains(reportName.ToLower()) && m.IsDelete == false).ToList();
        }
    }
}
