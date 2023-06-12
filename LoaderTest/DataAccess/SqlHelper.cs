using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LoaderTest.DataAccess;

public class SqlHelper
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public SqlHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public List<T> Query<T>(string sql, object parameters = null)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            return connection.Query<T>(sql, parameters).ToList();
        }
    }

    public int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(commandText, connection) { CommandType = commandType };
        if (parameters.Length > 0)
        {
            command.Parameters.AddRange(parameters);
        }
        connection.Open();
        return command.ExecuteNonQuery();
    }

    public object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(commandText, connection) { CommandType = commandType };
        if (parameters.Length > 0)
        {
            command.Parameters.AddRange(parameters);
        }
        connection.Open();
        return command.ExecuteScalar();
    }

    public DataTable ExecuteDataTable(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(commandText, connection) { CommandType = commandType };
        if (parameters.Length > 0)
        {
            command.Parameters.AddRange(parameters);
        }
        using var adapter = new SqlDataAdapter(command);
        var dataTable = new DataTable();
        adapter.Fill(dataTable);
        return dataTable;
    }
}
