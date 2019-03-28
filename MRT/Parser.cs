using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;

namespace MRT
{
    class Parser
    {
        private string URL = "https://jumbobackup.000webhostapp.com/";
        private Form1 form;
        private List<Employee> employees = new List<Employee>();
        private String license = "";
        private static HttpClient client;

        public Parser(Form1 form)
        {
            this.form = form;
            //client = new HttpClient();
            deserialize();
        }

        private void addEmployee()
        {

        }

        private void removeEmployee()
        {

        }

        private void addResult(int empID)
        {

        }

        private int getIdFromName(String name)
        {
            return 0;
        }

        private void updateFromJsonToDB()
        {
            String path = "\"D:\\Joeri\\workspace\\visual studio\\MRT\\MRT\\MRT\\Employees.mdf\"";
            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";//|DataDirectory|\\Employees.mdf

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO results (emp_id, date, intime, quality) VALUES((SELECT id FROM employees WHERE name=@name), @date, @intime, @quality)", connection);
                    command.CommandType = System.Data.CommandType.Text;

                    connection.Open();
                    Console.WriteLine("Connection opened: " + employees.Count);

                    foreach (Employee e in employees)
                    {
                        foreach(Result r in e.results)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@name", e.name);
                            command.Parameters.AddWithValue("@date", r.date);
                            command.Parameters.AddWithValue("@intime", r.intime);
                            command.Parameters.AddWithValue("@quality", r.quality);
                            int result = command.ExecuteNonQuery();
                            Console.WriteLine("Amount of rows affected: " + result + ", tried to add result for: " + e.name + ", date: " + r.date);
                        }
                    }

                    command = new SqlCommand("SELECT * FROM employees", connection);

                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Console.WriteLine("id: " + oReader["id"].ToString() + ", name: " + oReader["name"].ToString());
                        }
                    }

                    connection.Close();
                    Console.WriteLine("Connection closed");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace + ", " + e.Message);
            }
        }

        public Boolean makeBackup()
        {
            try
            {
                string homePath = AppDomain.CurrentDomain.BaseDirectory;
                string path = homePath + "results.json";
                if (File.Exists(path))
                {
                    string text = System.IO.File.ReadAllText(path);
                    var data = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("license", license),
                        new KeyValuePair<string, string>("json", text),
                        new KeyValuePair<string, string>("date", DateTime.Today.ToString("dd/MM/yyyy"))
                    });
                    var response = client.PostAsync(URL + "makebackup.php", data).Result;
                    string content = response.Content.ReadAsStringAsync().Result;
                    Response result = JsonConvert.DeserializeObject<Response>(content);
                    if (result.result == 2 || result.result == 3) return true;
                    else return false;
                }
                else return true;
            }
            catch (HttpRequestException)
            {
                form.showMessageBox("Kon geen backup maken door het ontbreken van een internet verbinding");
                return false;
            }
        }

        public Boolean addLicense(String license)
        {
            try
            {
                var data = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("license", license),
                    new KeyValuePair<string, string>("version", form.mrtVersion)
                });
                var response = client.PostAsync(URL + "addlicense.php", data).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                Response result = JsonConvert.DeserializeObject<Response>(content);
                if (result.result == 1) return true;
                else if(result.result == 2)
                {
                    form.showMessageBox("Deze licentiecode is niet bruikbaar");
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                form.showMessageBox("Kon licentie niet activeren door het ontbreken van een internet verbinding");
                return false;
            }
            form.showMessageBox("Er ging iets mis bij het activeren van de licentie");
            return false;
        }

        public CheckActivationResult checkActivation(String license)
        {
            try
            {
                var data = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("license", license)
                });
                var response = client.PostAsync(URL + "checkactivation.php", data).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                CheckActivationResult result = JsonConvert.DeserializeObject<CheckActivationResult>(content);
                return result;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public CheckVersionResult checkVersion()
        {
            try
            {
                var data = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("version", form.mrtVersion)
                });
                var response = client.PostAsync(URL + "checkversion.php", data).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                CheckVersionResult result = JsonConvert.DeserializeObject<CheckVersionResult>(content);
                return result;
            }
            catch (HttpRequestException)
            {
                form.showMessageBox("Je hebt een internetverbinding nodig om dit programma te kunnen gebruiken");
                return null;
            }
        }

        private String encrypt(String input)
        {
            String output = "";
            char[] arr = input.ToCharArray();
            char[] key = "ENCODEKEY".ToCharArray();
            for (int i = 0; i < arr.Length; i++)
                output += (char)(arr[i] + key[i % key.Length]);
            return output;
        }

        private String decrypt(String input)
        {
            String output = "";
            char[] arr = input.ToCharArray();
            char[] key = "ENCODEKEY".ToCharArray();
            for (int i = 0; i < arr.Length; i++)
                output += (char)(arr[i] - key[i % key.Length]);
            return output;
        }

        public void setLicense(String license)
        {
            deserialize();
            this.license = license;
            serialize();
        }

        public String getLicense()
        {
            deserialize();
            return license;
        }

        private bool deserialize()
        {
            string homePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = homePath + "results.json";
            if (File.Exists(path))
            {
                string text = System.IO.File.ReadAllText(path);
                text = decrypt(text);
                List list = JsonConvert.DeserializeObject<List>(text);
                employees = list.employees;
                license = list.license;
                return true;
            }
            return false;
        }

        public void serialize()
        {
            string homePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = homePath + "results.json";
            List list = new List();
            list.employees = employees;
            list.license = license;
            string json = JsonConvert.SerializeObject(list);
            json = encrypt(json);
            System.IO.File.WriteAllText(path, json);
        }

        public Employee getEmployeeByName(String name)
        {
            deserialize();
            for (int i = 0; i < employees.Count; i++)
                if (employees[i].name.Equals(name)) return employees[i];
            return null;
        }

        public List<Employee> getEmployees()
        {
            deserialize();
            return employees;
        }

        public void removeEmployee(String name)
        {
            deserialize();
            for (int i = 0; i < employees.Count; i++)
                if (employees[i].name.Equals(name)) employees.RemoveAt(i);
            serialize();
        }

        public class CheckVersionResult
        {
            public int result { get; set; }
            public int allowed { get; set; }
        }

        public class CheckActivationResult
        {
            public int result { get; set; }
            public int sameIP { get; set; }
            public int activated { get; set; }
        }

        public class Response
        {
            public int result { get; set; }
        }

        public class List
        {
            public String license { get; set; }
            public String version { get; set; }
            public List<Employee> employees { get; set; }
        }

        public class Employee
        {
            public string name { get; set; }
            public List<Result> results { get; set; }
        }

        public class Result
        {
            public string date { get; set; }
            public bool intime { get; set; }
            public int quality { get; set; }
        }
    }
}
