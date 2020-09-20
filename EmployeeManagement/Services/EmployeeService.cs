using EmployeeManagement.DbEntities;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeService(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<EmployeeModel> GetDetails()
        {
            EmployeeModel employee = new EmployeeModel();
            try
            {
                employee.RoleDetails = await this.dbContext.Role.ToListAsync().ConfigureAwait(false);
                employee.SkillDetails = (from skill in this.dbContext.Skills
                                         select new SkillsModel { Id = skill.Id, SkillsName = skill.SkillsName }).ToList();
                employee.HobbyDetails = (from hob in this.dbContext.Hobbies
                                         select new SelectListItem { Value = hob.Id.ToString(), Text = hob.HobbyName }).ToList();
            }
            catch
            {
                throw;
            }
            return employee;
        }
        public async Task AddUpdateEmployeeDetails(EmployeeModel employeeModel)
        {
            EmployeeModel employees = new EmployeeModel();
            try
            {
                if (employeeModel != null)
                {
                    var skillsName = GetCheckBoxListSelections(employeeModel.SkillDetails);

                    if (employeeModel.EmployeeId == 0)
                    {
                        Employee employee = new Employee()
                        {
                            Firstname = employeeModel.Firstname,
                            Lastname = employeeModel.Lastname,
                            Dob = employeeModel.Dob ?? DateTime.MinValue,
                            JoiningDate = employeeModel.JoiningDate ?? DateTime.MinValue,
                            Address = employeeModel.Address,
                            Gender = employeeModel.Gender,
                            RoleId = employeeModel.SelectedRoleId,
                            SkillsName = skillsName,
                            HobbyId = employeeModel.SelectedHobbyId,
                            About = employeeModel.About,
                        };

                        this.dbContext.Employees.Add(employee);
                        await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        Employee employee = this.dbContext.Employees.FirstOrDefault(x => x.Id == employeeModel.EmployeeId);

                        employee.Firstname = employeeModel.Firstname;
                        employee.Lastname = employeeModel.Lastname;
                        employee.Dob = employeeModel.Dob ?? DateTime.MinValue;
                        employee.JoiningDate = employeeModel.JoiningDate ?? DateTime.MinValue;
                        employee.Address = employeeModel.Address;
                        employee.Gender = employeeModel.Gender;
                        employee.RoleId = employeeModel.SelectedRoleId;
                        employee.SkillsName = skillsName;
                        employee.HobbyId = employeeModel.SelectedHobbyId;
                        employee.About = employeeModel.About;

                        this.dbContext.Employees.Update(employee);
                        await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private string GetCheckBoxListSelections(List<SkillsModel> skillsModel)
        {
            List<string> items = new List<string>();
            foreach (SkillsModel i in skillsModel)
            {
                if (i.Selected)
                {
                    items.Add(i.SkillsName);
                }
            }
            var skillsname = String.Join(", ", items.ToList());
            return skillsname;
        }

        public async Task<List<EmployeeModel>> GetAllEmployeeList()
        {
            List<EmployeeModel> employeelist = new List<EmployeeModel>();
            try
            {
                employeelist = (from emp in this.dbContext.Employees
                                select new EmployeeModel
                                {
                                    EmployeeId = emp.Id,
                                    Firstname = emp.Firstname,
                                    Lastname = emp.Lastname,
                                    Dob = emp.Dob,
                                    JoiningDate = emp.JoiningDate,
                                    Gender = emp.Gender,
                                    SelectedRole = emp.Role.RoleName,
                                    SelectedSkills = emp.SkillsName
                                }).ToList(); 
            }
            catch
            {
                throw;
            }
            return employeelist;
        }

        public async Task<EmployeeModel> GetEmployeeById( int id)
        {
            EmployeeModel employee = (from emp in this.dbContext.Employees.Where(x => x.Id == id)
                                      select new EmployeeModel
                                      {
                                          EmployeeId = emp.Id,
                                          Firstname = emp.Firstname,
                                          Lastname = emp.Lastname,
                                          Dob = emp.Dob,
                                          Address = emp.Address,
                                          About = emp.About,
                                          JoiningDate = emp.JoiningDate,
                                          Gender = emp.Gender,
                                          SelectedHobbyId = emp.HobbyId,
                                          SelectedRoleId = emp.RoleId,
                                          SelectedSkills = emp.SkillsName
                                      }).FirstOrDefault();

            employee.RoleDetails = await this.dbContext.Role.ToListAsync().ConfigureAwait(false);
            employee.SkillDetails = (from skill in this.dbContext.Skills
                                     select new SkillsModel { Id = skill.Id, SkillsName = skill.SkillsName }).ToList();
            employee.HobbyDetails = (from hob in this.dbContext.Hobbies
                                     select new SelectListItem { Value = hob.Id.ToString(), Text = hob.HobbyName }).ToList();

            return employee;
        }
    }
}
