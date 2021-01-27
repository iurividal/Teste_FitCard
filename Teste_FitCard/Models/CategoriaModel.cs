using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teste_FitCard.Models
{
    public class CategoriaModel : DbContext
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Informe a categoria")]
        [MaxLength(100)]
        public string Categoria { get; set; }


    }
}