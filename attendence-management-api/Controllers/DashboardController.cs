using AttendenceManagementApi.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : SharedController
    {
        public DashboardController(IDashboardDataProvider dataProvider)
            => _dataProvider = dataProvider;

        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            var dashboardDto = _dataProvider.GetSummary();

            return Ok(dashboardDto);
        }

        private readonly IDashboardDataProvider _dataProvider;
    }
}
