using Microsoft.AspNetCore.Mvc;
using SPCrudChoice.Models;

namespace SPCrudChoice.Controllers
{
    public class EmployeeCreateController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeCreateController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                //Map View Model to Employee entity
                Employee employee = new Employee
                {
                    EmployeeName = model.EmployeeName,
                    Designation = model.Designation,
                    Salary = model.Salary
                };

                //Call repository method to add Employee
                _employeeRepository.AddEmployee(employee);

                //Redirect to Action after successful creation
                return RedirectToAction("CREATE", "EmployeeCreate");
            }
            return View(model);
        }
    }
}
