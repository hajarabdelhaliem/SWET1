using System;

class Calculator
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter operator (+, -, *, /): ");
                char op = Convert.ToChar(Console.ReadLine());

                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = 0;
                bool validOperation = true;

                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 == 0)
                        {
                            Console.WriteLine("Error: Division by zero is not allowed.");
                            validOperation = false;
                        }
                        else
                        {
                            result = num1 / num2;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operator. Please use +, -, *, or /.");
                        validOperation = false;
                        break;
                }

                if (validOperation)
                {
                    Console.WriteLine($"Result: {result}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numbers correctly.");
            }

            Console.Write("Do you want to perform another calculation? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }

}