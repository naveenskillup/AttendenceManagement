using AttendenceManagementApi.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{
    [Route("api/attendence")]
    [ApiController]
    public class AttendenceController : SharedController
    {
        public AttendenceController(IAttendenceDataProvider dataProvider)
            => _dataProvider = dataProvider;

        [HttpGet]
        public IActionResult Get(int classId, DateTime? date, bool openWithPresent = true)
        {
            var allStudentsInClass = _dataProvider.Get(classId, date, openWithPresent);

            return Ok(allStudentsInClass);
        }

        private readonly IAttendenceDataProvider _dataProvider;
    }
}
