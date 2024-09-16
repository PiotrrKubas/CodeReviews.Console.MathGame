using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using static System.Random;

namespace PiotrrKubas.MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gameHistory = new List<string>();

            Stopwatch stopwatch = new Stopwatch();
            Random random = new Random();

            int a = 0;
            int b = 0;
            int randomMin = 0;
            int randomMax = 30;
            int score = 0;
            int result = 0;

            char menuSelector = ' ';
            string userInput;
            string operations = "/*-+";

            SelectDifficulty();
            Menu();     

            void Menu()
            {
                while (menuSelector != 'e')
                {
                    Console.Clear();
                    Console.WriteLine("Pick you game mode:");
                    Console.WriteLine(" '+' - Addition");
                    Console.WriteLine(" '-' - Substraction");
                    Console.WriteLine(" '*' - Multiplication");
                    Console.WriteLine(" '/' - Division");
                    Console.WriteLine(" 'R' - 5 Random Games");
                    Console.WriteLine(" 'D' - Difficulty");
                    Console.WriteLine(" 'S' - Score");
                    Console.WriteLine(" 'H' - Game history");
                    Console.WriteLine(" 'E' - Exit");

                    menuSelector = Console.ReadKey().KeyChar;
                    Console.Clear();
                    
                    switch (menuSelector)
                    {
                        case '+' or '-' or '*' or '/':
                            MathOperation(menuSelector);
                            break;
                        case 'e':
                            Environment.Exit(0);
                            break;
                        case 'd':
                            SelectDifficulty();
                            break;
                        case 's':
                            Console.WriteLine($"Your total score is: {score}");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 'h':
                            foreach (string game in gameHistory)
                            {
                                Console.WriteLine(game);
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 'r':
                            for (int i = 0; i < 5; i++)
                            { 
                                int j = random.Next(operations.Length);
                                MathOperation(operations[j]);
                            }
                            break;
                    }
                }
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

                stopwatch.Start();
                do
                {
                    Console.WriteLine("Enter your result, result must be an integer:");
                    userInput = Console.ReadLine();
                } while (!(int.TryParse(userInput, out _)));
                stopwatch.Stop();

                if (userInput !=null && int.Parse(userInput) == result) 
                {
                    Console.WriteLine("Score +10");
                    score += 10;
                    gameHistory.Add($"{a} {mathOperator} {b} = {result} \t Your answer: {userInput} \t\tYou were right!\tTime elapsed {stopwatch.Elapsed}");
                    stopwatch.Restart();
                    Console.ReadLine();
                }
                else 
                {
                    gameHistory.Add($"{a} {mathOperator} {b} = {result} \t Your answer: {userInput} \t\tYou were wrong!\tTime elapsed {stopwatch.Elapsed}");
                    stopwatch.Restart();
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
                    } while (a % b != 0 && a != 0 && b != 0);
                }
                else
                {
                    a = random.Next(randomMin, randomMax);
                    b = random.Next(randomMin, randomMax);
                }
            }

            void SelectDifficulty()
            {
                bool correctInput;
                Console.Clear();
                Console.WriteLine("Select difficulty:");
                Console.WriteLine(" '1' - Easy");
                Console.WriteLine(" '2' - Medium");
                Console.WriteLine(" '3' - Hard");

                do
                {
                    Console.WriteLine("Select difficulty by writing 1, 2 or 3");
                    menuSelector = Console.ReadKey().KeyChar;

                    switch (menuSelector)
                    {
                        case '1':
                            randomMin = 0; randomMax = 30;
                            correctInput = true;
                            break;
                        case '2':
                            randomMin = 1; randomMax = 100;
                            correctInput = true;
                            break;
                        case '3':
                            randomMin = -100; randomMax = 100;
                            correctInput = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong input, you have to select 1, 2 or 3");
                            correctInput = false;
                            break;
                    }
                } while (correctInput == false);
                Console.Clear();
            }
        }
    }
}
