using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq; 
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace April.Custom.CustomForms
{
    [Serializable]
    public partial class CustomDataGridView : DataGridView
    {
        private int CurrentColumn { get; set; }
        private Guid id;
        public Guid Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }  
        public CustomDataGridView()
        {
            InitializeComponent();

            try
            {                                                                   //У каждого пользователя сохранены свои настройки:
                string sGuid = File.ReadAllText("./guid.txt");                  // user1: 132be0b9-a6b4-499f-a962-0517d685d105
                if (!Guid.TryParse(sGuid, out id))                               // user2: 9d60354d-df42-4688-80b9-a06457b939fd
                {                                                               // user3: c3b0cfd4-b60b-4fd7-978b-5d9235717dc5
                    throw new Exception();
                }
            }
            catch
            {
                Id = Guid.NewGuid();
                File.WriteAllText("./guid.txt", Id.ToString());
            }


        }
        


        private void CustomDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    setFilterColumn(e.ColumnIndex);
                    break;
                case MouseButtons.Right:
                    hideColumn(e.ColumnIndex);
                    break;
            }

        }

        private void CustomDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormInputText fit = new FormInputText();
            fit.FilterText = e.KeyChar.ToString();
            if (fit.ShowDialog() == DialogResult.OK)
            {
                var filterField = this.Columns[CurrentColumn].Name;
                (DataSource as DataTable).DefaultView.RowFilter = String.Format("[{0}] LIKE '%{1}%'", filterField, fit.FilterText);

            }

            e.Handled = true;
        }

        private void setFilterColumn(int index)
        {
            if (this.DataSource.GetType() == typeof(DataTable))
            {
                Font font = new Font(this.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                this.Columns[index].HeaderCell.Style.Font = font;
                //(this.DataSource as DataTable).DefaultView.RowFilter = "";
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (i == index)
                    {
                        this.Columns[index].HeaderCell.Style.Font = font;
                    }
                    else
                    {
                        this.Columns[i].HeaderCell.Style.Font = this.ColumnHeadersDefaultCellStyle.Font;
                    }
                }

                CurrentColumn = index;
            }
        }
        private void hideColumn(int index)
        {
            try
            {
                var column = (DataGridViewTextBoxColumn)this.Columns[index];
                column.Visible = !column.Visible;
            }
            catch
            {
            }
        }
        public void switchVisibleColumns()
        {
            foreach (var column in this.Columns)
            {
                var c = (DataGridViewTextBoxColumn)column;
                c.Visible = !c.Visible;

            }
        }

        //сохранение настроек
        public void SaveColumnOrder()
        {
            if (this.AllowUserToOrderColumns)
            {
                List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
                DataGridViewColumnCollection columns = this.Columns;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnOrder.Add(new ColumnOrderItem
                    {
                        ColumnIndex = i,
                        DisplayIndex = columns[i].DisplayIndex,
                        Visible = columns[i].Visible,
                        Width = columns[i].Width
                    });
                }
                CustomDataGridViewSetting.Default.ColumnOrder[Id.ToString()] = columnOrder;
                CustomDataGridViewSetting.Default.Save();
            }
        }
        //загрузка настроек
        public void SetColumnOrder()
        {
            if (!CustomDataGridViewSetting.Default.ColumnOrder.ContainsKey(Id.ToString()))
                return;

            List<ColumnOrderItem> columnOrder =
                CustomDataGridViewSetting.Default.ColumnOrder[Id.ToString()];

            if (columnOrder != null)
            {
                var sorted = columnOrder.OrderBy(i => i.DisplayIndex);
                foreach (var item in sorted)
                {
                    this.Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
                    this.Columns[item.ColumnIndex].Visible = item.Visible;
                    this.Columns[item.ColumnIndex].Width = item.Width;
                }
            }
        }
        #region класс сериализации
        internal sealed class CustomDataGridViewSetting : ApplicationSettingsBase
        {
            private static CustomDataGridViewSetting _defaultInstace =
                (CustomDataGridViewSetting)ApplicationSettingsBase.Synchronized(new CustomDataGridViewSetting());
            //---------------------------------------------------------------------
            public static CustomDataGridViewSetting Default
            {
                get { return _defaultInstace; }
            }
            //---------------------------------------------------------------------

            [UserScopedSetting]
            [SettingsSerializeAs(SettingsSerializeAs.Binary)]
            [DefaultSettingValue("")]

            public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
            {
                get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>; }
                set { this["ColumnOrder"] = value; }
            }
        }
        [Serializable]
        public sealed class ColumnOrderItem
        {
            public int DisplayIndex { get; set; }
            public int Width { get; set; }
            public bool Visible { get; set; }
            public int ColumnIndex { get; set; }
        }
        #endregion

    }
}
