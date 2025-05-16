using System.Linq;
using AttendenceManagementWeb.ExternalServices;
using AttendenceManagementWeb.Utilities.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementWeb.Controllers
{
    public class AttendenceController : SharedController
    {
        public AttendenceController(IAttendenceServices attendenceServices, ILogger<AttendenceController> logger) : base(logger)
         => _attendenceServices = attendenceServices;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentsAttendence(int classId, DateTime? date, bool openWithAbsent = true)
        {
            var students = _attendenceServices.GetStudentsAsync(classId, date);
            return View("Index", students);
        }

        private readonly IAttendenceServices _attendenceServices;
    }
}
