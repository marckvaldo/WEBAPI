using Cart.Business.Models;
using FluentValidation;


namespace Cart.Business.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {

        public ProductValidation()
        {
            RuleFor<decimal>(p => p.Price)
                .NotEmpty()
                .WithMessage("Informe um valor válido para {PropertyName}")
                .GreaterThan(0).ScalePrecision(2,12)
                .WithMessage(" informar um valor para {PropertyName}");

        }
    }
}
