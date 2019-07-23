using April.Custom.CustomForms;
using April.Custom.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace April.Custom
{
    public partial class Form1 : Form
    {
        DatabaseContext db;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new DatabaseContext();
            dt = MyConvert.ListToDataTable(db.Products.ToList());

            customDataGridView1.DataSource = dt;
            //задаем текст ячейки заголовка столбца.
            customDataGridView1.Columns[0].HeaderText = "ID";
            customDataGridView1.Columns[1].HeaderText = "Название";
            customDataGridView1.Columns[2].HeaderText = "Цена со скидкой";
            customDataGridView1.Columns[3].HeaderText = "Цена без скидки";
            customDataGridView1.Columns[4].HeaderText = "Производитель";
            customDataGridView1.SetColumnOrder();
        }
        

        private void btnSwitchVisibleColumns_Click(object sender, EventArgs e)
        {
            customDataGridView1.switchVisibleColumns();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            customDataGridView1.SaveColumnOrder();
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            new BalloonTip().Show("Информация", "Введите наименование препарата", (TextBox)sender, ToolTipIcon.Info, 3000);
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            new BalloonTip().Show("Информация", "Цена со скидкой", (TextBox)sender, ToolTipIcon.Info, 3000);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbMaker.Text))
            {
                int x = tbMaker.RectangleToScreen(tbMaker.ClientRectangle).Left + tbMaker.Width / 2;
                int y = tbMaker.RectangleToScreen(tbMaker.ClientRectangle).Top + tbMaker.Height / 2;
                new BalloonTip().Show("Внимание!", "Введите производителя!", (Control)sender, ToolTipIcon.Error, 3000, x, y);
            }
            else
            {
                DataRow MyRow = dt.NewRow();
                MyRow[1] = tbName.Text;
                MyRow[2] = tbPrice1.Text;
                MyRow[3] = tbPrice2.Text;
                MyRow[4] = tbMaker.Text;
                dt.Rows.Add(MyRow);
                dt.AcceptChanges();
            }
        }
    }
    public static class MyConvert
    {
        public static DataTable ListToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
