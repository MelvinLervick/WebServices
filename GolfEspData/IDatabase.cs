using System.Data;
using System.Data.OleDb;

namespace GolfEspData
{
    public interface IDatabase
    {
        bool LoadAllTableData(string tableName);
        bool LoadDataWithQuery(string queryName, string query);
        void OpenConnection( string connectionString );
        void CloseConnection();
        OleDbConnection DbConnection { get; }
        DataSet DbDataSet { get; }
    }
}