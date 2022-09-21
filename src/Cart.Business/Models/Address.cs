using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Models
{
    public class Address: Entity
    {
        public Guid SupplierId { get; set; } 
        public string Logradouro { get; set; }
        public string Number { get; set; }  
        public string Complemento { get; set; } 
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /* EF Relations */
        public Supplier Supplier { get; set; }    

    }
}
