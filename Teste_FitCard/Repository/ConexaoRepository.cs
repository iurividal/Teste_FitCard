using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Teste_FitCard.Repository
{
    public class ConexaoRepository
    {
        public SqlConnection Conexao => new SqlConnection(ConfigurationManager.ConnectionStrings["fitcardTeste"].ConnectionString);

    }
}