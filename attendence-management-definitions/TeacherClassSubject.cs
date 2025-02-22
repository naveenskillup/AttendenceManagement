using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendenceManagementDefinitions
{
    [Table("TeacherClassSubject",Schema = "dbo")]
    public class TeacherClassSubject
    {
        [Key]
        public int Id { get; set; }

        public int ClassInfoId { get; set; }
        public required ClassInfo ClassInfo { get; set; }

        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public required Subject Subject { get; set; }

    }
}
