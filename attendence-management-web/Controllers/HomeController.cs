using System.Diagnostics;
using AttendenceManagement.Models;
using AttendenceManagementDefinitions.DTOs;
using AttendenceManagementWeb.Controllers;
using AttendenceManagementWeb.ExternalServices;
using AttendenceManagementWeb.Models;
using AttendenceManagementWeb.Utilities.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagement.Controllers
{
    public class HomeController : SharedController
    {
        public HomeController(IDashboardServices dashboardServices, ILogger<HomeController> logger): base(logger)
            => _dashboardServices = dashboardServices;

        public async Task<IActionResult> Index()
        {
            try
            {
                var dashboardViewData = await _dashboardServices.GetSummaryAsync();
                dashboardViewData.AttendanceRecords = new List<AttendanceRecordDto>{
                    new AttendanceRecordDto { Class = 7, TeacherName = "Prasanna Nayakam", ContactNumber = "7893483740", Present = 40, Total = 80},
                    new AttendanceRecordDto { Class = 8, TeacherName = "Naveen Kumar Cheruku", ContactNumber = "8555007029", Present = 12, Total = 50},
                    new AttendanceRecordDto { Class = 9, TeacherName = "Pavitra", ContactNumber = "9182897123", Present = 20, Total = 40}
                };

                return View(dashboardViewData);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly IDashboardServices _dashboardServices;
    }
}
