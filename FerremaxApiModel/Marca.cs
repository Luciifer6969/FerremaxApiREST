using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiModel
{
    public class Marca
    {
        [Key]
        public int id { get; set; }
        public string? Nombre { get; set; }


    }
}
