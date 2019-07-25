using April.Custom.Base;
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
using static System.Windows.Forms.Control;

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

            //Task_2, Task_3, Task_4
            db = new DatabaseContext(@".\Resource\apteka_sklad.db");
            dt = MyConvert.ListToDataTable(db.Products.ToList());

            customDataGridView1.DataSource = dt;
            //задаем текст ячейки заголовка столбца.
            customDataGridView1.Columns[0].HeaderText = "ID";
            customDataGridView1.Columns[1].HeaderText = "Наименование";
            customDataGridView1.Columns[2].HeaderText = "Цена со скидкой";
            customDataGridView1.Columns[3].HeaderText = "Цена без скидки";
            customDataGridView1.Columns[4].HeaderText = "Производитель";
            customDataGridView1.SetColumnOrder();
        }
        

        private void btnSwitchVisibleColumns_Click(object sender, EventArgs e)
        {
            customDataGridView1.switchVisibleColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e) //без добавления в БД!
        {
            if(this.Controls[0].Controls.DataCheck())
            {
                DataRow MyRow = dt.NewRow();
                MyRow[1] = ctbName.Text;
                MyRow[2] = ctbPrice1.Text;
                MyRow[3] = ctbPrice2.Text;
                MyRow[4] = ctbMaker.Text;
                dt.Rows.Add(MyRow);
                dt.AcceptChanges();
            }
            else
            {
                int x = btnAdd.RectangleToScreen(btnAdd.ClientRectangle).Right - btnAdd.Width / 4;
                int y = btnAdd.RectangleToScreen(btnAdd.ClientRectangle).Top + btnAdd.Height / 2;
                new BalloonTip().Show("Внимание!", "Не все данные заполненны!", (Control)sender, ToolTipIcon.Error, 3000, x, y);
            }
        }

        private void ctbName_MouseHover(object sender, EventArgs e)
        {
            new BalloonTip().Show("Информация", "Введите наименование препарата", (TextBox)sender, ToolTipIcon.Info, 3000);
        }

        private void ctbPrice1_MouseClick(object sender, MouseEventArgs e)
        {
            new BalloonTip().Show("Информация", "Цена со скидкой", (TextBox)sender, ToolTipIcon.Info, 3000);
        }

        private void ctbPrice2_MouseClick(object sender, MouseEventArgs e)
        {
            new BalloonTip().Show("Информация", "Цена без скидки", (TextBox)sender, ToolTipIcon.Info, 3000);
        }
        private void customDataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int x = customDataGridView1.RectangleToScreen(customDataGridView1.ClientRectangle).Left + 60;
            int y = customDataGridView1.RectangleToScreen(customDataGridView1.ClientRectangle).Top + 35;
            new BalloonTip().Show("Информация", "Чтобы скрыть столбец, нажмите на него ПКМ.", (Control)sender, ToolTipIcon.Info, 3000, x, y);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            customDataGridView1.SaveColumnOrder();
        }
        
    }
    public static class ControlCollectionExtension
    {
        public static bool DataCheck(this ControlCollection control)
        {
            var result = true;
            foreach (var elem in control)
            {
                Type type = elem.GetType().GetInterface("ICheckableControl");
                if (type == typeof(ICheckableControl))
                {
                    if(((ICheckableControl)elem).EmptyDataCheck)
                    {
                        if (!((ICheckableControl)elem).Check())
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
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
