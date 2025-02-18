using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementDefinitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{
    [Route("api/classinfo")]
    [ApiController]
    public class ClassInfoController : SharedController
    {
        public ClassInfoController(IClassInfoDataProvider dataProvider)
            => _dataProvider = dataProvider;

        [HttpGet]
        public IActionResult Get(int id)
        {
            var classInfo = _dataProvider.Get(id);

            return Ok(classInfo);
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            var classInfo = _dataProvider.Get();

            return Ok(classInfo);
        }

        [HttpPost]
        public IActionResult Save([FromBody]ClassInfo classInfo)
        {
            _dataProvider.Save(classInfo);
            return Ok(classInfo);
        }

        private readonly IClassInfoDataProvider _dataProvider;
    }
}
