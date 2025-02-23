using AttendenceManagement.Controllers;
using AttendenceManagementDefinitions;
using AttendenceManagementWeb.ExternalServices;
using AttendenceManagementWeb.Utilities.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementWeb.Controllers
{
    public class StudentController : SharedController
    {
        public StudentController(IStudentServices studentServices, ILogger<HomeController> logger) : base(logger)
          => _studentServices = studentServices;
        
        public async Task<IActionResult> Index()
        {
            var students = await _studentServices.GetAllStudentsAsync();
            return View(students);
        }

        public async Task<IActionResult> Save(Student student)
        {
            student = await _studentServices.AddStudentAsync(student);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _studentServices.DeleteStudentAsync(id);
            return RedirectToAction("Index");
        }

        private readonly IStudentServices _studentServices;
    }
}
