using FerremaxApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiData.Repositories
{
    public interface ITipoProductoRepository
    {
        Task<IEnumerable<TipoProducto>> GetAllTiposProducto();
        Task<TipoProducto> GetTipoProducto(int id);
        Task<bool> InsertTipoProducto(TipoProducto tipoProducto);
        Task<bool> UpdateTipoProducto(TipoProducto tipoProducto);
        Task<bool> DeleteTipoProducto(TipoProducto tipoProducto);
    }
}
