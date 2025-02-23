using AttendenceManagementApi.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{
    [Route("api/attendence")]
    [ApiController]
    public class AttendenceController : SharedController
    {
        public AttendenceController(IDashboardDataProvider dataProvider)
            => _dataProvider = dataProvider;

        [HttpGet]
        public IActionResult Get(int classId, DateTime? date)
        {
            var dashboardDto = _dataProvider.GetSummary();

            return Ok(dashboardDto);
        }

        private readonly IDashboardDataProvider _dataProvider;
    }
}
