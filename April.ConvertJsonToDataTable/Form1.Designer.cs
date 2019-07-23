namespace April.ConvertJsonToDataTable
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
            this.btnJSON_to_DataTable = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDataTable_to_JSON = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnJSON_to_DataTable
            // 
            this.btnJSON_to_DataTable.Location = new System.Drawing.Point(12, 161);
            this.btnJSON_to_DataTable.Name = "btnJSON_to_DataTable";
            this.btnJSON_to_DataTable.Size = new System.Drawing.Size(114, 23);
            this.btnJSON_to_DataTable.TabIndex = 2;
            this.btnJSON_to_DataTable.Text = "JSON -> DataTable";
            this.btnJSON_to_DataTable.UseVisualStyleBackColor = true;
            this.btnJSON_to_DataTable.Click += new System.EventHandler(this.btnJSON_to_DataTable_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 190);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(603, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnDataTable_to_JSON
            // 
            this.btnDataTable_to_JSON.Enabled = false;
            this.btnDataTable_to_JSON.Location = new System.Drawing.Point(501, 161);
            this.btnDataTable_to_JSON.Name = "btnDataTable_to_JSON";
            this.btnDataTable_to_JSON.Size = new System.Drawing.Size(114, 23);
            this.btnDataTable_to_JSON.TabIndex = 5;
            this.btnDataTable_to_JSON.Text = "DataTable -> JSON";
            this.btnDataTable_to_JSON.UseVisualStyleBackColor = true;
            this.btnDataTable_to_JSON.Click += new System.EventHandler(this.btnDataTable_to_JSON_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(603, 143);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 353);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDataTable_to_JSON);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnJSON_to_DataTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnJSON_to_DataTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDataTable_to_JSON;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

