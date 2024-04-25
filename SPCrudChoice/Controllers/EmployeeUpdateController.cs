using Microsoft.AspNetCore.Mvc;
using SPCrudChoice.Models;

namespace SPCrudChoice.Controllers
{
    public class EmployeeUpdateController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUpdateController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);

                return RedirectToAction("UPDATE", "EmployeeUpdate");
            }
            return View(employee);
        }
    }
}
