﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April.Custom.SQLite
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(
            new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = @".\Resource\apteka_sklad.db", ForeignKeys = true }.ConnectionString
            }, true)
        {
        }
        public DbSet<Product> Products { get; set; }


    }
}
