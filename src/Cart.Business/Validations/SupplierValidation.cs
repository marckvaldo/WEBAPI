using Cart.Business.Enums;
using Cart.Business.Models;
using Cart.Business.Validations.BaseValidation;
using Cart.Business.Validations.BaseValidation.Interfaces;
using Cart.Business.Validations.Rules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Validations
{
    public class SupplierValidation: AbstractValidator<Supplier> //ValidationBase, IValidationBase<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(f => f.Name)
                 .NotEmpty()
                 .WithMessage("O campo {PropertyName} não pode ser vazio!")
                 .Length(5, 50)
                 .WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f=>f.Document)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(5, 16)
                .WithMessage("O Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            When(f=>f.KindSupplier == KindSupplier.Fisica, () =>
            {
                RuleFor(f => f.Document.Length)
                .Equal(RuleCPF.length)
                .WithMessage("Campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(f => RuleCPF.CPFIsValid(f.Document))
                .Equal(true)
                .WithMessage("Documento invalido");

            });

            When(f => f.KindSupplier == KindSupplier.Juridica, () =>
            {
                RuleFor(f => f.Document.Length)
                .Equal(16)
                .WithMessage("Campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(f => RuleCNPJ.CNPJIsValid(f.Document))
                .Equal(true)
                .WithMessage("Documento invalido");

            });
        }       
    }
}
