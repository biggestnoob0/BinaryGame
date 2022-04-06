using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;
using Assets.Scripts.Encryption;

namespace Assets.Scripts.Files
{
    class FileIO
    {
        /// <summary>
        /// Writes the input to the specified file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="fileName"></param>
        public static void WriteLine<T>(T input, string fileName, string dir, string encryptionKey = "")
        {
            if (input.GetType() == typeof(string) || input.GetType() == typeof(int))
            {
                // uses encrypted string to write if above statement is true
                string newInput = StringEncryption.EncryptStringWithoutConversion(encryptionKey, (string)(object)input);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (!File.Exists(fileName))
                {
                    FileStream file = File.Create(fileName);
                    file.Close();
                }
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(newInput.ToString());
                    sw.Close();
                }
                return;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!File.Exists(fileName))
            {
                FileStream file = File.Create(fileName);
                file.Close();
            }
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(input.ToString());
                sw.Close();
            }
        }
        public static void WriteLines<T>(T[] inputs, string fileName, string dir, string encryptionKey = "")
        {
            if (inputs.GetType() == typeof(string) || inputs.GetType() == typeof(int))
            {
                // uses encrypted string to write if above statement is true
                string[] newInputs = new string[inputs.Length];
                for (int i = 0; i < inputs.Length; i++)
                {
                    newInputs[i] = StringEncryption.EncryptStringWithoutConversion(encryptionKey, (string)(object)inputs[i]);
                }
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                if (!File.Exists(fileName))
                {
                    FileStream file = File.Create(fileName);
                    file.Close();
                }
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    for (int i = 0; i < inputs.Length; i++)
                    {
                        sw.WriteLine(newInputs[i].ToString());
                    }
                }
                return;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!File.Exists(fileName))
            {
                FileStream file = File.Create(fileName);
                file.Close();
            }
            using (StreamWriter sw = File.AppendText(fileName))
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    sw.WriteLine(inputs[i].ToString());
                }
            }
        }
        public static void ReplaceFile(string fileName, string dir)
        {
            if (Directory.Exists(dir))
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    FileStream fs = File.Create(fileName);
                    fs.Close();
                }
            }
        }
        public static List<string> ReadTextFile(string fileName, string dir, string encryptionKey)
        {
            Debug.Log(fileName);
            if (!Directory.Exists(dir))
            {
                return null;
            }
            if (File.Exists(fileName))
            {
                List<string> lines = new List<string>();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (!encryptionKey.Equals(""))
                    {
                        while (!sr.EndOfStream)
                        {
                            lines.Add(StringEncryption.DecryptStringWithoutConversion(encryptionKey, sr.ReadLine()));
                        }
                    }
                    else
                    {
                        lines.Add(sr.ReadLine());
                    }
                }
                return lines;
            }
            else
            {
                return null;
            }
        }
    }
}
