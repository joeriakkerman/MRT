using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MRT
{
    public partial class Form1 : Form
    {

        private Parser parser;
        private int week, currentWeek;
        private String addedName = "";
        private int year, currentYear;

        public Form1()
        {
            InitializeComponent();
            parser = new Parser(this);
            init();
        }

        private void init()
        {
            setEmployeesList();
            loadCurrentWeek();
            intimeCircle.Value = 0;
            qualityCircle.Value = 0;
            clearChart();
        }

        public void setAddedEmployee(String name)
        {
            addedName = name;
        }

        private void loadCurrentWeek()
        {
            DateTime time = DateTime.Now;
            changeYear(time.Date.Year);
            currentYear = time.Date.Year;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            currentWeek = week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            weekNumber.Text = "Week " + week;
        }

        private DateTime firstDateOfWeek(int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        private void setupChart()
        {
            clearChart();
            string[] daysInWeek = new string[] { "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag" };
            List<Parser.Result> results = parser.getResults(employeesList.Text.ToString());
            if (results == null) return;
            DateTime dtt = firstDateOfWeek(week);
            for (int i = 0; i < 7; i++)
            {
                DateTime dt = dtt.AddDays(i);
                string s = dt.Date.Day + "/" + dt.Date.Month + "/" + dt.Date.Year;
                for (int j = 0; j < results.Count; j++)
                {
                    if (results[j].date.Equals(s))
                    {
                        
                        if (results[j].intime) chart1.Series["Op tijd klaar"].Points[i].SetValueY(100);
                        else chart1.Series["Op tijd klaar"].Points[i].SetValueY(1);
                        int ii = results[j].quality * 50;
                        if (ii <= 0) ii = 1;
                        chart1.Series["Kwaliteit"].Points[i].SetValueY(ii);
                        continue;
                    }
                }
            }
            chart1.ChartAreas[0].AxisY.Maximum = 100;
        }

        private void changeYear(int year)
        {
            this.year = year;
            lblYear.Text = "" + year;
        }

        private void setEmployeesList()
        {
            employeesList.Items.Clear();
            List<String> employees = parser.getEmployees();
            employeesList.Items.AddRange(employees.ToArray());
        }

        private Boolean isInside(string d)
        {
            string[] date = d.Split('/');
            DateTime dt = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;
            if (dt >= from && dt <= to) return true;
            else return false;
        }

        private void loadAverages()
        {
            float intime = 0;
            float quality = 0;
            int count = 0;
            List<Parser.Result> results = parser.getResults(employeesList.Text.ToString());

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (isInside(results[i].date))
                    {
                        if (results[i].intime) intime++;
                        quality += results[i].quality;
                        count++;
                    }
                }
                if (count == 0) return;
                intime *= 100;
                intime /= count;
                quality *= 50;
                quality /= count;
                intimeCircle.Value = (int)intime;
                intimeCircle.Update();
                intimeCircle.Text = "" + (int)intime;
                qualityCircle.Value = (int)quality;
                qualityCircle.Update();
                qualityCircle.Text = "" + (int)quality;
            }
            else
            {
                intimeCircle.Value = 0;
                intimeCircle.Update();
                intimeCircle.Text = "0";
                qualityCircle.Value = 0;
                qualityCircle.Update();
                qualityCircle.Text = "0";
            }
        }

        public void showMessageBox(String msg)
        {
            MessageBox.Show(msg);
        }

        private void setDatePickers()
        {
            List<Parser.Result> results = parser.getResults(employeesList.Text.ToString());
            if (results == null || results.Count <= 0)
            {
                dateFrom.Enabled = false;
                dateTo.Enabled = false;
                return;
            }
            dateFrom.Enabled = true;
            dateTo.Enabled = true;
            int id = 0;
            for(int i = 0; i < results.Count; i++)
            {
                string[] date = results[i].date.Split('/');
                string[] fdate = results[id].date.Split('/');
                if (int.Parse(fdate[2]) < int.Parse(date[2])) continue;
                else if (int.Parse(fdate[2]) > int.Parse(date[2])) id = i;
                else if (int.Parse(fdate[1]) < int.Parse(date[1])) continue;
                else if (int.Parse(fdate[1]) > int.Parse(date[1])) id = i;
                else if (int.Parse(fdate[0]) < int.Parse(date[0])) continue;
                else if (int.Parse(fdate[0]) > int.Parse(date[0])) id = i;
            }
            Console.WriteLine("emp.results[id].date " + results[id].date);
            string[] parts = results[id].date.Split('/');
            DateTime firstDay = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));
            dateFrom.CustomFormat = "dd/MM/yyyy";
            dateFrom.Format = DateTimePickerFormat.Custom;
            dateTo.CustomFormat = "dd/MM/yyyy";
            dateTo.Format = DateTimePickerFormat.Custom;
            dateFrom.MinDate = firstDay;
            dateFrom.MaxDate = DateTime.Today;
            dateTo.MinDate = firstDay;
            dateTo.MaxDate = DateTime.Today;
            dateFrom.Value = firstDay;
            dateTo.Value = DateTime.Today;
        }

        private void add_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.ShowDialog();
            employeesList_SelectionChangeCommitted(sender, e);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            string name = employeesList.Text.ToString();
            if (!addedName.Equals("")) name = addedName;
            addedName = "";
            setEmployeesList();
            if (employeesList.Items.Contains(name)) employeesList.Text = name;
        }

        private void addResult_Click(object sender, EventArgs e)
        {
            if (!employeesList.Text.ToString().Equals(""))
                new Form3(this, employeesList.Text.ToString()).ShowDialog();
            employeesList_SelectionChangeCommitted(sender, e);
        }

        private void left_Click(object sender, EventArgs e)
        {
            week--;
            if (week < 1)
            {
                changeYear(year-1);
                week = 52;
            }
            weekNumber.Text = "Week " + week;
            setupChart();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTo.MinDate = dateFrom.Value;
            loadAverages();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            loadAverages();
        }

        private void clearChart()
        {
            chart1.Series["Op tijd klaar"].Points.Clear();
            chart1.Series["Kwaliteit"].Points.Clear();
            DateTime dt = firstDateOfWeek(week);
            string[] daysInWeek = new string[] { "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag" };
            for (int i = 0; i < daysInWeek.Length; i++)
            {
                DateTime dtt = dt.AddDays(i);
                chart1.Series["Op tijd klaar"].Points.AddXY(daysInWeek[i] + " " + dtt.ToString("dd/MM"), 0);
                chart1.Series["Kwaliteit"].Points.AddXY(daysInWeek[i] + " " + dtt.ToString("dd/MM"), 0);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet je zeker dat je deze medewerker wilt verwijderen?", "Medewerker verwijderen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                parser.removeEmployee(employeesList.Text.ToString());
                Form1_Activated(sender, e);
                intimeCircle.Value = 0;
                qualityCircle.Value = 0;
                intimeCircle.Text = "0";
                qualityCircle.Text = "0";
                dateFrom.Enabled = false;
                dateTo.Enabled = false;
                delete.Enabled = false;
                addResult.Enabled = false;
                clearChart();
            }
        }

        private void employeesList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            intimeCircle.Value = 0;
            qualityCircle.Value = 0;
            intimeCircle.Text = "0";
            qualityCircle.Text = "0";
            clearChart();

            setDatePickers();
            loadCurrentWeek();
            setupChart();
            loadAverages();
            addResult.Enabled = true;
            delete.Enabled = true;
        }

        private void right_Click(object sender, EventArgs e)
        {
            week++;
            if (week > currentWeek && year == currentYear) week = currentWeek;
            else if(week > 52 && year < currentYear)
            {
                week = 1;
                changeYear(year+1);
            }
            weekNumber.Text = "Week " + week;
            setupChart();
        }
    }
}
