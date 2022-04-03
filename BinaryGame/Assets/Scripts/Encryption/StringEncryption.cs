using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Scripts.Encryption
{
    public static class StringEncryption
    {
        public static string[] LetterPlacements { get; private set; } = new string[]
       {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",

            "!", "0", ".", "1", "#", "2", "{", "3", ")", "4", ";", "5", "/",
            "'", "6", "~", "7", "8", "%", "9", ">", "-", "<", "?",
            "*", "@", "£", "$", "^", "}", "(", "_", "+", "=", "|", "`", "[",
            " ", "]",

             "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

           "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",

           "!", "0", ".", "1", "#", "2", "{", "3", ")", "4", ";", "5", "/",
            "'", "6", "~", "7", "8", "%", "9", ">", "-", "<", "?",
            "*", "@", "£", "$", "^", "}", "(", "_", "+", "=", "|", "`", "[",
            " ", "]",

           "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
            "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",

           "!", "0", ".", "1", "#", "2", "{", "3", ")", "4", ";", "5", "/",
            "'", "6", "~", "7", "8", "%", "9", ">", "-", "<", "?",
            "*", "@", "£", "$", "^", "}", "(", "_", "+", "=", "|", "`", "[",
            " ", "]",

           "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
       };
        public static string EncryptStringAndTurnIntoBinary(string key, string originalStringToEncrypt, long additionalNumberDisplacement = 93467159)
        {
            string newString = EncryptStringWithoutConversion(key, originalStringToEncrypt, additionalNumberDisplacement);
            string newStringAsBinary = "";
            foreach (char character in newString)
            {
                if (Convert.ToString(character, 2).Length == 7)
                {
                    newStringAsBinary += Convert.ToString(character, 2);
                }
                else
                {
                    for (int i = Convert.ToString(character, 2).Length; i < 7; i++)
                    {
                        newStringAsBinary += "0";
                    }
                    newStringAsBinary += Convert.ToString(character, 2);
                }
            }
            if (newStringAsBinary != null)
            {
                newStringAsBinary.Reverse();
            }
            return newStringAsBinary;
        }
        public static string EncryptStringAndturnIntoBytes(string key, string originalStringToEncrypt, long additionalNumberDisplacement = 93467159)
        {
            string newString = EncryptStringWithoutConversion(key, originalStringToEncrypt, additionalNumberDisplacement);
            byte[] newStringAsbytes = Encoding.ASCII.GetBytes(newString);
            string newStringAsBytesInString = "";
            for (int i = 0; i < newStringAsbytes.Length; i++)
            {
                if (newStringAsbytes[i].ToString().Length == 3)
                {
                    newStringAsBytesInString += newStringAsbytes[i].ToString();
                }
                else
                {
                    for (int zeros = newStringAsbytes[i].ToString().Length; zeros < 3; zeros++)
                    {
                        newStringAsBytesInString += "0";
                    }
                    newStringAsBytesInString += newStringAsbytes[i].ToString();
                }
            }
            return newStringAsBytesInString;
        }
        public static string EncryptStringWithoutConversion(string key, string originalStringToEncrypt, long additionalNumberDisplacement = 93467159)
        {
            int currentLetter = 0;
            string newString = "";
            string additionalNumberDisplacementAsString = additionalNumberDisplacement.ToString();
            int[] encryptionShift = new int[originalStringToEncrypt.Length];
            int numberDisplacementLetter = 0;
            while (currentLetter < originalStringToEncrypt.Length)
            {
                if (additionalNumberDisplacementAsString.Length > key.Length)
                {
                    int keyLetter = 0;
                    for (numberDisplacementLetter = 0; numberDisplacementLetter < additionalNumberDisplacementAsString.Length - 1; numberDisplacementLetter++)
                    {
                        encryptionShift[currentLetter] = (Array.IndexOf(LetterPlacements, key[keyLetter].ToString()) + Convert.ToInt32(additionalNumberDisplacementAsString[numberDisplacementLetter].ToString()));
                        if (Array.IndexOf(LetterPlacements, key[keyLetter].ToString()) == -1)
                        {
                            Console.WriteLine("symbol not found");
                            return "";
                        }
                        keyLetter++;
                        if (keyLetter >= key.Length - 1)
                        {
                            keyLetter = 0;
                        }
                        currentLetter++;
                        if (currentLetter == encryptionShift.Length)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int keyLetter = 0; keyLetter < key.Length - 1; keyLetter++)
                    {

                        encryptionShift[currentLetter] = (Array.IndexOf(LetterPlacements, key[keyLetter].ToString()) + Convert.ToInt32(additionalNumberDisplacementAsString[numberDisplacementLetter].ToString()));
                        numberDisplacementLetter++;
                        if (numberDisplacementLetter == additionalNumberDisplacementAsString.Length - 1)
                        {
                            numberDisplacementLetter = 0;
                        }
                        currentLetter++;
                        if (currentLetter >= encryptionShift.Length)
                        {
                            break;
                        }
                    }

                }
            }
            for (int i = 0; i < originalStringToEncrypt.Length; i++)
            {
                newString += LetterPlacements[Array.IndexOf(LetterPlacements, originalStringToEncrypt[i].ToString()) + encryptionShift[i] + 1];
            }
            return newString;
        }
        public static string DecryptStringAndReverseFromBinary(string key, string stringToDecrypt, long additionalNumberDisplacement = 93467159)
        {
            string newString = "";
            int currentCharAsByte = 0;
            int bitValue = 1;
            char[] newStringAsByte = new char[stringToDecrypt.Length / 7];
            bool exitNestedForLoops = false;
            while (!exitNestedForLoops)
            {
                for (int i = 0; ; i++)
                {
                    for (int currentByte = 6; currentByte >= 0; currentByte--)
                    {
                        if (currentByte >= stringToDecrypt.Length)
                        {
                            exitNestedForLoops = true;
                            break;
                        }
                        if (stringToDecrypt[currentByte].ToString().Equals("0"))
                        {

                        }
                        else
                        {
                            currentCharAsByte += bitValue;
                        }
                        bitValue *= 2;
                    }
                    if (stringToDecrypt.Length > 6)
                    {
                        stringToDecrypt = stringToDecrypt.Remove(0, 7); // length of a byte
                    }
                    else
                    {
                        exitNestedForLoops = true;
                        break;

                    }
                    newStringAsByte[i] = (char)currentCharAsByte;
                    currentCharAsByte = 0;
                    bitValue = 1;
                }
            }
            for (int i = 0; i < newStringAsByte.Length; i++)
            {
                newString += newStringAsByte[i];
            }
            string decryptedString = DecryptStringWithoutConversion(key, newString, additionalNumberDisplacement);
            decryptedString.Reverse();
            return decryptedString;
        }
        public static string DecryptStringAndReverseFromBytes(string key, string stringToDecrypt, long additionalNumberDisplacement = 93467159)
        {
            string[] stringToDecryptAsIndividualStringOfBytes = new string[(int)Math.Round(Convert.ToDouble(stringToDecrypt.Length) / 3)];

            for (int i = 0; i < stringToDecrypt.Length; i += 3)
            {
                stringToDecryptAsIndividualStringOfBytes[i / 3] = stringToDecrypt.Substring(i, 3);
            }
            byte[] bytes = new byte[stringToDecryptAsIndividualStringOfBytes.Length];
            for (int i = 0; i < stringToDecryptAsIndividualStringOfBytes.Length; i++)
            {
                bytes[i] = (byte)Convert.ToInt16(stringToDecryptAsIndividualStringOfBytes[i]);
            }
            stringToDecrypt = Encoding.ASCII.GetString(bytes);
            string newString = DecryptStringWithoutConversion(key, stringToDecrypt, additionalNumberDisplacement);
            return newString;
        }
        public static string DecryptStringWithoutConversion(string key, string stringToDecrypt, long additionalNumberDisplacement = 93467159)
        {
            int currentLetter = 0;
            string newString = "";
            string additionalNumberDisplacementAsString = additionalNumberDisplacement.ToString();
            int[] encryptionShift = new int[stringToDecrypt.Length];
            int numberDisplacementLetter = 0;
            while (currentLetter < stringToDecrypt.Length)
            {
                if (additionalNumberDisplacementAsString.Length > key.Length)
                {
                    int keyLetter = 0;
                    for (numberDisplacementLetter = 0; numberDisplacementLetter < additionalNumberDisplacementAsString.Length - 1; numberDisplacementLetter++)
                    {
                        encryptionShift[currentLetter] = (Array.IndexOf(LetterPlacements, key[keyLetter].ToString()) + Convert.ToInt32(additionalNumberDisplacementAsString[numberDisplacementLetter].ToString()));
                        keyLetter++;
                        if (keyLetter >= key.Length - 1)
                        {
                            keyLetter = 0;
                        }
                        currentLetter++;
                        if (currentLetter == encryptionShift.Length)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int keyLetter = 0; keyLetter < key.Length - 1; keyLetter++)
                    {

                        encryptionShift[currentLetter] = (Array.IndexOf(LetterPlacements, key[keyLetter].ToString()) + Convert.ToInt32(additionalNumberDisplacementAsString[numberDisplacementLetter].ToString()));
                        numberDisplacementLetter++;
                        if (numberDisplacementLetter == additionalNumberDisplacementAsString.Length - 1)
                        {
                            numberDisplacementLetter = 0;
                        }
                        currentLetter++;
                        if (currentLetter >= encryptionShift.Length)
                        {
                            break;
                        }
                    }

                }
            }
            for (int i = 0; i < stringToDecrypt.Length; i++)
            {
                int index = Array.IndexOf(LetterPlacements, stringToDecrypt[i].ToString()) + 182 - encryptionShift[i] - 1;
                if (index != -1)
                {
                    newString += LetterPlacements[index];
                }
                else
                {
                    return "";
                }
            }
            return newString;

        }
    }

}
