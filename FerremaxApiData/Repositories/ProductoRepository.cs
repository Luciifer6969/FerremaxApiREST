using Dapper;
using FerremaxApiModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FerremaxApiData.Repositories
{
    public class ProductoRepository(MySQLConfiguration connectionString) : IProductoRepository

    {
        private readonly MySQLConfiguration _connectionString = connectionString;

        protected MySqlConnection dbConnection()
        { 
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM PRODUCTO WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = producto.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            var db = dbConnection();

            var sql = @" SELECT * from Producto";

            return await db.QueryAsync<Producto>(sql, new { });
        }

        public async Task<Producto> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT * from producto WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Producto>(sql, new { id });
        }

        public async Task<bool> InsertProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO Producto(Nombre,Descripcion,Precio,Cantidad_disponible,Imagen_url,Marca_id,Tipoproducto_id) 
                        VALUES (@Nombre,@Descripcion,@Precio,@Cantidad_disponible,@Imagen_url,@Marca_id,@Tipoproducto_id)";
            var result = await db.ExecuteAsync(sql, new { producto.Nombre, producto.Descripcion, producto.Precio,
                producto.Cantidad_disponible, producto.Imagen_url, producto.Marca_id, producto.TipoProducto_id });

            return result > 0;
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @" UPDATE Producto 
                         SET nombre=@Nombre,descripcion=@Descripcion,
                        precio=@Precio,cantidad_disponible=@Cantidad_disponible,
                        imagen_url=@Imagen_url,marca_id=@Marca_id,
                        tipoproducto_id=@Tipoproducto_id 
                        WHERE id = @Id ";
            var result = await db.ExecuteAsync(sql, new { producto.Nombre, producto.Descripcion, producto.Precio,
                producto.Cantidad_disponible, producto.Imagen_url, producto.Marca_id, producto.TipoProducto_id, producto.Id });

            return result > 0;
        }
    }
}
