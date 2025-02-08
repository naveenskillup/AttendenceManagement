using AttendenceManagementData.Definitions;

namespace AttendenceManagementApi.Data.Interfaces
{
    public interface ITeacherDataProvider
    {
        Teacher Get(int id);
        IEnumerable<Teacher> Get();
        void Save(Teacher teacher);
        void Update(int id, Teacher teacher);
        void Delete(int id);
        IEnumerable<Teacher> Find(int? id, string firstName, string lastName);
    }
}
