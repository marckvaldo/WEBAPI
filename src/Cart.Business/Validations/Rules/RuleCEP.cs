using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Validations.Rules
{
    public static class RuleCEP
    {
        public static string CEPvsUF(string CEP)
        {
            int startCEP = int.Parse(CEP.Substring(0, 2));

            if (startCEP >= 50 && startCEP <= 56) return "PE";

            return "";
        }
    }
}
