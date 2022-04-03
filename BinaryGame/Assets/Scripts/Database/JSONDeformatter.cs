using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Database
{
    static class JSONDeformatter
    {
        public static string GetRidOfJsonCharacters(string str)
        {
            str = str.Replace("{", "");
            str = str.Replace("}", "");
            str = str.Replace(" ", "");
            str = str.Replace("\"", "");
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            while (true)
            {
                int startIndex = str.IndexOf("objectid");
                if (startIndex > -1)
                {
                    str = str.Remove(startIndex, 8);
                }
                else
                {
                    break;
                }

            }
            return str;

        }
    }
}
