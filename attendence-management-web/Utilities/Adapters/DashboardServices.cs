using AttendenceManagementDefinitions.DTOs;
using AttendenceManagementWeb.ExternalServices;
using AttendenceManagementWeb.Utilities.Adapters.Interfaces;

namespace AttendenceManagementWeb.ExternalServices
{
    public class DashboardServices : IDashboardServices
    {
        private readonly ExternalApiClient _apiClient;


        public DashboardServices(ExternalApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<DashboardDto> GetSummaryAsync()
         => await _apiClient.SendRequestAsync<DashboardDto>(HttpMethod.Get, "dashboard/summary", null);
    }
}
