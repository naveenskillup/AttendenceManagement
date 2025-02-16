using AttendenceManagementData.Definitions;

namespace AttendenceManagementApi.Data.Interfaces
{
    public interface ITeacherDataProvider
    {
        Teacher Get(int id);
        IEnumerable<Teacher> Get();
        void Save(Teacher teacher);
        bool TryUpdate(int id, Teacher teacher);
        bool TryDelete(int id);
        IEnumerable<Teacher> Find(int? id, string? firstName, string? lastName);
    }
}
