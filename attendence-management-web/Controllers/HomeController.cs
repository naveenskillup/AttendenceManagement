using System.Diagnostics;
using AttendenceManagement.Models;
using AttendenceManagementWeb.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExternalApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger, ExternalApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStudents()
        {
            return View("Students");
        }

        public IActionResult GetTeachers()
        {
            return View("Teachers");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
