using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementDefinitions
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(25)]
        public string? City { get; set; }

        [StringLength(25)]
        public string? State { get; set; }

        public int Class { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string? FatherName { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string? FatherMobileNumber { get; set; }

        [JsonIgnore]
        public byte[]? Profile { get; set; }
    }
}
