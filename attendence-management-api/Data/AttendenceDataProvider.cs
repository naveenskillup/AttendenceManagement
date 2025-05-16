using attendence_management_api.Migrations;
using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementData;
using AttendenceManagementDefinitions;
using AttendenceManagementDefinitions.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementApi.Data
{
    public class AttendenceDataProvider : IAttendenceDataProvider
    {
        public AttendenceDataProvider(AMSDBContext context)
         => _context = context;

        public IEnumerable<AttendenceDto> Get(int classId, DateTime? date, bool openWithPresent)
        {
            var studentInClass = _context.ClassInfos.Where(ci => ci.Class == classId)
                .Include(ci => ci.Students)
                .SelectMany(ci => ci.Students)
                .Select(s => new AttendenceDto
                {
                    StudentId = s.Id,
                    StudentName = s.FullName,
                    RollNumber = s.RollNumber,
                    FatherContact = s.FatherMobileNumber,
                    FatherName = s.FatherName,
                    IsPresent = !openWithPresent
                });

            return studentInClass;
        }

        private readonly AMSDBContext _context;
    }
}
