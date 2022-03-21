using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inputReducer
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://instagram.com/hereioz");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/w9qHFVVKSP");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/bOeNiX0");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/hereioz");
        }
    }
}
