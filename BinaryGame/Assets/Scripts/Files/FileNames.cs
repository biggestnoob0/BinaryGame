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
        public static string practiceFile = Application.persistentDataPath + @"\practice\highscores" + PracticeOverMechanics.difficulty + ".txt";
        public static string loginDetails = Application.persistentDataPath + @"\user" + ".txt";
        public static string loginTimesCheck = Application.persistentDataPath + @"\login" + ".txt";
        public static string practiceDir = Application.persistentDataPath + @"\practice";
        public static string dir = Application.persistentDataPath;
    }
}
