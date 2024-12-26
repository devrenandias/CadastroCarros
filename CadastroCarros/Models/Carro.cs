using System.ComponentModel.DataAnnotations;

namespace CadastroCarros.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")]
        [Display(Name = "Data de Fabricação")]
        public DateTime dataFabricacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está em formato incorreto")]
        [Display(Name = "Ano de Fabricação")]
        public int anoFabricacao {  get; set; }


        public bool Vendido { get; set; }
         
    }
}
