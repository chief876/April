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
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbPrice1 = new System.Windows.Forms.Label();
            this.tbPrice1 = new System.Windows.Forms.TextBox();
            this.lbPrice2 = new System.Windows.Forms.Label();
            this.tbPrice2 = new System.Windows.Forms.TextBox();
            this.lbMaker = new System.Windows.Forms.Label();
            this.tbMaker = new System.Windows.Forms.TextBox();
            this.customDataGridView1 = new April.Custom.CustomForms.CustomDataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSwitchVisibleColumns
            // 
            this.btnSwitchVisibleColumns.Location = new System.Drawing.Point(446, 104);
            this.btnSwitchVisibleColumns.Name = "btnSwitchVisibleColumns";
            this.btnSwitchVisibleColumns.Size = new System.Drawing.Size(123, 23);
            this.btnSwitchVisibleColumns.TabIndex = 1;
            this.btnSwitchVisibleColumns.Text = "Switch visible columns";
            this.btnSwitchVisibleColumns.UseVisualStyleBackColor = true;
            this.btnSwitchVisibleColumns.Click += new System.EventHandler(this.btnSwitchVisibleColumns_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMaker);
            this.groupBox1.Controls.Add(this.tbMaker);
            this.groupBox1.Controls.Add(this.lbPrice2);
            this.groupBox1.Controls.Add(this.tbPrice2);
            this.groupBox1.Controls.Add(this.lbPrice1);
            this.groupBox1.Controls.Add(this.tbPrice1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить данные в таблицу:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(98, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(87, 20);
            this.tbName.TabIndex = 0;
            this.tbName.MouseHover += new System.EventHandler(this.textBox1_MouseHover);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 22);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(57, 13);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Название";
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
            // lbPrice1
            // 
            this.lbPrice1.AutoSize = true;
            this.lbPrice1.Location = new System.Drawing.Point(6, 48);
            this.lbPrice1.Name = "lbPrice1";
            this.lbPrice1.Size = new System.Drawing.Size(42, 13);
            this.lbPrice1.TabIndex = 7;
            this.lbPrice1.Text = "Цена 1";
            // 
            // tbPrice1
            // 
            this.tbPrice1.Location = new System.Drawing.Point(98, 45);
            this.tbPrice1.Name = "tbPrice1";
            this.tbPrice1.Size = new System.Drawing.Size(87, 20);
            this.tbPrice1.TabIndex = 6;
            this.tbPrice1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseClick);
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
            // tbPrice2
            // 
            this.tbPrice2.Location = new System.Drawing.Point(98, 71);
            this.tbPrice2.Name = "tbPrice2";
            this.tbPrice2.Size = new System.Drawing.Size(87, 20);
            this.tbPrice2.TabIndex = 8;
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
            // tbMaker
            // 
            this.tbMaker.Location = new System.Drawing.Point(98, 97);
            this.tbMaker.Name = "tbMaker";
            this.tbMaker.Size = new System.Drawing.Size(87, 20);
            this.tbMaker.TabIndex = 10;
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
        private System.Windows.Forms.TextBox tbMaker;
        private System.Windows.Forms.Label lbPrice2;
        private System.Windows.Forms.TextBox tbPrice2;
        private System.Windows.Forms.Label lbPrice1;
        private System.Windows.Forms.TextBox tbPrice1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
    }
}

