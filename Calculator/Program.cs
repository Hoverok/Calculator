//This is a generic calculator using C#

using System;


namespace Calculator
{
    class Program
    {
        static void Main()
        {
            double rez = 0, var1; // rez keeps track of the result, var1 used for operations
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
                case "SUB":
                    rez = Program.Sub(rez, var1);
                    break;
            }
            Console.WriteLine(rez);
        }
     

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Sub (double a, double b) {
            return a - b;
            }
    }
}
