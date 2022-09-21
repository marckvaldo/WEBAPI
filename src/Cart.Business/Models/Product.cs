using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Models
{
    public class Product : Entity
    {
        public Guid  SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Image { get; set; }
        public decimal Price { get; set; }  
        public DateTime DateCreate { get; set; }    
        public bool Enable { get; set; }   

        /* EF Relations */
        public Supplier Supplier { get; set; }    
    }
}
