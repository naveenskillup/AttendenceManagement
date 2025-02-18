using AttendenceManagement.Controllers;
using AttendenceManagementDefinitions;
using AttendenceManagementWeb.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementWeb.Controllers
{
    public class TeacherController : SharedController
    {
        public TeacherController(ITeacherServices teacherServices, ILogger<HomeController> logger) : base(logger)
           => _teacherServices = teacherServices;

        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherServices.GetAllTeachersAsync();
            return View(teachers);
        }

        public async Task<IActionResult> Save(Teacher teacher)
        {
            teacher = await _teacherServices.AddTeacherAsync(teacher);
            return RedirectToAction("Index");
        }

        private readonly ITeacherServices _teacherServices;
    }
}
