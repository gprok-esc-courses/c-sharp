using System;
using System.Data.SqlClient;

namespace db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\code\c-sharp-course\db\db\Company.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                Console.WriteLine("Connected to db");

                // Read all Employees
                string sql = "SELECT * FROM Employee";
                // Console.Write("Query: ");
                // sql = Console.ReadLine();
                SqlCommand readEmployees = new SqlCommand(sql, connection);
                SqlDataReader reader = readEmployees.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine("{0}: {1}, salary {2}",
                        reader[0], reader["Name"], reader.GetDecimal(2));
                }
                reader.Close();

                // Add a new Employee
                Console.Write("Give a name: ");
                string name = Console.ReadLine();

                // Prepared statement
                sql = "INSERT INTO Employee (Name, Salary) VALUES (@param1, 600.0)";
                SqlCommand insertEmployee = new SqlCommand(sql, connection);
                insertEmployee.Parameters.AddWithValue("@param1", name);
                insertEmployee.ExecuteNonQuery();

                // Update salary
                Console.Write("Give ID: ");
                string id = Console.ReadLine();
                sql = "UPDATE Employee SET Salary=1000.0 WHERE id=@param1";
                SqlCommand updateEmployee = new SqlCommand(sql, connection);
                updateEmployee.Parameters.AddWithValue("@param1", id);
                updateEmployee.ExecuteNonQuery();
            }
        }
    }
}
