//This is a generic calculator using C#

using System;


namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(140, 40);
            double rez = 0, var1 = 0; // rez keeps track of the result, var1 used for operations
            string CalcOperator = " "; // reads the operator as a string
            bool exit = false;

            Console.WriteLine("Welcome to a generic calculator application");
            Program.Help();

            do
            {
                Console.WriteLine("Command list : ADD X, SUBSTRACT X, DIVIDE X, TIMES X, POWER X, ROOT X, CLEAR, POSITIVE, NEGATIVE, HELP, EXIT\n");
                Console.WriteLine("The current result is {0} ", rez);
                string[] tokens = Console.ReadLine().Split(); //reads input into an array of strings and splits on space

                Console.Clear();
                if (tokens.Length == 1) //if only 1 word was typed in
                {
                    CalcOperator = tokens[0].ToUpper(); //to make command input not case sensitive
                    

                    switch (CalcOperator)
                    {
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
                        case "EXIT":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid command. Type in HELP for command menu \n");
                            break;
                    }

                }
                else if (tokens.Length == 2)
                {
                    CalcOperator = tokens[0].ToUpper();
                    if (double.TryParse(tokens[1], out var1)) //check if a number was entered
                    {
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
                            default:
                                Console.WriteLine("Invalid command. Type in HELP for command menu.");
                                break;
                        }
                    }
                    else Console.WriteLine("Invalid command or operand(number needed). Type in HELP for command menu."); // if string instead of number
                }
               else Console.WriteLine("Invalid command or operand(number needed). Type in HELP for command menu."); // too many inputs (3+)
            } while (exit == false);
            Console.WriteLine("Thank you for using the calculator. Exiting the program... ");
        }
    
        //ADD
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
                Console.WriteLine("Cannot divide by 0");
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
        {   //I know that Math.Pow() exists, but with this solution I can show for loops
            

            //3 scenarios:
            //b > 0, b = 0, b < 0
            //b needs to be an integer value
            double a_temp = a; // stores the initial rezult

            //checking if the power number is an integer
            int b_temp = (int)b;
            double b_check = b - b_temp;

            if (b_check == 0) // if be is an integer
            {

                if (b > 0)
                {
                    for (int i = 1; i < b; i++)
                    {
                        a = a * a_temp;
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
                    a_temp = a;

                    for (int i = -1; i > b; i--)
                    {
                        a = a * a_temp;
                    }
                }
                return a;
            }
            else
            {
                Console.WriteLine("POWER requires an integer value as an operand. Good example : POWER 3, bad example : POWER 1.5");
                return a;
            }
      
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
                    Console.WriteLine("Negative result cannot have an even root");
                    return a;
                }
            }

            else  //if a(rez) is positive
            {
                return Math.Pow(a, 1 / b);
            }
        }
        //POSITIVE
        public static double Positive(double a)
        {
            if (a >= 0) return a;
            else return a * -1;
        }

        //NEGATIVE
        public static double Negative(double a)
        {
            if (a <= 0) return a;
            else return a * -1;
        }
        //HELP
        public static void Help()
        {
            Console.Clear();
            Console.WriteLine("Calculator's HELP MENU.\n\nCommand input is not case sensitive\n\nCOMMANDS:\n");
            Console.WriteLine("ADD command adds an operand from the current result. Requires an operand. Operand can be a double. Example : ADD 10.5\n");
            Console.WriteLine("SUBTRACT command subtracts an operand to the current result. Requires an operand. Operand can be a double. Example : SUBSTRACT 9.22\n");
            Console.WriteLine("DIVIDE command divides the current result by an operand (cannot be 0). Requires an operand. Operand can be a double. Example : DIVIDE -3.333\n");
            Console.WriteLine("TIMES command multiplies result by an operand. Requires an operand. Operand can be a double. Example : TIMES 5.242\n");
            Console.WriteLine("POWER command raises the result by power of an operand. Requires an operand. Operand has to be an integer.  Example : POWER 3\n");
            Console.WriteLine("ROOT command finds the base number of the result raised in power by an operand. Requires an operand. Operand has to be an integer.");
            Console.WriteLine("If the result is negative, the operand has to be an odd number. Example: ROOT 3\n");
            Console.WriteLine("CLEAR command resets result to 0\n");
            Console.WriteLine("NEGATIVE command changes result to negative\n");
            Console.WriteLine("POSITIVE command changes result to positive\n");
            Console.WriteLine("Press any key to use the calculator");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
