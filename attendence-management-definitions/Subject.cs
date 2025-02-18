
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendenceManagementDefinitions
{
    [Table("Subject", Schema = "dbo")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TeacherClassSubject>? TeacherClassSubjects { get; set; }
    }
}
