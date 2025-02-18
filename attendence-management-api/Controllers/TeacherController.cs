using AttendenceManagementDefinitions;
using AttendenceManagementApi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{

    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : SharedController
    {

        public TeacherController(ITeacherDataProvider dataProvider)
            => _dataProvider = dataProvider;

        [HttpGet]
        public IActionResult Get(int id)
        {
            var teacher = _dataProvider.Get(id);
            return Ok(teacher);
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            var teachers = _dataProvider.Get();
            return Ok(teachers);
        }

        [HttpPost]
        public IActionResult Save([FromBody]Teacher teacher)
        {
            _dataProvider.Save(teacher);
            return Ok(teacher);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Teacher teacher)
        {
            if (teacher == null || id <= 0)
                return BadRequest(new { Message = "Teacher data is required" });

            if (!_dataProvider.TryUpdate(id, teacher))
                return NotFound(new { Message = $"Teacher with ID {id} is not found" });

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!_dataProvider.TryDelete(id))
                return NotFound();

            return Ok();
        }

        [HttpGet("find")]
        public IActionResult Find(int? id, string? firstName, string? lastName)
        {
            if (id <= 0 && string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return BadRequest();

            var teachers = _dataProvider.Find(id, firstName, lastName);
            
            if(teachers.Count() <= 0)
                return NotFound();

            return Ok(teachers);
        }

        private readonly ITeacherDataProvider _dataProvider;
    }

}
