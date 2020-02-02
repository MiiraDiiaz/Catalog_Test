using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Test_без_БД
{
    public class Catalog_Level
    {
        public int id { get; set; }
        public int Parent_id { get; set; }
        public string Name { get; set; }
    }
}
