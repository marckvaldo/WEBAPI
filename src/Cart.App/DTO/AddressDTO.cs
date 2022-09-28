using Cart.Business.Helps;
using Cart.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cart.App.DTO
{
    public class AddressDTO
    {
        public AddressDTO(string Estado)
        {
            if(Estado.Length > 2)
                this.Estado = UFvsEstados.EstadoToUF(Estado);
            else 
                this.Estado = UFvsEstados.UFtoEstado(Estado);
        }

        [Key]
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }

        [DisplayName("Logradouro")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Logradouro { get; set; }

        [DisplayName("Numero")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Number { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Estado { get; private set; }

    }
}
