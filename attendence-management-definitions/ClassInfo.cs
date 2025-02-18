using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AttendenceManagementDefinitions
{
    [Table("ClassInfo", Schema = "dbo")]
    public class ClassInfo
    {
        [Key]
        public int Id { get; set; }
        public int Class { get; set; }
        public int Limit { get; set; }
        public char? Section { get; set; }

        /*Class contain number of students*/
        public ICollection<Student>? Students { get; set; }

        public ICollection<TeacherClassSubject>? TeacherClassSubjects { get; set; }

        /*one to one between teacher and class*/
        public int ClassTeacherId { get; set; }

        //[ForeignKey("ClassTeacherId")]
        //public Teacher? ClassTeacher { get; set; }

        ///*one to many between attendence and class record */
        //public ICollection<AttendanceStatus>? AttendanceStatuses { get; set; }
    }
}
