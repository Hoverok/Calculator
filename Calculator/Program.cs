//This is a generic calculator using C#

using System;


namespace Calculator
{
    class Program
    {
        static void Main()
        {
            double rez = 0, var1 = 0; // rez keeps track of the result, var1 used for operations
            string CalcOperator = " "; // reads the operator as a string
             


            Console.WriteLine("Welcome to a generic calculator application");
            do
            {
                Console.WriteLine("The current result is {0} \nWhat operation would you like to do?", rez);
                string[] tokens = Console.ReadLine().Split(); //reads input into an array of strings and splits on space


                if (tokens.Length == 1)
                {

                    CalcOperator = tokens[0].ToUpper();
                    Console.WriteLine("{0}", CalcOperator);
                }
                else if (tokens.Length == 2)
                {
                    CalcOperator = tokens[0].ToUpper();
                    var1 = double.Parse(tokens[1]);
                    Console.WriteLine("{0} {1}", CalcOperator, var1);
                }
                    /*CalcOperator = Console.ReadLine().ToUpper(); //ToUpper capitalizes all the letters, helps with error handling
                    if (CalcOperator != "CLEAR" && CalcOperator != "POSITIVE" && CalcOperator != "NEGATIVE" && CalcOperator != "HELP")
                    {
                        var1 = double.Parse(Console.ReadLine());
                    }
                    */
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
                    case "TIMES":
                        rez = Program.Multiply(rez, var1);
                        break;
                    case "POWER":
                        rez = Program.Power(rez, var1);
                        break;
                    case "ROOT":
                        rez = Program.Root(rez, var1);
                        break;
                    case "CLEAR":
                        rez = 0;
                        break;
                    case "POSITIVE":
                        rez = Program.Positive(rez);
                        break;
                    case "NEGATIVE":
                        rez = Program.Negative(rez);
                        break;
                    case "HELP":
                        Program.Help();
                        break;
                    default:
                        Console.WriteLine("Invalid command or a typo");
                        break;
                }
                Console.Clear();
                
            } while (true);
}
    

        public static double Add(double a, double b)
        {
            return a + b;
        }

        //SUBTRACT
        public static double Subtract(double a, double b) {
            return a - b;
            }

        //DIVIDE
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

        //MULTIPLY
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        //POWER
        public static double Power(double a, double b)
        {   //I am fully aware that Math.Pow() exists
            //With this solution I can show for loops and logical thinking

            //3 scenarios:
            //b > 0, b = 0, b < 0
            //b needs to be an integer value
            double temp = a; // stores the initial rezult
            if (b > 0)
            {
                for (int i = 1; i < b; i++)
                {
                    a = a * temp;
                }
            }
            else if (b == 0)
            {
                a = 1; // a^0 = 1
            }
            else if (b < 0)
            {
                // switching numerator and denominator, for example 10^-1 = 0.1
                // 10^1 = 10, 25^1 = 25
                // 10^-1 = 1/10 = 0.1, 25^-1 = 1/25 = 0.04
                a = 1 / a; // a = a^-1
                temp = a;
               
                for (int i = -1; i > b; i--)
                {
                    a = a * temp;
                }
            }
            return a;
        }

        //ROOT
        public static double Root(double a, double b)
        {   //rules
            //1) b > 0 and needs to be an integer value
            //2) if a (rez) is negative, b (root) has to be an odd number


            //if b is not an integer {WriteLine b has to be an integer value!}
            int b_temp =  (int)b;
            double b_check = b - b_temp;
            if (b_check != 0)
            {
                Console.WriteLine("Root needs to be an integer value!");
                return a;
            }

            if (b <= 0)
            {
                Console.WriteLine("Root value cannot be equal to or less than 0");
                return a;
            }

            //Math.pow will not do operations with negative numbers
            if (a < 0)  //if a (rez) is negative 
            {
                if (b % 2 == 1) //if b(power) is odd
                {
                    double temp_a = a * -1; //making a positive
                    a = Math.Pow(temp_a, 1 / b);
                    a *= -1;  //returning it to being negative
                    return a;
                }
                else
                {
                    Console.WriteLine("Negative number cannot have an even root");
                    return a;
                }
            }

            else  //if a(rez) is positive
            {
                return Math.Pow(a, 1 / b);
            }
        }
        //Positive
        public static double Positive(double a)
        {
            if (a >= 0) return a;
            else return a * -1;
        }

        //Negative
        public static double Negative(double a)
        {
            if (a <= 0) return a;
            else return a * -1;
        }
        public static void Help()
        {
            Console.Clear();
            Console.WriteLine("You have selected help, there will be description!\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
