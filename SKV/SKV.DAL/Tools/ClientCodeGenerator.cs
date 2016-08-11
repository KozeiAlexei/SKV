using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DAL.Tools
{
    public static class ClientCodeGenerator
    {
        public static string Generate(string last_code)
        {
            var code = default(string);
            if (last_code == null)
                code = "A0";
            else
                code = last_code;

            string lpart = string.Empty; string rpart;

            rpart = (Convert.ToInt32(code.Substring(1)) + 1).ToString();
            if (rpart.Length == 1)
                rpart = "00" + rpart;
            else if (rpart.Length == 2)
                rpart = "0" + rpart;

            var latter = (int)code.First();

            if (rpart == "999")
            {
                if (latter == 90)
                    lpart = "A";
                else
                    lpart = ((char)(++latter)).ToString();
            }
            else
                lpart = ((char)latter).ToString();

            return lpart + rpart.ToString();
        }
    }
}
