using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Hello");
            Console.WriteLine("1. Play Dice Game ");
            Console.WriteLine("2. Student Information ");
            Console.WriteLine("3. Exit");
            Console.Write("\nSelect an option (1-3): ");

            string choice = Console.ReadLine();

            Console.Clear();
            switch (choice)
            {
                case "1":
                    RunDiceGame();
                    break;
                case "2":
                    RunStudentInformation();
                    break;
                case "3":
                    keepRunning = false;
                    Console.WriteLine("Goodbye!");
                    continue;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    continue;
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }

    static void RunDiceGame()
    {
        Console.WriteLine("=== Dice Game (Imperative) ===\n");

        Random random = new Random();
        int playerRoll = 0;
        int computerRoll = 0;
        bool hasWinner = false;

        while (!hasWinner)
        {
            playerRoll = random.Next(1, 7);
            computerRoll = random.Next(1, 7);

            Console.WriteLine($"You rolled: {playerRoll}");
            Console.WriteLine($"Computer rolled: {computerRoll}");

            if (playerRoll > computerRoll)
            {
                Console.WriteLine("\n--> Congratulations! You win!");
                hasWinner = true;
            }
            else if (computerRoll > playerRoll)
            {
                Console.WriteLine("\n--> The computer wins!");
                hasWinner = true;
            }
            else
            {
                Console.WriteLine("--> It's a tie! Re-rolling...\n");
            }
        }
    }

    static void RunStudentInformation()
    {
        Console.WriteLine("=== Student Information System (Declarative) ===\n");

        List<double> grades = Enumerable.Range(1, 5)
            .Select(i =>
            {
                double grade;
                Console.Write($"Enter grade {i}: ");
                while (!double.TryParse(Console.ReadLine(), out grade))
                {
                    Console.Write($"Invalid input. Please enter a valid number for grade {i}: ");
                }
                return grade;
            })
            .ToList();

        double maxGrade = grades.Max();
        double minGrade = grades.Min();
        double averageGrade = grades.Average();

        Console.WriteLine("\n--- Grade Summary ---");
        Console.WriteLine($"Grades Entered : {string.Join(", ", grades)}");
        Console.WriteLine($"Maximum Grade  : {maxGrade:F2}");
        Console.WriteLine($"Minimum Grade  : {minGrade:F2}");
        Console.WriteLine($"Average Grade  : {averageGrade:F2}");
    }
}