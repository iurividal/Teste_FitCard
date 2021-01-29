using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teste_FitCard.Models
{
    public class CategoriaModel
    {

        public int IdCategoria { get; set; }

        [MaxLength(100)]
        public string Categoria { get; set; }


    }
}