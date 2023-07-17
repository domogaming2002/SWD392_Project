using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface IReportRepository
    {
        List<Report>? GetListReport();
        Report? GetReportById(int reportId);
        Boolean Create(Report report);
        List<Report> GetListReportByName(string reportName);
    }
}
