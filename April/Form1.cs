using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace April
{
    public partial class Form1 : Form
    {
        string connect = "Server=127.0.0.1; Port=5433; User Id=postgres; Password=115507; Database=db_april";
        string selectQuery = "SELECT * FROM public.pharmacy_warehouse where \"Discount_Price\" = @p1";
        string selectQuery1 = "SELECT * FROM public.pharmacy_warehouse where \"Manufacturer\" like @p1 and \"Name\" like @p2";
        string selectQuery2 = "SELECT * FROM public.pharmacy_warehouse";
        string updateQuery = "UPDATE pharmacy_warehouse SET \"Discount_Price\" = @p1 where \"Name\" = @p2";
        string insertQuery = "INSERT INTO pharmacy_warehouse (\"Name\", \"Discount_Price\", \"Price_Without_Discount\", \"Manufacturer\") VALUES (@p2, @p1, @p3, @p4)";
        public Form1()
        {
            InitializeComponent();

            //insert("Mezim", 140, 215, "Menarini");
            select();
        }
        
        
        void select()
        {
            Query q = new Query(connect, selectQuery2);
            q.OpenConnection(); 
            q.ExecuteNonQuery();
            dataGridView1.DataSource = q.FillData();
            q.Dispose();
        }
        void insert(string name, int price1, int price2, string maker)
        {
            Query q = new Query(connect, insertQuery);
            q.OpenConnection();
            //q.BeginTransaction();
            q.Cmd = new NpgsqlCommand(insertQuery, q.Conn); 
            q.Add("p2", name, NpgsqlDbType.Text);
            q.Add("p1", price1, NpgsqlTypes.NpgsqlDbType.Integer);
            q.Add("p3", price2, NpgsqlTypes.NpgsqlDbType.Integer); 
            q.Add("p4", maker, NpgsqlDbType.Text);
            q.ExecuteNonQuery();
            //q.CommitTransaction();
            
            q.Dispose();

        }
        public void deriveParametersVarious(string name)
        {

            using (Query q = new Query(connect))
            {
                q.OpenConnection();
                q.Cmd = new NpgsqlCommand("public.select_price", q.Conn);
                q.Cmd.CommandType = CommandType.StoredProcedure;
                q.DeriveParameters();
                q.Cmd.Parameters[0].Value = name;

                q.ExecuteNonQuery();

                lPrice1.Text = q.Cmd.Parameters[1].Value.ToString();
                lPrice2.Text = q.Cmd.Parameters[2].Value.ToString();

                q.CloseConnection();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deriveParametersVarious(tbName.Text);
        }
    }
}
