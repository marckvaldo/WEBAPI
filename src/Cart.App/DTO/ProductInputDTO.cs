using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Cart.App.DTO
{
    public class ProductInputDTO
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public Guid? SupplierId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Description { get; set; }

        public string? ImageUpload { get; set; }

        public string? Image { get; set; }

        [DisplayName("Preco")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        [DisplayName("Ativo?")]
        public bool Enable { get; set; }

    }
}
