﻿using DataGenerationFramework.Core;
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
            var gen = new RepositoryGenerators();
            Random r = new Random();

            if (r.Next(0, 2) == 0)
            {
                textBox2.Text = "Male";
                textBox1.Text = gen.GetHumanData_Name(Gender.Male);
            }
            else
            {
                textBox2.Text = "Female";
                textBox1.Text = gen.GetHumanData_Name(Gender.Female);
            }

            textBox3.Text = gen.GetGEOData_ChineseAddress();
            textBox4.Text = gen.GetHumanData_EmailAddress();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
