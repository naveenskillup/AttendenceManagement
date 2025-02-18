using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementWeb.Controllers
{
    public class AttendenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
