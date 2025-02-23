using AttendenceManagement.Controllers;
using AttendenceManagementDefinitions;
using AttendenceManagementWeb.ExternalServices;
using AttendenceManagementWeb.Utilities.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementWeb.Controllers
{
    public class ClassInfoController : SharedController
    {
        public ClassInfoController(IClassInfoServices classInfoServices, ILogger<HomeController> logger) : base(logger)
         => _classInfoServices = classInfoServices;

        public async Task<IActionResult> Index()
        {
            var classInfos = await _classInfoServices.GetClassInfosAsync();
            return View(classInfos);
        }

        public async Task<IActionResult> Save(ClassInfo classInfo)
        {
            classInfo = await _classInfoServices.AddClassInfoAsync(classInfo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _classInfoServices.DeleteClassInfoAsync(id);
            return RedirectToAction("Index");
        }

        private readonly IClassInfoServices _classInfoServices;
    }
}
