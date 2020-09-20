using EmployeeManagement.DbEntities;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        public Task<EmployeeModel> GetDetails();
        public Task AddUpdateEmployeeDetails(EmployeeModel employee);
        public Task<List<EmployeeModel>> GetAllEmployeeList();

        public Task<EmployeeModel> GetEmployeeById(int id);
    }
}
