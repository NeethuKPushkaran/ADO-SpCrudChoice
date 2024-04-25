using Microsoft.AspNetCore.Mvc;
using SPCrudChoice.Models;

namespace SPCrudChoice.Controllers
{
    public class EmployeeReadController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeReadController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
