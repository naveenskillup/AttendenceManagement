using System.Diagnostics;
using AttendenceManagement.Models;
using AttendenceManagementWeb.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStudentServices _studentServices;

        public HomeController(ILogger<HomeController> logger, IStudentServices studentServices)
        {
            _logger = logger;
            _studentServices = studentServices;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _studentServices.GetAllStudentsAsync();
            _logger.LogInformation("Index visited");
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
