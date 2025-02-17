using AttendenceManagementDefinitions;

namespace AttendenceManagementApi.Data.Interfaces
{
    public interface IStudentDataProvider
    {
        Student? Get(int id);
        IEnumerable<Student> Get();
        void Save(Student teacher);
        bool TryUpdate(int id, Student teacher);
        bool TryDelete(int id);
        IEnumerable<Student> Find(int? id, string? firstName, string? lastName);
    }
}
