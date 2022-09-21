using Cart.Business.Validations.BaseValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Validations.BaseValidation
{
    public  class Validation : IValidation
    {
        public string Message { get; set; } 
        public string Field { get; set; }
    }
}
