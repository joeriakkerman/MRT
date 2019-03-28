using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRT
{
    public partial class Form2 : Form
    {
        private Form1 form;

        public Form2(Form1 form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void addEmployeesFromList()
        {
            String[] content = System.IO.File.ReadAllText(@"C:\Users\Joeri\Desktop\names.txt").Split('\n');
            for (int i = 0; i < content.Length; i++)
            {
                Parser parser = new Parser(form);
                Parser.Employee emp = new Parser.Employee();
                emp.name = content[i];
                emp.results = new List<Parser.Result>();
                parser.getEmployees().Add(emp);
                parser.serialize();
            }
            Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //addEmployeesFromList();
            Parser parser = new Parser(form);
            if (parser.getEmployees().Count < 1)
            {
                Parser.Employee emp = new Parser.Employee();
                emp.name = name.Text.ToString();
                emp.results = new List<Parser.Result>();
                parser.getEmployees().Add(emp);
                parser.serialize();
                Close();
                form.setAddedEmployee(emp.name);
            }
            else MessageBox.Show("Je kunt maximaal 1 medewerker toevoegen in de DEMO versie");
        }
    }
}
