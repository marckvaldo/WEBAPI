using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Validations.BaseValidation.Interfaces
{
    public  interface IValidation
    {
        public string Message { get; set; }
        public string Field { get; set; }
    }
}
