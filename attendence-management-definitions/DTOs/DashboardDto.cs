namespace AttendenceManagementDefinitions.DTOs
{
    public class DashboardDto
    {
        public DashboardDto()
        {
            
        }
        public int NumberOfTeachers { set; get; }
        public int NumberOfStudents { set; get; }
        public int NumberOfWorkers { set; get; }
        public IEnumerable<AttendanceRecordDto>? AttendanceRecords { get; set; } = new List<AttendanceRecordDto>();
    }

    public class AttendanceRecordDto
    {
        public int Class { set; get; }
        public string TeacherName { set; get; }
        public string? ContactNumber { set; get; }
        public int Present { set; get; }
        public int Total { set; get; }

        public int Absent {
            get { return Total - Present; }
        }
    }
}
