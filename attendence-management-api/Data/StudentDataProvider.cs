using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementData;
using AttendenceManagementData.Definitions;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementApi.Data
{
    public class StudentDataProvider : IStudentDataProvider
    {

        public StudentDataProvider(AMSDBContext context)
            => _context = context;

        public Student? Get(int id)
            => _context.Students.FirstOrDefault(t => t.Id == id);

        public IEnumerable<Student> Get()
            => _context.Students;

        public void Save(Student teacher)
        {
            _context.Students.Add(teacher);
            _context.SaveChanges();
        }

        public bool TryUpdate(int id, Student teacher)
        {
            var existingStudent = _context.Students.FirstOrDefault(t => t.Id == id);
            if (existingStudent == null)
                return false;

            existingStudent.FirstName = teacher.FirstName;
            existingStudent.LastName = teacher.LastName;
            existingStudent.Address = teacher.Address;
            existingStudent.City = teacher.City;
            existingStudent.State = teacher.State;
            existingStudent.Profile = teacher.Profile;
            _context.SaveChanges();
            return true;
        }

        public bool TryDelete(int id)
        {
            var teacher = _context.Students.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                return false;

            _context.Students.Remove(teacher);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Student> Find(int? id, string? firstName, string? lastName)
        {
            var query = _context.Students.AsQueryable();

            if (id.HasValue)
                query = query.Where(t => t.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(firstName))
                query = query.Where(t => t.FirstName.Contains(firstName));

            if (!string.IsNullOrWhiteSpace(lastName))
                query = query.Where(t => t.LastName.Contains(lastName));

            return query.ToList();
        }

        private readonly AMSDBContext _context;
    }
}
