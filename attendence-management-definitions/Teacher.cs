using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementDefinitions
{
    [Table("Teacher", Schema = "dbo")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public required string LastName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(25)]
        public string? City { get; set; }

        [StringLength(25)]
        public string? State { get; set; }

        [StringLength(25)]
        public required string Subject { get; set; }

        [Precision(9, 2)]
        public decimal Salary { get; set; }

        [StringLength(10)]
        public string? MobileNumber { get; set; }

        [JsonIgnore]
        public byte[]? Profile { get; set; }

        public ICollection<TeacherClassSubject>? TeacherClassSubjects { get; set; }

        ///*one to one between teacher and class, class that the teacher is responsble for*/
        //public ClassInfo? ClassInfo { get; set; }

    }
}
