using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;

namespace MRT
{
    class Parser
    {
        private Form1 form;
        
        private String connectionString;

        public Parser(Form1 form)
        {
            this.form = form;
            String path = AppDomain.CurrentDomain.BaseDirectory + "Employees.mdf";
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";//|DataDirectory|\\Employees.mdf
        }

        public bool addEmployee(String name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO employees (name) VALUES (@name)", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@name", name);
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0) return true;
                    else return false;
                }
            }
            catch (SqlException e)
            {
                form.showMessageBox("Er ging iets mis bij het verbinden met de database...");
                Console.WriteLine(e.StackTrace + ", " + e.Message);
                return false;
            }
            
        }

        public bool removeEmployee(String name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM employees WHERE name = @name", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@name", name);
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0) return true;
                    else return false;
                }
            }
            catch (SqlException e)
            {
                form.showMessageBox("Er ging iets mis bij het verbinden met de database...");
                Console.WriteLine(e.StackTrace + ", " + e.Message);
                return false;
            }
        }

        public bool addResult(String name, String date, bool intime, int quality)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO results (name, date, intime, quality) VALUES (@name, @date, @intime, @quality)", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@intime", intime ? 1 : 0);
                    command.Parameters.AddWithValue("@quality", quality);
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0) return true;
                    else return false;
                }
            }
            catch (SqlException e)
            {
                form.showMessageBox("Er ging iets mis bij het verbinden met de database...");
                Console.WriteLine(e.StackTrace + ", " + e.Message);
                return false;
            }
        }

        public List<Result> getResults(String name)
        {
            List<Result> results = new List<Result>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT date, intime, quality FROM results WHERE name = @name", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            try
                            {
                                int intime = Int32.Parse(oReader["intime"].ToString());
                                int quality = Int32.Parse(oReader["quality"].ToString());
                                bool b = intime == 1 ? true : false;
                                results.Add(new Result(oReader["date"].ToString(), b, quality));
                            }
                            catch (FormatException e)
                            {
                                form.showMessageBox("Er ging iets mis bij het ophalen van de resultaten...");
                                Console.WriteLine("Format exception (Parser->getResults()) : " + e.Message + ", " + e.StackTrace);
                            }

                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                form.showMessageBox("Er ging iets mis bij het verbinden met de database...");
                Console.WriteLine(e.StackTrace + ", " + e.Message);
            }
            return results;
        }

        public bool containsResult(String name, String date)
        {
            List<Result> results = getResults(name);
            for(int i = 0; i < results.Count; i++)
            {
                if (results[i].date.Equals(date)) return true;
            }
            return false;
        }

        public List<String> getEmployees()
        {
            List<String> employees = new List<String>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM employees ORDER BY name ASC", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            employees.Add(oReader["name"].ToString());
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                form.showMessageBox("Er ging iets mis bij het verbinden met de database...");
                Console.WriteLine(e.StackTrace + ", " + e.Message);
            }
            
            return employees;
        }

        public class Result
        {
            public string date { get; set; }
            public bool intime { get; set; }
            public int quality { get; set; }

            public Result(string date, bool intime, int quality)
            {
                this.date = date;
                this.intime = intime;
                this.quality = quality;
            }
        }
    }
}
