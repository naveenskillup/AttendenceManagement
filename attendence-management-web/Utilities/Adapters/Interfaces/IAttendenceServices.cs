using AttendenceManagementDefinitions.DTOs;

namespace AttendenceManagementWeb.Utilities.Adapters.Interfaces
{
    public interface IAttendenceServices
    {
        Task<IEnumerable<AttendenceDto>> GetStudentsAsync(int classId, DateTime? date);
    }
}
