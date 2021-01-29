using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste_FitCard
{
    public static class Helpers
    {
        public static string FormatCNPJ(this string CNPJ)
        {
            try
            {
                return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
            }
            catch
            {
                return "";
            }

        }
    }
}