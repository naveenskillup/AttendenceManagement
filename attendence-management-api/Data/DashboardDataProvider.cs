using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementData;
using AttendenceManagementDefinitions.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementApi.Data
{
    public class DashboardDataProvider : IDashboardDataProvider
    {
        public DashboardDataProvider(AMSDBContext context)
           => _context = context;

        public DashboardDto GetSummary()
        {
            var dashboardDto = new DashboardDto()
            {
                NumberOfTeachers = _context.Teachers.Count(),
                NumberOfStudents = _context.Students.Count(),
                NumberOfWorkers = 0,
            };
            return dashboardDto;
        }

        private readonly AMSDBContext _context;
    }
}
