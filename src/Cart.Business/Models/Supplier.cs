using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cart.Business.Enums;

namespace Cart.Business.Models
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public KindSupplier KindSupplier { get; set; }
        public bool Enable { get; set; } 

        /* EF Relations */
        public IEnumerable<Product>? Products { get; set; }
        public Address Address { get; set; }

    }
}
