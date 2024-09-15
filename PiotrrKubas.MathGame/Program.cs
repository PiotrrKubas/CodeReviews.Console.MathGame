using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using static System.Random;

namespace PiotrrKubas.MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gameHistory = new List<string>();

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
                    Console.WriteLine("Pick you game mode:");
                    Console.WriteLine("Addition - \'+\'");
                    Console.WriteLine("Substraction - \'-\'");
                    Console.WriteLine("Multiplication - \'*\'");
                    Console.WriteLine("Division - \'/\'");
                    Console.WriteLine("5 Random Games - \'R\'");
                    Console.WriteLine("Difficulty \'D\'");
                    Console.WriteLine("Score - \'S\'");
                    Console.WriteLine("Game history - \'H\'");
                    Console.WriteLine("Exit - \'E\'");

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

                do
                {
                    Console.WriteLine("Enter your result, result must be an integer:");
                    userInput = Console.ReadLine();
                } while (!(int.TryParse(userInput, out _)));

                if (userInput !=null && int.Parse(userInput) == result) 
                {
                    Console.WriteLine("Score +10");
                    score += 10;
                    gameHistory.Add($"{a} {mathOperator} {b} = {result} \tYour answer: {userInput} \t\t\tYou were right!\t");
                    Console.ReadLine();
                }
                else 
                {
                    gameHistory.Add($"{a} {mathOperator} {b} = {result} \tYour answer: {userInput} \t\t\tYou were wrong!\t");
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
                Console.WriteLine("Easy - \'1\'");
                Console.WriteLine("Medium - \'2\'");
                Console.WriteLine("Hard - \'3\'");

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
