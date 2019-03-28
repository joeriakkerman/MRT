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
    public partial class Form3 : Form
    {

        private Form1 form;
        private String name;

        public Form3(Form1 form, String name)
        {
            this.form = form;
            this.name = name;
            InitializeComponent();
            setupDayBox();
        }

        private string getDate(int days)
        {
            DateTime dt = DateTime.Now.AddDays(-days);
            return dt.DayOfWeek + " " + dt.Day + "/" + dt.Month + "/" + dt.Year;
        }

        private void setupDayBox()
        {
            for(int i = 6; i >= 0; i--)
            {
                string date = getDate(i);
                day.Items.Add(date);
            }
            day.Text = day.Items[day.Items.Count -1].ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Parser parser = new Parser(form);
            if (qualityCombo.Text.Equals(""))
            {
                MessageBox.Show("Je bent vergeten de kwaliteit in te vullen!");
                return;
            }
            int quality = 1;
            string q = qualityCombo.Text.ToString();
            if (q.Equals(qualityCombo.Items[0])) quality = 0;
            else if (q.Equals(qualityCombo.Items[2])) quality = 2;
            string date = day.Text.ToString().Split(' ')[1];
            Console.WriteLine("date " + date);
            
            if(parser.containsResult(name, date))
            {
                MessageBox.Show("Er is al een resultaat ingevuld op deze datum voor deze persoon!");
            }else
            {
                parser.addResult(name, date, intimeCheckbox.Checked, quality);
                Close();
            }
        }
    }
}
