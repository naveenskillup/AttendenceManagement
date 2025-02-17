using AttendenceManagementDefinitions;

namespace AttendenceManagementWeb.ExternalServices
{
    public interface ITeacherServices
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher?> GetTeacherByIdAsync(int id);
        Task<Teacher> AddTeacherAsync(Teacher teacher);
        Task<bool> UpdateTeacherAsync(int id, Teacher teacher);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
