using ConsoleAppADO.NET.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppADO.NET.Controller
{
    internal class EmployeeController
    {
        string connectionString = "Data Source=VuHoangNam;Initial Catalog=T2301E_SEM3;User ID=sa;Password=1234567890;Encrypt=False";

        public void GetAllEmp()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT EmpId, FirstName, LastName, Email FROM Employees";

                SqlDataReader data = sqlCommand.ExecuteReader();

                while (data.Read())
                {
                    Employee emp = new Employee
                    {
                        EmpId = Convert.ToInt32(data[0]),
                        FirstName = data[1].ToString(),
                        LastName = data[2].ToString(),
                        Email = data[3].ToString()
                    };

                    emp.Display();

                }

                data.Close();
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Employee FindById(int id)
        {
            Employee emp = null;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "proGetAllEmp";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@empId", id);

                SqlDataReader data = sqlCommand.ExecuteReader();

                if (data.Read())
                {
                    emp = new Employee
                    {
                        EmpId = Convert.ToInt32(data[0]),
                        FirstName = data[1].ToString(),
                        LastName = data[2].ToString(),
                        Email = data[3].ToString()
                    };
                }

                data.Close();
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return emp;
        }

        public bool CreateNewEmp(Employee emp)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Employees VALUES(@fname, @lname, @email)";

                sqlCommand.Parameters.AddWithValue("@fname", emp.FirstName);
                sqlCommand.Parameters.AddWithValue("@lname", emp.LastName);
                sqlCommand.Parameters.AddWithValue("@email", emp.Email);

                int result = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return (result > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool UpdateEmp(Employee emp)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Employees SET FirstName = @fname, LastName = @lname, Email = @email WHERE EmpId = @empId";

                sqlCommand.Parameters.AddWithValue("@empId", emp.EmpId);
                sqlCommand.Parameters.AddWithValue("@fname", emp.FirstName);
                sqlCommand.Parameters.AddWithValue("@lname", emp.LastName);
                sqlCommand.Parameters.AddWithValue("@email", emp.Email);

                int result = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return (result > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool DeleteEmp(int empId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Employees WHERE EmpId = @empId";

                sqlCommand.Parameters.AddWithValue("@empId", empId);

                int result = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return (result > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

    }
}
