using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Teste_FitCard.Models
{
    public class DbContext
    {

        private const string connectString = "Server=tcp:iurisvidal.database.windows.net,1433;Initial Catalog=FitCardTeste;Persist Security Info=False;User ID=iurividal;Password=Ygvhm4SR960T;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public SqlConnection Connection()
        {
            return new SqlConnection(connectString);
        }
    }
}