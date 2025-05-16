using AttendenceManagementDefinitions.DTOs;

namespace AttendenceManagementApi.Data.Interfaces
{
    public interface IAttendenceDataProvider
    {
        IEnumerable<AttendenceDto> Get(int classId, DateTime? date, bool openWithPresent);
    }
}
