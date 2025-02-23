using AttendenceManagementDefinitions;
using AttendenceManagementApi.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{

    [Route("api/student")]
    [ApiController]
    public class StudentController : SharedController
    {

        public StudentController(IStudentDataProvider dataProvider)
            => _dataProvider = dataProvider;

        [HttpGet]
        public IActionResult Get(int id)
        {
            var student = _dataProvider.Get(id);
            return Ok(student);
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            var students = _dataProvider.Get();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Student student)
        {
            _dataProvider.Save(student);
            return Ok(student);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            if (student == null || id <= 0)
                return BadRequest(new { Message = "Student data is required" });

            if (!_dataProvider.TryUpdate(id, student))
                return NotFound(new { Message = $"Student with ID {id} is not found" });

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!_dataProvider.TryDelete(id))
                return NotFound();

            return Ok(true);
        }

        [HttpGet("find")]
        public IActionResult Find(int? id, string? firstName, string? lastName)
        {
            if (id <= 0 && string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return BadRequest();

            var students = _dataProvider.Find(id, firstName, lastName);

            return Ok(students);
        }

        private readonly IStudentDataProvider _dataProvider;
    }

}
