using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Converters
{
    internal class DifficultyConverter
    {
        public static string ToDifficulty(int bits)
        {
            switch (bits)
            {
                case 4: return "easy";
                case 6: return "medium";
                case 8: return "hard";
                case 10: return "extreme";
                default: return "";
            }
        }
    }
}
