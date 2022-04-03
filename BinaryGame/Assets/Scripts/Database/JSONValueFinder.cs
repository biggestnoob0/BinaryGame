using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Database
{
    internal class JSONValueFinder
    {
        public static string findValue(string str, string label)
        {

            int labelIndex = str.IndexOf(label + ":");
            if (labelIndex > -1)
            {
                string newStr = str.Remove(0, labelIndex);
                newStr = JSONDeformatter.GetRidOfJsonCharacters(newStr);
                int commaIndex = newStr.IndexOf(",");
                if (commaIndex > -1)
                {
                    return newStr.Substring(label.Length + 1, commaIndex - label.Length - 1);
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
        public static List<string> findValues(string str, string label)
        {
            List<string> values = new List<string>();
            int labelIndex = str.IndexOf(label + ":");
            if (labelIndex > -1)
            {
                string newStr = str;
                newStr = JSONDeformatter.GetRidOfJsonCharacters(newStr);
                while (true)
                {
                    labelIndex = newStr.IndexOf(label + ":");
                    if (labelIndex == -1)
                    {
                        if (values.Count > 0)
                        {
                            return values;
                        }
                        return null;
                    }
                    newStr = newStr.Remove(0, labelIndex + label.Length + 1);
                    int commaIndex = newStr.IndexOf(",");
                    if (commaIndex > -1)
                    {
                        values.Add(newStr.Substring(0, commaIndex));
                        newStr = newStr.Substring(commaIndex + 1);
                    }
                    else
                    {
                        if (values.Count > 0)
                        {
                            return values;
                        }
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
