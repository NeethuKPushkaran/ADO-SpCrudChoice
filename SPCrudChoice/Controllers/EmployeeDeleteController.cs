using Microsoft.AspNetCore.Mvc;
using SPCrudChoice.Models;

namespace SPCrudChoice.Controllers
{
    public class EmployeeDeleteController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeDeleteController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("DELETE", "EmployeeDelete");
        }
    }
}
