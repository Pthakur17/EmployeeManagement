using EmployeeManagement.DbEntities;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeDetails()
        {
            EmployeeModel employee = await this.service.GetDetails().ConfigureAwait(false);
            return this.View("EmployeeDetails", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployeeDetails(EmployeeModel employee)
        {
            if (!ModelState.IsValid)
            {
                return this.View("EmployeeDetails", employee);
            }
            await this.service.AddUpdateEmployeeDetails(employee).ConfigureAwait(false);
            TempData["Message"] = "Employee Details Succesfully Saved.";
            return this.RedirectToAction("EmployeeDetails");
        }

        [HttpGet]
        public async Task<IActionResult> ManageEmployeeDetails()
        {
            List<EmployeeModel> employee = await this.service.GetAllEmployeeList().ConfigureAwait(false);
            return this.View("ManageEmployeeDetails", employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            EmployeeModel employee = await this.service.GetEmployeeById(id).ConfigureAwait(false);
            return this.View("EmployeeDetails", employee);
        }
    }
}
