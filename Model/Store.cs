using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_DB2.Model
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public List<Sale> Sales { get; set; } = new List<Sale>();
    }

}
