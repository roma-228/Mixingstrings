using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mixingstrings
{
    class Program
    {
        public static string Mix(string phrase1, string phrase2)
        {
            string result = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] alphabetArr = alphabet.ToCharArray();
            int maxCountPhrase1 = 0, maxCountPhrase2 = 0;
            for (int i = 0; i < alphabetArr.Length; i++)
            {
                int count1 = phrase1.Count(f => (f == alphabetArr[i]));
                if (count1 > maxCountPhrase1)
                {
                    maxCountPhrase1 = count1;
                }
                int count2 = phrase2.Count(f => (f == alphabetArr[i]));
                if (count2 > maxCountPhrase2)
                {
                    maxCountPhrase2 = count2;
                }
            }

            int max;
            if (maxCountPhrase1 > maxCountPhrase2)
            {
                max = maxCountPhrase1;
            }
            else
            {
                max = maxCountPhrase2;
            }

            for (int k = max; k > 1; --k)
            {
                string tempResult = "";
                string startText = "", middleText = "", endText = "";
                for (int i = 0; i < alphabetArr.Length; i++)
                {
                    int count1 = phrase1.Count(f => (f == alphabetArr[i]));
                    int count2 = phrase2.Count(f => (f == alphabetArr[i]));

                    if (count1 == k && count1 > count2)
                    {
                        startText = startText + "/1:" + new string(alphabetArr[i], count1);
                    }

                    if (count2 == k && count2 > count1)
                    {
                        middleText = middleText + "/2:" + new string(alphabetArr[i], count2);
                    }


                    if (count1 == count2 && count1 == k && count2 == k)
                    {
                        endText = endText + "/=:" + new string(alphabetArr[i], count2);
                    }
                    tempResult = startText + middleText + endText;
                }
                result = result + tempResult;
            }
            if (result.Length > 0)
            {
                result = result.Substring(1);
            }
            return result;
        }
        static void Main(string[] args)
        {
            string phrase1 = "my&friend&Paul has heavy hats! &";
            string phrase2 = "my friend John has many many friends &";
            Console.WriteLine(Mix(phrase1, phrase2));
            Console.ReadKey();


        }
    }
}
