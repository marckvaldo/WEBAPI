using Cart.Business.Models;
using Cart.Business.Validations.BaseValidation;
using Cart.Business.Validations.BaseValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Validations
{
    public class AddressValidation : ValidationBase, IValidationBase<Address>
    {
        public ReturnValidation IsValid(Address Entity)
        {
            WhenEqual(Entity.Cep.Substring(0, 2) == "56", () =>
            {
                Rules(Entity.Estado, nameof(Entity.Cep))
                .Equal("Pernambuco", "O :field não pertence ao estado de :equal !");
                
            });

            return IsValidBase();
        }
    }
}
