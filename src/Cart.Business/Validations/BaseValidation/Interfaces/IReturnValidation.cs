using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Validations.BaseValidation.Interfaces
{
    public  interface IReturnValidation
    {
        public List<Validation> GetMessageErros { get; set; }
        public bool IsValid { get; set; }
        public int CountErros { get; set; }
    }
}
