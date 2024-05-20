using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerremaxApiData
{
    public class MySQLConfiguration(string connectionString)
    {
        public string ConnectionString { get; set; } = connectionString;
    }
}
