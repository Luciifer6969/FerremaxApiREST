using FerremaxApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiData.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto> GetDetails(int id);
        Task<bool> InsertProducto(Producto Producto);
        Task<bool> UpdateProducto(Producto Producto);
        Task<bool> DeleteProducto(Producto Producto);
    }
}
