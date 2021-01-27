using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtermap
{
    class Encrypt
    {
        public static String booltoarray(bool[] Input)
        {
            int asc = 65;
            
            StringBuilder response = new StringBuilder();
            for (int i = 0; i < Input.GetLength(0); i++)
            {
                response.Append(Convert.ToChar(asc));
                asc++;
            }
            return response.ToString();
            
        }
    }
}
