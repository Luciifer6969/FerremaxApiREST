using FerremaxApiModel;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiData.Repositories
{
    public class TipoProductoRepository(MySQLConfiguration connectionString) : ITipoProductoRepository
    {
        private readonly MySQLConfiguration _connectionString = connectionString;

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteTipoProducto(TipoProducto tipoProducto)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM tipoproducto WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = tipoProducto.id });

            return result > 0;
        }

        public async Task<IEnumerable<TipoProducto>> GetAllTiposProducto()
        {
            var db = dbConnection();

            var sql = @" SELECT * from tipoproducto";

            return await db.QueryAsync<TipoProducto>(sql, new { });
        }

        public async Task<TipoProducto> GetTipoProducto(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT * from tipoproducto WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<TipoProducto>(sql, new { id });
        }

        public async Task<bool> InsertTipoProducto(TipoProducto tipoProducto)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO tipoproducto(Nombre) 
                        VALUES (@Nombre);";
            var result = await db.ExecuteAsync(sql, new {tipoProducto.Nombre});

            return result > 0;
        }

        public async Task<bool> UpdateTipoProducto(TipoProducto tipoProducto)
        {
            var db = dbConnection();

            var sql = @" UPDATE tipoproducto 
                         SET nombre=@Nombre 
                        WHERE id = @id ";
            var result = await db.ExecuteAsync(sql, new
            {
                tipoProducto.Nombre,
                tipoProducto.id
            });

            return result > 0;
        }
    }
}
