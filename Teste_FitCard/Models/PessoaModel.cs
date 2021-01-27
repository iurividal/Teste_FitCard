using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace Teste_FitCard.Models
{
    public class PessoaModel
    {
        [DisplayName("Nome Razão")]
        [Required]
        public string NomeRazao { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Telefone { get; set; }

        public EnderecoModel Endereco { get; set; } = new EnderecoModel();

    }

    public class EnderecoModel
    {
        public string Logradouro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

    }


    public class EstabelecimentoModel : PessoaModel
    {
        public int IdEstabelecimento { get; set; }

        public string NomeFantasia { get; set; }

        public DateTime DataCadastro { get; set; }

        public CategoriaModel Categoria { get; set; } = new CategoriaModel();

        public string Status { get; set; }

        public BancoModel DadosBancario { get; set; } = new BancoModel();
    }

    public class CategoriaModel
    {
        public int IdCategoria { get; set; }

        public string Categoria { get; set; }

        public IEnumerable<CategoriaModel> GetCategorias()
        {
            return new List<CategoriaModel>
            {
                new CategoriaModel
                {
                    Categoria = "Restaurante",
                    IdCategoria = 1
                },
                new CategoriaModel
                {
                    Categoria = "Supermercado",
                    IdCategoria = 2
                },
                new CategoriaModel
                {
                Categoria = "Borracharia",
                IdCategoria = 3
                },
                new CategoriaModel
                {
                    Categoria = "Posto",
                    IdCategoria = 4
                },
                new CategoriaModel
                {
                    Categoria = "Oficina",
                    IdCategoria = 5
                }

            };

        }
    }
}

public class BancoModel
{
    public string Agencia { get; set; }
    public string Conta { get; set; }
}

