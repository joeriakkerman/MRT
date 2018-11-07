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
    public partial class Form4 : Form
    {
        private Parser parser;
        private Form1 form;
        private bool done = false;

        public Form4(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            parser = new Parser(form);
        }
        
        private void add_Click(object sender, EventArgs e)
        {
            addLicense();
        }
        
        public void addLicense()
        {
            String license = textBox1.Text.ToString();
            Boolean b = parser.addLicense(license);
            if (!b) return;
            parser.setLicense(license);
            done = true;
            Close();
        }

        public void showMessageBox(String msg)
        {
            MessageBox.Show(msg);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (done)
            {
                form.Enabled = true;
                return;
            }
            System.Windows.Forms.Application.Exit();
        }
    }
}
