using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Helper;

namespace SWD392_Project.Pages.Report
{
    public class ListReportModel : PageModel
    {
        IReportRepository _reportRepository;
        IUserRepository _userRepository;

        public List<Models.Report> reports { get; set; }
        public ListReportModel(IReportRepository reportRepository, IUserRepository userRepository)
        {
            _reportRepository = reportRepository;
            _userRepository = userRepository;
        }
        public void OnGet(int categoryID)
        {
            reports = _reportRepository.GetListReport();
        }

        public IActionResult OnPostCreateReport()
        {
            string reportName = HttpContext.Request.Form["reportName"];

            string description = HttpContext.Request.Form["reportDescription"];

            int? created_by = SessionHelper.GetIdFromSession(HttpContext.Session, "userId");

            if (string.IsNullOrEmpty(reportName) || string.IsNullOrEmpty(description))
            {
                TempData["messageResponse"] = "Add fail";
                return RedirectToPage();
            }
            if (reportName.Length > 50 || description.Length > 8000)
            {
                TempData["messageResponse"] = "Add fail";
                return RedirectToPage();

            }

            Models.Report report = new Models.Report();
            report.ReportName = reportName;
            report.Description = description;
            report.CreatedAt = DateTime.Now;
            report.CreatedBy = created_by.Value;

            try
            {
                _reportRepository.Create(report);
            }
            catch (Exception e)
            {

                string ex = e.Message;
            }

            return RedirectToPage();
        }
    }
}
