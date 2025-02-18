using AttendenceManagementDefinitions.DTOs;

namespace AttendenceManagementWeb.Utilities.Adapters.Interfaces
{
    public interface IDashboardServices
    {
        Task<DashboardDto> GetSummaryAsync();
    }
}
