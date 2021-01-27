using System;

namespace Teste_FitCard.Models
{
    public class EstabelecimentoModel : PessoaModel
    {
        public int IdEstabelecimento { get; set; }

        public string NomeFantasia { get; set; }

        public DateTime DataCadastro { get; set; }

        public CategoriaModel Categoria { get; set; } = new CategoriaModel();

        public string Status { get; set; }

        public BancoModel DadosBancario { get; set; } = new BancoModel();
    }
}