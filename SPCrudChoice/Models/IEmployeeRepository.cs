using System.Net.Http.Headers;

namespace SPCrudChoice.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int EmployeeID);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int EmployeeID);
    }
}
