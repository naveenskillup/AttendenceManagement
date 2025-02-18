using AttendenceManagementDefinitions;
using AttendenceManagementDefinitions.DTOs;

namespace AttendenceManagementWeb.ExternalServices
{
    public interface IStudentServices
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
