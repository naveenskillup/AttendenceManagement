using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementData;
using AttendenceManagementData.Definitions;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementApi.Data
{
    public class TeacherDataProvider : ITeacherDataProvider
    {

        public TeacherDataProvider(AMSDBContext context)
            => _context = context;

        public Teacher Get(int id)
            => _context.Teachers.FirstOrDefault(t => t.Id == id);

        public IEnumerable<Teacher> Get()
            => _context.Teachers;

        public void Save(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public bool TryUpdate(int id, Teacher teacher)
        {
            var existingTeacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (existingTeacher == null)
                return false;

            existingTeacher.FirstName = teacher.FirstName;
            existingTeacher.LastName = teacher.LastName;
            existingTeacher.Address = teacher.Address;
            existingTeacher.City = teacher.City;
            existingTeacher.State = teacher.State;
            existingTeacher.Salary = teacher.Salary;
            existingTeacher.Profile = teacher.Profile;
            _context.SaveChanges();
            return true;
        }

        public bool TryDelete(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
                return false;

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Teacher> Find(int? id, string? firstName, string? lastName)
        {
            var query = _context.Teachers.AsQueryable();

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
