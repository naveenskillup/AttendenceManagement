using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementData;
using AttendenceManagementDefinitions;
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

        public void Save(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public bool TryUpdate(int id, Student student)
        { 
            var existingStudent = _context.Students.FirstOrDefault(t => t.Id == id);
            if (existingStudent == null)
                return false;

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Address = student.Address;
            existingStudent.City = student.City;
            existingStudent.State = student.State;
            existingStudent.Profile = student.Profile;
            _context.SaveChanges();
            return true;
        }

        public bool TryDelete(int id)
        {
            var student = _context.Students.FirstOrDefault(t => t.Id == id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
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
