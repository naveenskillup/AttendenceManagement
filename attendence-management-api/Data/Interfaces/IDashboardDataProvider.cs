using AttendenceManagementDefinitions.DTOs;

namespace AttendenceManagementApi.Data.Interfaces
{
    public interface IDashboardDataProvider
    {
        DashboardDto GetSummary();
    }
}
