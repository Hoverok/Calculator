//This is a generic calculator using C#

using System;


namespace Calculator
{
    class Program
    {
        static void Main()
        {
            double rez = 10, var1; // rez keeps track of the result, var1 used for operations
            string CalcOperator; // reads the operator as a string
           

            Console.WriteLine("Welcome to a generic calculator application");
            Console.WriteLine("The current result is {0}, what operation would you like to do?", rez);
            CalcOperator = Console.ReadLine().ToUpper(); //ToUpper capitalizes all the letters, helps with error handling
            var1 = double.Parse(Console.ReadLine());
          

            switch (CalcOperator)
            {
                case "ADD":
                    rez = Program.Add(rez, var1);
                    break;
                case "SUBTRACT":
                    rez = Program.Subtract(rez, var1);
                    break;
                case "DIVIDE":
                    rez = Program.Divide(rez, var1);
                    break;
            }
            Console.WriteLine(rez);
        }

        /*
 •	Add <number> - adds a number to the result
•	Subtract <number> - subtracts number from the result
•	Divide <number> - divides result by the number
•	Times <number> - multiples number by the result 
•	Power <number> - rises the result by power of number
•	Root <number> - finds the base number of the result raised in power by number
•	Clear – Makes result a 0
•	Negative – Changes result to negative
•	Positive – Changes result to positive
•	Help – Shows all possible commands and descriptions

         */

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b) {
            return a - b;
            }
        public static double Divide(double a, double b)
        {
            // need to make sure b!=0
            if (b != 0) return a / b;
            else
            {
                Console.WriteLine("Cannot divide by 0!");
                return a;
            }
        }

    }
}
