using System;

namespace IntegerToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read an integer from the console
            Console.WriteLine("Enter an integer (-9999 to 9999):");
            int num = int.Parse(Console.ReadLine());

            string words = IntegerToWords(num);

            Console.WriteLine("The integer in words is: " + words);
        }

        public static string IntegerToWords(int num)
        {
            if (num == 0)
            {
                return "zero";
            }

            if (num < 0)
            {
                return "negative " + IntegerToWords(Math.Abs(num));
            }

            string words = "";

            if ((num / 1000) > 0)
            {
                words += IntegerToWords(num / 1000) + " thousand ";
                num %= 1000;
            }

            if ((num / 100) > 0)
            {
                words += IntegerToWords(num / 100) + " hundred ";
                num %= 100;
            }

            if (num > 0)
            {
                if (words != "")
                {
                    words += "and ";
                }

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (num < 20)
                {
                    words += unitsMap[num];
                }
                else
                {
                    words += tensMap[num / 10];
                    if ((num % 10) > 0)
                    {
                        words += "-" + unitsMap[num % 10];
                    }
                }
            }

            return words;
        }
    }
}
