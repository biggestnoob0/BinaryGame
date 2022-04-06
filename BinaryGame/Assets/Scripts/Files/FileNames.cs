using Assets.Scripts.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Files
{
    static class FileNames
    {
        public static string practiceEasyHighscores = Application.persistentDataPath + @"\practice\highscores\easy.txt";
        public static string practiceMediumHighscores = Application.persistentDataPath + @"\practice\highscores\medium.txt";
        public static string practiceHardHighscores = Application.persistentDataPath + @"\practice\highscores\hard.txt";
        public static string loginDetails = Application.persistentDataPath + @"\user" + ".txt";
        public static string loginTimesCheck = Application.persistentDataPath + @"\login" + ".txt";
        public static string practiceDir = Application.persistentDataPath + @"\practice";
        public static string dir = Application.persistentDataPath;
    }
}
