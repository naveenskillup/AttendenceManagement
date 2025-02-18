using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendenceManagementDefinitions
{
    [Table("AttendanceStatus", Schema = "dbo")]
    public class AttendanceStatus
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
    }
}
