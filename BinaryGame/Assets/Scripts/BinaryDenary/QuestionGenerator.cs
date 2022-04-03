using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BinaryDenary
{
    static class QuestionGenerator
    {
        public static Question GenerateQuestion()
        {
            Random random = new Random();
            string questionType = QuestionType(random.Next(2));
            //generates max value from the amount of bits being used
            int max = BinaryConverter.BinaryDigitsToMaxDenaryValue(PracticeGameMechanics.bits);
            int denary = random.Next(1, max);
            string binary = BinaryConverter.DenaryToBinary(denary);
            if (questionType.Equals("binary"))
            {
                // generates new random binary question
                return new BinaryQuestion(binary, denary);
            }
            else if (questionType.Equals("denary"))
            {
                //generates new random denary question
                return new DenaryQuestion(denary, binary);
            }
            else
            {
                return null;
            }
        }
        public static string QuestionType(int number)
        {
            if (number == 0)
            {
                return "denary";
            }
            else if (number == 1)
            {
                return "binary";
            }
            else
            {
                return null;
            }
        }
    }
}
