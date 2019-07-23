using NpgsqlTypes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April
{
    public class Query : IDisposable
    {
        private bool disposed = false;
        private NpgsqlTransaction et;
        public NpgsqlConnection Conn { get; set; }
        public NpgsqlCommand Cmd { get; set; }

        public Query()
        {
        }
        public Query(string connection, string cmdText = null)
        {
            Conn = new NpgsqlConnection(connection);
            if (!String.IsNullOrEmpty(cmdText))
            {
                Cmd = new NpgsqlCommand(cmdText, Conn);
            }
        }
        public bool DeriveParameters()
        {
            if(Cmd != null && Cmd.CommandType == CommandType.StoredProcedure)
            {
                NpgsqlCommandBuilder.DeriveParameters(Cmd);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool OpenConnection()
        {
            try
            {
                Conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool CloseConnection()
        {
            try
            {
                Conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Add(string parameterName, object parameterValue, NpgsqlDbType type)
        {
            try
            {
                Cmd.Parameters.AddWithValue(parameterName, type, parameterValue);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool BeginTransaction()
        {
            try
            {
                et = Conn.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool CommitTransaction()
        {
            try
            {
                et.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool RollbackTransaction()
        {
           
            try
            {
                et.Rollback();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool ExecuteNonQuery()
        {
            try
            {
                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public DataTable FillData()
        {
            DataSet ds = new DataSet();
            //ds.Reset();
            new NpgsqlDataAdapter(Cmd).Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }


        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if(et != null)
                    {
                        et.Dispose();
                        et = null;
                    }
                    if(Cmd != null)
                    {
                        Cmd.Dispose();
                        Cmd = null;
                    }
                    if(Conn != null)
                    {
                        CloseConnection();
                        Conn.Dispose();
                        Conn = null;
                    }
                }
                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }
         
        ~Query()
        {
            Dispose(false);
        }
    }
}
