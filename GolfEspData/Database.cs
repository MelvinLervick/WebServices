using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfEspData
{
    public abstract class Database : IDatabase
    {
        protected OleDbConnection conn;
        protected DataSet ds = new DataSet();
        protected string error = string.Empty;

        public bool LoadAllTableData(string tableName)
        {
            bool errorFlag = false;
            var adapter = new OleDbDataAdapter();
            var query = "Select * from " + tableName;

            adapter.SelectCommand = new OleDbCommand( query, conn );
            
            try
            {
                openConnection();
                adapter.Fill( ds );
            }
            catch (Exception ex)
            {
                error = ex.Message;
                errorFlag = true;
            }

            return errorFlag;
        }

        public bool LoadDataWithQuery(string queryName, string query)
        {
            var adapter = new OleDbDataAdapter();
            bool errorFlag = false;

            try
            {
                adapter.SelectCommand = new OleDbCommand( query, conn );
                openConnection();

                adapter.Fill( ds, queryName );
            }
            catch (Exception ex)
            {
                error = ex.Message;
                errorFlag = true;
            }

            return errorFlag;
        }

        public void OpenConnection(string connectionString)
        {
            conn = new OleDbConnection( connectionString );
        }

        public void CloseConnection()
        {
            closeConnection();
        }

        public OleDbConnection DbConnection { get { return conn; } }
        public DataSet DbDataSet { get { return ds; } }
        
        #region Local Methods

        internal void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        internal void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        #endregion Local Methods
    }
}
