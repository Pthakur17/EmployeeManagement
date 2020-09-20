using EmployeeManagement.DbEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name = "Date of Birth")]
        public DateTime? Dob { get; set; }

        [Required(ErrorMessage = "Joining Date is required.")]
        [Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "About is required.")]
        public string About { get; set; }

        [Display(Name = "Role : ")]
        public List<Role> RoleDetails { get; set; }

        [Display(Name = "Skills : ")]   
        [SkillValidation(ErrorMessage = "Select at least 1 Skill.")]
        public List<SkillsModel> SkillDetails { get; set; }

        [Display(Name = "Hobbies : ")]
        public List<SelectListItem> HobbyDetails { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public int SelectedRoleId { get; set; }

        [Required(ErrorMessage = "Hobby is required.")]
        public int SelectedHobbyId {get; set;}
        public string SelectedSkills { get; set; }
        public string SelectedRole { get; set; }
    }
}
