using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inputReducer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                ProcessStartInfo info = new ProcessStartInfo(Process.GetCurrentProcess().ProcessName.ToString() + ".exe");
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info);
                Process pr = Process.GetCurrentProcess();
                pr.Kill();
            }

            for (int i = 100; i >= 5; i--)
            {
                domainUpDown1.Items.Add(i);
            }
            for (int i = 100; i >= 5; i--)
            {
                domainUpDown2.Items.Add(i);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = false;
        }

        private void domainUpDown2_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.overclock.net/threads/mousedataqueuesize-registry-tweak-to-reduce-input-delay-fact-or-fiction.1794122/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\kbdclass\\Parameters\" /v \"KeyboardDataQueueSize\" /t REG_DWORD /d \"{domainUpDown2.Text}\" /f";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            MessageBox.Show("Keyboard: " + output);

            Process process2 = new Process();
            process2.StartInfo.FileName = "cmd.exe";
            process2.StartInfo.Arguments = $"/c Reg.exe add \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\mouclass\\Parameters\" /v \"MouseDataQueueSize\" /t REG_DWORD /d \"{domainUpDown1.Text}\" /f";
            process2.StartInfo.UseShellExecute = false;
            process2.StartInfo.CreateNoWindow = true;
            process2.StartInfo.RedirectStandardOutput = true;
            process2.StartInfo.RedirectStandardError = true;
            process2.Start();
            string output2 = process2.StandardOutput.ReadToEnd();
            MessageBox.Show("Mouse: " + output2);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var NewForm = new About();
            NewForm.ShowDialog();
        }
    }
}
