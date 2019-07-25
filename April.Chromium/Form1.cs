using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace April.Chromium
{
    public partial class Form1 : Form
    {
        ChromiumWebBrowser myBrowser;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Task_7
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/GPMDP";
            //settings.WindowlessRenderingEnabled = true;

            Cef.Initialize(settings);
            myBrowser = new ChromiumWebBrowser(@"file:///Resources/yandex.html");
            this.Controls.Add(myBrowser);
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нажмите и удерживайте клавишу \"Ctrl\" что бы поставить метку.\nДля рисования произвольной области, зажмите клавишу \"Alt\".", "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        
    }
}
