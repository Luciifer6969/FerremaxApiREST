using Dapper;
using FerremaxApiModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiData.Repositories
{
    public class MarcaRepository(MySQLConfiguration connectionString) : IMarcaRepository
    {
        private readonly MySQLConfiguration _connectionString = connectionString;

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteMarca(Marca marca)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM marca WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new { marca.id });

            return result > 0;
        }

        public async Task<IEnumerable<Marca>> GetAllMarcas()
        {
            var db = dbConnection();

            var sql = @" SELECT * from marca";

            return await db.QueryAsync<Marca>(sql, new { });
        }

        public async Task<Marca> GetMarca(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT * from marca WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Marca>(sql, new { id });
        }

        public async Task<bool> InsertMarca(Marca marca)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO marca(Nombre)  
                        VALUES (@Nombre);";
            var result = await db.ExecuteAsync(sql, new
            {
                marca.Nombre
            });

            return result > 0;
        }

        public async Task<bool> UpdateMarca(Marca marca)
        {
            var db = dbConnection();

            var sql = @" UPDATE marca 
                         SET nombre=@Nombre 
                        WHERE id = @id ";
            var result = await db.ExecuteAsync(sql, new
            {
                marca.Nombre,
                marca.id
            });

            return result > 0;
        }
    }
}
