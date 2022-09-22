using Cart.Business.Enums;
using Cart.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cart.App.DTO
{
    public class SupplierDTO
    {
        [Key]
        public Guid id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Document { get; set; }

        [DisplayName("Tipo Fornecedor")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [EnumDataType(typeof(KindSupplier), ErrorMessage = "Campo {0} Invalido")]
        public KindSupplier KindSupplier { get; set; }

        [DisplayName("Ativo?")]
        public bool Enable { get; set; }

        /* EF Relations */
        public IEnumerable<ProductViewDTO>? Products { get; set; }

        [Required(ErrorMessage = "Address não informado")]
        public AddressDTO? Address { get; set; }
    }
}
