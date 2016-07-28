using DataGenerationFramework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGenerationFramework.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gen = new Generators();
            Random r = new Random();

            if (r.Next(0, 2) == 0)
            {
                textBox2.Text = "Male";
                textBox1.Text = gen.GetName(Gender.Male);
            }
            else
            {
                textBox2.Text = "Female";
                textBox1.Text = gen.GetName(Gender.Female);
            }

            textBox3.Text = gen.GetAddress();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
