using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string conectionString) 
        {
            ConnectionString=conectionString;
        }
        public string? ConnectionString { get; set; }

    }
}
