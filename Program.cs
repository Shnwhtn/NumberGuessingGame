using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    class Program
    {
        //Variables
        static double guess;
        static bool switchBetweenHigherLower = false;
        static double low = 1;
        static double high = 100;

        //This method replaces if the guess should replace the lower or higher range
        public static void workOutNumberRange(bool HigherOrLower, string yesOrNo)
        {
            if (((HigherOrLower) & (yesOrNo == "y")) | ((!HigherOrLower) & (yesOrNo == "n")))
            {
                high = guess;
            }
            else
            {
                low = guess;
            }
        }

        //THis method deals with if the number is greater or less than
        public static void isNumberThan(double low, double high, bool switchOnHigherLower)
        {
            double math;
            // Round up
            math = (low + high) / 2;
            guess = Math.Ceiling(math);
            if (switchOnHigherLower)
            {
                Console.WriteLine("\nIs Number Greater Than " + guess+"?\n");
                switchBetweenHigherLower = false;
            }
            else
            {
                Console.WriteLine("\nIs Number Less Than " + guess+"?\n");
                switchBetweenHigherLower = true;
            }
        }


        static void Main(string[] args)
        {
            string higherorlower;

            Console.WriteLine("Choose a number between 1 and 100");
            bool active = true;
            int count = 0;
            ConsoleKeyInfo keypress;
            while (active)
            {
                isNumberThan(low,high,switchBetweenHigherLower);
                keypress = Console.ReadKey();
                switch(keypress.Key)
                {
                    case ConsoleKey.Y:
                        workOutNumberRange(switchBetweenHigherLower, "y");
                        break;
                    case ConsoleKey.N:
                        workOutNumberRange(switchBetweenHigherLower, "n");
                        break;
                }
                count++;
                if(count==7)
                {
                    //if last input was lower then the number range end is the low, else high if the 
                    //low and high number have one digit between them, else its another in the range
                    if ((high - low == 1)&(!switchBetweenHigherLower))
                    {
                        Console.WriteLine("\nYour Number Was " + low);
                    }
                    else if ((high - low == 1) & (switchBetweenHigherLower))
                    {
                        Console.WriteLine("\nYour Number Was " + high);
                    }
                    else
                    {
                        Console.WriteLine("\nYour Number Was " + ((low + high) / 2));
                    }
                    active = false;
                }
            }
            Console.ReadLine();
        }
    }
}
