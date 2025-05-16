using AttendenceManagementDefinitions.DTOs;
using AttendenceManagementWeb.ExternalServices;
using AttendenceManagementWeb.Utilities.Adapters.Interfaces;

namespace AttendenceManagementWeb.Utilities.Adapters
{
    public class AttendenceServices : IAttendenceServices
    {
        private readonly ExternalApiClient _apiClient;

        public AttendenceServices(ExternalApiClient apiClient)
             => _apiClient = apiClient;

        public async Task<IEnumerable<AttendenceDto>> GetStudentsAsync(int classId, DateTime? date)
         => await _apiClient.SendRequestAsync<IEnumerable<AttendenceDto>>(HttpMethod.Get, $"classinfo?classId={classId}&date={date}", null);
    }
}
