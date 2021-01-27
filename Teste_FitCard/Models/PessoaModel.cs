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
}