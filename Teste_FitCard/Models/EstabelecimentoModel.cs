﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teste_FitCard.Models
{
    public class EstabelecimentoModel : PessoaModel
    {
        public int IdEstabelecimento { get; set; }

        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de Abertura")]
        public DateTime? DataCadastro { get; set; }

        public CategoriaModel Categoria { get; set; } = new CategoriaModel();

        public string Status { get; set; }

        public BancoModel DadosBancario { get; set; } = new BancoModel();
    }
}