using System;
using static System.Random;

namespace PiotrrKubas.MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int a = 0;
            int b = 0;
            int randomMin = 1;
            int randomMax = 100;
            int score = 0;
            int result = 0;

            char menuSelector = ' ';
            string userInput;

            while (menuSelector != 'e') 
            {
                PrintMenu();
                menuSelector = Console.ReadLine().ToLower()[0];


                switch (menuSelector)
                {
                    case '+' or '-' or '*' or '/':
                        MathOperation(menuSelector);
                        break;
                    case 'e':
                        break;
                        Environment.Exit(0);
                    case 'd':
                        Console.WriteLine("Select difficulty:");
                        Console.WriteLine("Easy - \'1\'");
                        Console.WriteLine("Medium - \'2\'");
                        Console.WriteLine("Hard - \'3\'");
                        menuSelector = Console.ReadLine().ToLower()[0];

                        switch (menuSelector)
                        {
                            case '1':
                                randomMin = 0; randomMax = 10;
                                break;
                            case '2':
                                randomMin = 0; randomMax = 30;
                                break;
                            case '3':
                                randomMin = -30; randomMax = 30;
                                break;
                            default:
                                Console.WriteLine("wrong number");
                                break;
                        }
                        break;

                }
                Console.ReadLine();


            }

            void PrintMenu()
            {
                Console.WriteLine("Pick you game mode:");
                Console.WriteLine("Addition - \'+\'");
                Console.WriteLine("Substraction - \'-\'");
                Console.WriteLine("Multiplication - \'*\'");
                Console.WriteLine("Division - \'/\'");
                Console.WriteLine("Difficulty \'D\'");
                Console.WriteLine("Score - \'S\'");
                Console.WriteLine("Exit - \'E\'");
            }
            
            void MathOperation(char mathOperator)
            {
                Console.Clear();



                switch (mathOperator) 
                {
                    case '+':
                        GenerateNumber(mathOperator);
                        Console.WriteLine($"{a} + {b} = ?");
                        result = a + b;
                        break;
                    case '-':
                        GenerateNumber(mathOperator);
                        Console.WriteLine($"{a} - {b} = ?");
                        result = a - b;
                        break;
                    case '*':
                        GenerateNumber(mathOperator);
                        Console.WriteLine($"{a} * {b} = ?");
                        result = a * b;
                        break;
                    case '/':
                        GenerateNumber(mathOperator);
                        Console.WriteLine($"{a} / {b} = ?");
                        result = a / b;
                        break;
                }

                
                userInput = Console.ReadLine();
                if (int.Parse(userInput) !=null && int.Parse(userInput) == result) 
                {
                    Console.WriteLine("Score +10");
                    score += 10;
                }
                else 
                {
                    Console.WriteLine("Wrong answer");
                }
            }

            void GenerateNumber(char mathOperator)
            {
                if (mathOperator == '/')
                {
                    do
                    {
                        a = random.Next(randomMin, randomMax);
                        b = random.Next(randomMin, randomMax);
                    } while (a % b != 0 && a + b != 0);
                }
                else
                {
                    a = random.Next(randomMin, randomMax);
                    b = random.Next(randomMin, randomMax);
                }

            }
        }

    }
}
