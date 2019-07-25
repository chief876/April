using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace April.ConvertJsonToDataTable
{
    public partial class Form1 : Form
    {
        private DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Task_8
            richTextBox1.Text = "[\n{\"id\":\"10\",\"name\":\"User\",\"add\":false,\"edit\":true,\"authorize\":true,\"view\":true}, {\"id\":\"11\",\"name\":\"Group\",\"add\":true,\"edit\":false,\"authorize\":false,\"view\":true}, {\"id\":\"12\",\"name\":\"Permission\",\"add\":true,\"edit\":true,\"authorize\":true,\"view\":true}\n]";
        }
        private void btnJSON_to_DataTable_Click(object sender, EventArgs e)
        {
            dt = Convert.JsonToDataTable(richTextBox1.Text);
            dataGridView1.DataSource = dt;
            btnDataTable_to_JSON.Enabled = true;
        }

        private void btnDataTable_to_JSON_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string JSONresult = Convert.DataTableToJson(dt);
            richTextBox1.Text = JSONresult;
        }

    }
}
