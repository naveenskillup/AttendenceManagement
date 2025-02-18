using AttendenceManagement.Controllers;
using AttendenceManagementWeb.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementWeb.Controllers
{
    public class SharedController : Controller
    {
        public SharedController(ILogger<SharedController> logger)
            => Logger = logger;

        protected readonly ILogger<SharedController> Logger;
    }
}
