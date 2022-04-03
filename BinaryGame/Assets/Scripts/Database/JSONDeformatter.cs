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
            while (true)
            {
                int startIndex = str.IndexOf("_id");
                int endIndex = str.IndexOf("),");
                if (startIndex > -1 && endIndex > 0)
                {
                    str = str.Remove(startIndex, endIndex - startIndex + 2);
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
