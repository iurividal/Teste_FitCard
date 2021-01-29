using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teste_FitCard.Models
{
    public class EstabelecimentoModel : PessoaModel
    {
        public int IdEstabelecimento { get; set; }

        public string NomeFantasia { get; set; }


        [DisplayName("Data de Abertura")]
        [DataType(DataType.Date)]
        public DateTime? DataCadastro { get; set; }

        public CategoriaModel Categoria { get; set; } = new CategoriaModel();

        public string Status { get; set; }

        public BancoModel DadosBancario { get; set; } = new BancoModel();
    }
}