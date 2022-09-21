using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Validations.BaseValidation.Interfaces
{
    public  interface IValidationBase<T>
    {
        public ReturnValidation IsValid(T Entity);
    }
}
