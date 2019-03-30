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
                if (!parser.addEmployee(content[i]))
                {
                    MessageBox.Show("Er ging iets mis bij het toevoegen van een medewerker...");
                }
            }
            Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //addEmployeesFromList();
            Parser parser = new Parser(form);
            if (parser.getEmployees().Count < 1)
            {
                if (!parser.addEmployee(name.Text.ToString()))
                {
                    MessageBox.Show("Er ging iets mis bij het toevoegen van een medewerker...");
                }
                else
                {
                    form.setAddedEmployee(name.Text.ToString());
                }
            }
            else MessageBox.Show("Bij de demo versie kan je maximaal één medewerker toevoegen...");
            Close();
        }
    }
}
