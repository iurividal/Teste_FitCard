using System.ComponentModel;

namespace Teste_FitCard.Models
{
    public class BancoModel
    {
        [DisplayName("Agência")]
        public string Agencia { get; set; }

        [DisplayName("Conta Corrente")]
        public string Conta { get; set; }
    }
}