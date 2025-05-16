using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendenceManagementDefinitions.DTOs
{
    public class AttendenceDto
    {
        public int StudentId { get; set; }
        public string RollNumber { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string FatherContact { get; set; }
        public bool IsPresent { get; set; } = false;
    }
}
