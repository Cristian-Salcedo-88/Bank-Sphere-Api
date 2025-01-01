using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BankSphere.Infrastructure.Repositories.Base.SQLServer
{
    public class SqlServerBase<T> where T : class
    {
        public string ConnectionString;

        public SqlServerBase(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public async Task<int> SingleInsertWithReturnId(string sql, object parameters)
        {
            int id = -1;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                id = await conn.ExecuteScalarAsync<int>(sql, parameters);
            }
            return id;
        }
        public async Task SingleInsertWith(string sql, object parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                await conn.ExecuteScalarAsync(sql, parameters);
            }
        }
        public async Task<int> SingleUpDate(string sql, object parameters)
        {
            int affectedRows;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                affectedRows = await conn.ExecuteAsync(sql, parameters, commandTimeout: 120);
                conn.Close();
            }
            return affectedRows;
        }
        public async Task<T> ExecuteSingleAsync(string sql, object sqlParameters)
        {
            T sqlResponse = default;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                sqlResponse = (await connection.QueryAsync<T>(sql, param: sqlParameters, commandTimeout: 120)).FirstOrDefault();
                connection.Close();
            }
            return sqlResponse;
        }
        public async Task<IEnumerable<T>> ExecuteResult<T>(string sql, object parameters)
        {
            IEnumerable<T> result = Enumerable.Empty<T>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                result = await conn.QueryAsync<T>(sql, parameters,
                    commandType: CommandType.Text, commandTimeout: 120);
                conn.Close();
            }
            return result;
        }
    }
}
