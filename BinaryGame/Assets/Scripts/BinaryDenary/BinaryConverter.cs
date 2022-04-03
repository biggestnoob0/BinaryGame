using System;
using System.Linq;

static class BinaryConverter
{
    public static string DenaryToBinary(int denary)
    {
        string binary = "";
        while (denary > 0)
        {
            //finds remainder
            int remainder = denary % 2;
            //divides number by 2 and adds the remainder to string
            denary /= 2;
            binary += remainder.ToString();
        }
        return ReverseString(binary);
    }
    public static int BinaryToDenary(string binary)
    {
        int denary = 0;
        int multipler = 1;
        string binaryReversed = (string)binary.Reverse();
        for (int i = 0; i < binary.Length; i++)
        {
            if (binaryReversed[i].Equals('1'))
            {
                denary += multipler;
            }
        }
        return denary;
    }
    public static int BinaryDigitsToMaxDenaryValue(int binaryDigits)
    {
        return (int)(Math.Pow(2, binaryDigits) - 1);
    }
    public static string ReverseString(string str)
    {
        int length = str.Length;
        string newStr = "";
        for(int i = length - 1; i >= 0; i--)
        {
            newStr += str[i];
        }
        return newStr;
    }
}
