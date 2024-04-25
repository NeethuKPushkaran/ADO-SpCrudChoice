using System.Data.SqlClient;
using System.Data;

namespace SPCrudChoice.Models
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly string _connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public Employee GetEmployee(int EmployeeID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("spEmployeeCRUD", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    command.Parameters.AddWithValue("@Action", "READ");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                EmployeeID = (int)reader["EmployeeID"],
                                EmployeeName = reader["EmployeeName"].ToString(),
                                Designation = reader["Designation"].ToString(),
                                Salary = (int)reader["Salary"]
                            };
                            return employee;
                        }
                    }
                }
            }
            return null; // Return null if product is not found
        }
        public void AddPEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spEmployeeCRUD", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Designation", employee.Designation);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@Action", "CREATE");

                    command.ExecuteNonQuery();
                }
            }

        }
        public void UpdateEmployee(Employee employee)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spEmployeeCRUD", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Designation", employee.Designation);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@Action", "UPDATE");

                    command.ExecuteNonQuery ();
                }
            }
        }
        public void DeleteEmployee(int EmployeeID)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand ("spEmployeeCRUD", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    command.Parameters.AddWithValue("@Action", "DELETE");

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
