using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class BinaryQuestion : Question
    {
        public BinaryQuestion(string _value, int answer)
        {
            Type = "binary";
            BinaryValue = _value;
            DenaryValue = answer;

        }
    }
}
