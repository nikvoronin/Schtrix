using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Schtrix
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Assembly execAsm = Assembly.GetExecutingAssembly();
            versionLabel.Text = execAsm.GetName().Version.ToString();
            copyrightLabel.Text = ((AssemblyCopyrightAttribute)execAsm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://zxingnet.codeplex.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.aforgenet.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel3.Text);
        }
    }
}
