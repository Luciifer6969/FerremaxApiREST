using FerremaxApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiData.Repositories
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetAllMarcas();
        Task<Marca> GetMarca(int id);
        Task<bool> InsertMarca(Marca marca);
        Task<bool> UpdateMarca(Marca marca);
        Task<bool> DeleteMarca(Marca marca);
    }
}
