namespace AttendenceManagementWeb.Models
{
    public class DashboardViewModel
    {
        public int NumberOfTeachers { set; get; }
        public int NumberOfStudents { set; get; }
        public int NumberOfWorkers { set; get; }
        public IEnumerable<AttendanceRecordViewModel>? AttendanceRecords { get; set; }
    }

    public class AttendanceRecordViewModel
    {
        public int Class { set; get; }
        public int? Teacher { set; get; }
        public string? ContactNumber { set; get; }
        public int Present { set; get; }
        public int Total { set; get; }

        public int Absent{
            get { return Total - Present; }
        }
    }
}
