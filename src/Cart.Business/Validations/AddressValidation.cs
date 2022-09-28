using Cart.Business.Models;
using Cart.Business.Validations.Rules;
using FluentValidation;


namespace Cart.Business.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    { 

        public AddressValidation()
        {
            
            RuleFor(e=> RuleCEP.CEPvsUF(e.Cep))
            .Equal(e=>e.Estado)
            .WithMessage("CEP não pertence ao estado informado");

        }
    }
}
