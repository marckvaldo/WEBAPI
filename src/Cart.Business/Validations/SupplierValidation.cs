using Cart.Business.Enums;
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
    public class SupplierValidation: ValidationBase, IValidationBase<Supplier>
    {
        public ReturnValidation IsValid(Supplier Supplier)
        {
            Rules<string>(Supplier.Name, nameof(Supplier.Name))
                .NotEmpty(":field não pode ser Vazio!")
                .Length(5, 50, ":field precisa ter entre :min e :max");

            Rules<string>(Supplier.Document, nameof(Supplier.Document))
                .NotEmpty(":field não pode ser Vazio!")
                .Length(5, 50, ":field precisa ter entre :min e :max");


            WhenEqual(Supplier.KindSupplier == KindSupplier.Fisica, () =>
            {
                Rules<int>(Supplier.Document.Length, nameof(Supplier.Document))
                    .Equal<int>(11, "Campo precisa ter :equal caracteres e foi fornecido :length");
            });

            WhenEqual(Supplier.KindSupplier == KindSupplier.Juridica, () =>
            {
                Rules<int>(Supplier.Document.Length, nameof(Supplier.Document))
                    .Equal<int>(16, "Campo precisa ter :equal caracteres e foi fornecido :length");
            });


            return IsValidBase();
        }

    }
}
