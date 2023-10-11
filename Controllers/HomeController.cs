using Microsoft.AspNetCore.Mvc;
using nikopharm_task.Models;
using nikopharm_task.Services;
using System.Diagnostics;

namespace nikopharm_task.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeManagerService _employeeManagerService;
        public HomeController(IEmployeeManagerService employeeManagerService)
        {
            _employeeManagerService = employeeManagerService;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> employees = _employeeManagerService.GetAll().Result;
            return View(employees);
        }

        [HttpGet]
        public IActionResult NewEmployee()
        {
            EmployeeModel employee = new EmployeeModel();
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            EmployeeModel oldEmployee = await _employeeManagerService.GetById(Id);
            return View(oldEmployee);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _employeeManagerService.Delete(Id);
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult Search(string lastName, string department, string position)
        {
            var employees = _employeeManagerService.GetAll().Result;

            if (!string.IsNullOrEmpty(lastName))
            {
                employees = employees.Where(e => e.LastName.Contains(lastName)).ToList();
            }

            if (!string.IsNullOrEmpty(department))
            {
                employees = employees.Where(e => e.Department.Contains(department)).ToList();
            }

            if (!string.IsNullOrEmpty(position))
            {
                employees = employees.Where(e => e.Position.Contains(position)).ToList();
            }

            return View("Index", employees);
        }






        [HttpPost]
        public IActionResult Update(EmployeeModel newEmployee)
        {
            _employeeManagerService.Update(newEmployee);
            return RedirectToAction("Index", "Home");

        }


        [HttpPost]
        public IActionResult NewEmployee(EmployeeModel employee)
        {
            _employeeManagerService.Create(employee);
            return RedirectToAction("Index", "Home");

        }





    }
}