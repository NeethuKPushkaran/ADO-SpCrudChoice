namespace SPCrudChoice.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployeeID { get; internal set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
}
