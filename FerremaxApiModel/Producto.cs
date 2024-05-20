using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiModel
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal? Precio { get; set; }

        public int? Cantidad_disponible { get; set; }

        public string? Imagen_url { get; set; } 

        //public int? MarcaId { get; set; }

        //public int? TipoProductoId { get; set; }

        public int Marca_id { get; set; } 
        //public  Marca? Marca { get; set; }

        public int TipoProducto_id { get; set; }
        //public  TipoProducto? TipoProducto { get; set; }
    }
}
