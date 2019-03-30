using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;

namespace MRT
{
    class Parser
    {
        private Form1 form;

        private String fileName;

        private SQLiteConnection connection;

        public Parser(Form1 form)
        {
            this.form = form;

            fileName = "Employees.sqlite";

            setup();
            createSchema();
        }

        private void setup()
        {
            if (!File.Exists(fileName)) SQLiteConnection.CreateFile(fileName);
            connection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;Foreign Keys=True;");
        }

        private void createSchema()
        {
            connection.Open();

            string tbl_emp = "CREATE TABLE IF NOT EXISTS employees (name VARCHAR(50) PRIMARY KEY);";
            string tbl_res = "CREATE TABLE IF NOT EXISTS results (name VARCHAR(50), date VARCHAR(10), intime TINYINT NOT NULL, quality INT NOT NULL, PRIMARY KEY (name, date), FOREIGN KEY (name) REFERENCES employees(name) ON DELETE CASCADE);";

            SQLiteCommand command = new SQLiteCommand(tbl_emp, connection);
            int result = command.ExecuteNonQuery();
            if (result > 0) Console.WriteLine("Succesfully created employees table");
            else Console.WriteLine("Something went wrong trying to create the employees table");

            command = new SQLiteCommand(tbl_res, connection);
            result = command.ExecuteNonQuery();
            if (result > 0) Console.WriteLine("Succesfully created results table");
            else Console.WriteLine("Something went wrong trying to create the results table");

            connection.Close();
        }

        public bool addEmployee(String name)
        {
            try
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand("INSERT INTO employees (name) VALUES (@name)", connection);
                command.Parameters.AddWithValue("@name", name);
                int result = command.ExecuteNonQuery();

                connection.Close();

                if (result > 0) return true;
                else return false;
            }
            catch (SQLiteException e)
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
                connection.Open();

                SQLiteCommand command = new SQLiteCommand("DELETE FROM employees WHERE name = @name", connection);
                command.Parameters.AddWithValue("@name", name);
                int result = command.ExecuteNonQuery();

                connection.Close();

                if (result > 0) return true;
                else return false;
            }
            catch (SQLiteException e)
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
                connection.Open();

                SQLiteCommand command = new SQLiteCommand("INSERT INTO results (name, date, intime, quality) VALUES (@name, @date, @intime, @quality)", connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@intime", intime ? 1 : 0);
                command.Parameters.AddWithValue("@quality", quality);
                int result = command.ExecuteNonQuery();

                connection.Close();

                if (result > 0) return true;
                else return false;
            }
            catch (SQLiteException e)
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
                connection.Open();

                SQLiteCommand command = new SQLiteCommand("SELECT date, intime, quality FROM results WHERE name = @name", connection);
                command.Parameters.AddWithValue("@name", name);

                using (SQLiteDataReader oReader = command.ExecuteReader())
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
            catch (SQLiteException e)
            {
                form.showMessageBox("Er ging iets mis bij het verbinden met de database...");
                Console.WriteLine(e.StackTrace + ", " + e.Message);
            }
            return results;
        }

        public bool containsResult(String name, String date)
        {
            List<Result> results = getResults(name);
            for (int i = 0; i < results.Count; i++)
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
                connection.Open();

                SQLiteCommand command = new SQLiteCommand("SELECT * FROM employees ORDER BY name ASC", connection);
                using (SQLiteDataReader oReader = command.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        employees.Add(oReader["name"].ToString());
                    }
                }

                connection.Close();
            }
            catch (SQLiteException e)
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
