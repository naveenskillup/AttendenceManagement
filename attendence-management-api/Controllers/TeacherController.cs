using AttendenceManagementApi.Data;
using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementData;
using AttendenceManagementData.Definitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{

    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : CommonController
    {

        public TeacherController(ITeacherDataProvider dataProvider)
            => _dataProvider = dataProvider;

        [HttpGet]
        public IActionResult Get(int id)
        {
            var teacher = _dataProvider.Get(id);
            if(teacher == null)
                return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Save([FromBody]Teacher teacher)
        {
            _dataProvider.Save(teacher);
            
            return Ok(teacher);
        }


        private readonly ITeacherDataProvider _dataProvider;
    }

}
