namespace April.Custom
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSwitchVisibleColumns = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMaker = new System.Windows.Forms.Label();
            this.lbPrice2 = new System.Windows.Forms.Label();
            this.lbPrice1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.ctbMaker = new April.Custom.CustomForms.CustomTextBox();
            this.ctbPrice2 = new April.Custom.CustomForms.CustomTextBox();
            this.ctbPrice1 = new April.Custom.CustomForms.CustomTextBox();
            this.ctbName = new April.Custom.CustomForms.CustomTextBox();
            this.customDataGridView1 = new April.Custom.CustomForms.CustomDataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSwitchVisibleColumns
            // 
            this.btnSwitchVisibleColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwitchVisibleColumns.Location = new System.Drawing.Point(389, 104);
            this.btnSwitchVisibleColumns.Name = "btnSwitchVisibleColumns";
            this.btnSwitchVisibleColumns.Size = new System.Drawing.Size(180, 23);
            this.btnSwitchVisibleColumns.TabIndex = 1;
            this.btnSwitchVisibleColumns.Text = "Переключить видимые столбцы";
            this.btnSwitchVisibleColumns.UseVisualStyleBackColor = true;
            this.btnSwitchVisibleColumns.Click += new System.EventHandler(this.btnSwitchVisibleColumns_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctbMaker);
            this.groupBox1.Controls.Add(this.lbMaker);
            this.groupBox1.Controls.Add(this.ctbPrice2);
            this.groupBox1.Controls.Add(this.lbPrice2);
            this.groupBox1.Controls.Add(this.ctbPrice1);
            this.groupBox1.Controls.Add(this.lbPrice1);
            this.groupBox1.Controls.Add(this.ctbName);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить данные в таблицу:";
            // 
            // lbMaker
            // 
            this.lbMaker.AutoSize = true;
            this.lbMaker.Location = new System.Drawing.Point(6, 100);
            this.lbMaker.Name = "lbMaker";
            this.lbMaker.Size = new System.Drawing.Size(86, 13);
            this.lbMaker.TabIndex = 11;
            this.lbMaker.Text = "Производитель";
            // 
            // lbPrice2
            // 
            this.lbPrice2.AutoSize = true;
            this.lbPrice2.Location = new System.Drawing.Point(6, 74);
            this.lbPrice2.Name = "lbPrice2";
            this.lbPrice2.Size = new System.Drawing.Size(42, 13);
            this.lbPrice2.TabIndex = 9;
            this.lbPrice2.Text = "Цена 2";
            // 
            // lbPrice1
            // 
            this.lbPrice1.AutoSize = true;
            this.lbPrice1.Location = new System.Drawing.Point(6, 48);
            this.lbPrice1.Name = "lbPrice1";
            this.lbPrice1.Size = new System.Drawing.Size(42, 13);
            this.lbPrice1.TabIndex = 7;
            this.lbPrice1.Text = "Цена 1";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(189, 96);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 22);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(83, 13);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Наименование";
            // 
            // ctbMaker
            // 
            this.ctbMaker.EmptyDataCheck = true;
            this.ctbMaker.Location = new System.Drawing.Point(92, 97);
            this.ctbMaker.Name = "ctbMaker";
            this.ctbMaker.Size = new System.Drawing.Size(91, 20);
            this.ctbMaker.TabIndex = 7;
            // 
            // ctbPrice2
            // 
            this.ctbPrice2.EmptyDataCheck = true;
            this.ctbPrice2.Location = new System.Drawing.Point(92, 71);
            this.ctbPrice2.Name = "ctbPrice2";
            this.ctbPrice2.Size = new System.Drawing.Size(91, 20);
            this.ctbPrice2.TabIndex = 6;
            this.ctbPrice2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctbPrice2_MouseClick);
            // 
            // ctbPrice1
            // 
            this.ctbPrice1.EmptyDataCheck = true;
            this.ctbPrice1.Location = new System.Drawing.Point(92, 45);
            this.ctbPrice1.Name = "ctbPrice1";
            this.ctbPrice1.Size = new System.Drawing.Size(91, 20);
            this.ctbPrice1.TabIndex = 5;
            this.ctbPrice1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctbPrice1_MouseClick);
            // 
            // ctbName
            // 
            this.ctbName.EmptyDataCheck = true;
            this.ctbName.Location = new System.Drawing.Point(92, 19);
            this.ctbName.Name = "ctbName";
            this.ctbName.Size = new System.Drawing.Size(91, 20);
            this.ctbName.TabIndex = 4;
            this.ctbName.MouseHover += new System.EventHandler(this.ctbName_MouseHover);
            // 
            // customDataGridView1
            // 
            this.customDataGridView1.AllowUserToOrderColumns = true;
            this.customDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customDataGridView1.Location = new System.Drawing.Point(12, 133);
            this.customDataGridView1.Name = "customDataGridView1";
            this.customDataGridView1.ReadOnly = true;
            this.customDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customDataGridView1.Size = new System.Drawing.Size(557, 245);
            this.customDataGridView1.TabIndex = 2;
            this.customDataGridView1.VirtualMode = true;
            this.customDataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.customDataGridView1_ColumnHeaderMouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 390);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customDataGridView1);
            this.Controls.Add(this.btnSwitchVisibleColumns);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSwitchVisibleColumns;
        private CustomForms.CustomDataGridView customDataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMaker;
        private System.Windows.Forms.Label lbPrice2;
        private System.Windows.Forms.Label lbPrice1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lbName;
        private CustomForms.CustomTextBox ctbMaker;
        private CustomForms.CustomTextBox ctbPrice2;
        private CustomForms.CustomTextBox ctbPrice1;
        private CustomForms.CustomTextBox ctbName;
    }
}

