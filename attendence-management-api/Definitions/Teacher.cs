using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementData.Definitions
{
    [Table("Teacher", Schema = "dbo")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength =3)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(25)]
        public string State { get; set; }

        [Precision(9, 2)]
        public decimal Salary { get; set; }

        [Column(Order =100)]
        public byte[] Profile { get; set; }

    }
}
