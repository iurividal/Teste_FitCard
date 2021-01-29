using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste_FitCard.Models
{

    

    public class EstadosModel
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao regiao { get; set; }
    }

    public class Regiao
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }

}
