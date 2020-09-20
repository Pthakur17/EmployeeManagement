using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DbEntities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        [Column("DOB", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Column("JoiningDate", TypeName = "date")]
        public DateTime JoiningDate { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(1000)]
        public string Address { get; set; }
        [StringLength(5000)]
        public string About { get; set; }
        public int RoleId { get; set; }
        public string SkillsName { get; set; }
        public int HobbyId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(HobbyId))]
        public virtual Hobbies Hobbies { get; set; }
    }
}
