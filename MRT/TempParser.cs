using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;

namespace MRT
{
    class TempParser
    {

        private Form1 form;

        public TempParser(Form1 form)
        {
            this.form = form;
            string json = readInput();
            Console.WriteLine("json: " + json);
            List list = JsonConvert.DeserializeObject<List>(json);
            addToDatabase(list);
        }

        private void loadNewList(List<String> newEmployees)
        {
            Parser parser = new Parser(form);
            List<String> employees = parser.getEmployees();
            List<Employee> finalList = new List<Employee>();

            foreach(String s in newEmployees)
            {
                Employee e = new Employee();
                e.name = s;
                e.results = new List<Result>();
                if (employees.Contains(s))
                {
                    List<Parser.Result> results = parser.getResults(s);
                    foreach(Parser.Result r in results)
                    {
                        Result res = new Result();
                        res.date = r.date;
                        res.intime = r.intime;
                        res.quality = r.quality;
                        e.results.Add(res);
                    }
                }
                finalList.Add(e);
                employees.Remove(s);
            }

            foreach(String s in employees)
            {
                parser.removeEmployee(s);
            }
        }

        private void addToDatabase(List list)
        {
            Parser parser = new Parser(form);
            foreach(Employee e in list.employees)
            {

                if (parser.addEmployee(e.name)) Console.WriteLine("Succesfully added " + e.name);
                else Console.WriteLine("Could not add employee " + e.name);
                foreach(Result r in e.results)
                {
                    if (parser.addResult(e.name, r.date, r.intime, r.quality)) Console.WriteLine("Succesfully added result " + e.name + ", " + r.date);
                    else Console.WriteLine("Could not add result " + e.name + ", " + r.date);
                }
            }
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

        private string readInput()
        {
            return decrypt(File.ReadAllText(@"C:\Users\Joeri\Desktop\results.json"));
        }

        public class List
        {
            public string license { get; set; }
            public string version { get; set; }
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
