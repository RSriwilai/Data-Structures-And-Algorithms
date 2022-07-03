using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_And_Algorithm.CodingProblems
{
    public class LeetCodeProblems
    {

        //******************EASY PROBLEMS******************
        //Problem Nr 12
        public static int RomanToInt(string s)
        {
            var romanNums = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            char[] ch = s.ToUpper().ToCharArray();
            int result = 0;
            int intValue, nextIntValue;

            for (int i = 0; i < ch.Length; i++)
            {
                intValue = romanNums[ch[i]];

                if (i != ch.Length - 1)
                {
                    nextIntValue = romanNums[ch[i + 1]];

                    if (nextIntValue > intValue)
                    {
                        intValue = nextIntValue - intValue;
                        i = i + 1;
                    }
                }
                result = result + intValue;
            }
            return result;
        }

    }
}
