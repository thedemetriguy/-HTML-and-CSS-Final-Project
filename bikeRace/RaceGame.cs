using System;
namespace CrazyBiker
{
    public class RaceGame
    {
        public int Size {get;set;}
        public int EndingPoint {get;set;}
        public string[] Name {get;set;}
        public int[] Position {get;set;}
        public char[]? DisplayChar {get;set;}
        public bool? Winner {get;set;}
        public int WinnerNumber {get;set;}
        public static int? Rounds {get; set;}
        public bool GameOver {get; set;}

        static RaceGame ()
        {
            Rounds = 0;
        }

        public RaceGame ()
        {
            Size = 0;
            EndingPoint = 0;
            Name = null;
            Position = null;
            DisplayChar = null;
            Winner = false;
            WinnerNumber = 0;
            GameOver = false;
        }

        public RaceGame (int size, int endingPoint, string[] name, int[] position, char[] displayChar, bool winner, int winnerNumber, bool gameOver)
        {
            Size = size;
            EndingPoint = endingPoint;
            Name = name;
            Position = position;
            DisplayChar = displayChar;
            Winner = winner;
            WinnerNumber = winnerNumber;
            GameOver = gameOver;
        }

        public void AddNames ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < Name.Length; i++)
            {
                Console.Write($"Name:");
                string tempName = Console.ReadLine();
                while (String.IsNullOrEmpty(tempName) || String.IsNullOrWhiteSpace(tempName))
                {
                    Console.WriteLine("You have entered an invalid name, please try again");
                    tempName = Console.ReadLine();
                }
                Name[i] = tempName;
            }
            Console.WriteLine("The contestants have been registered.");
        }

        public void AddDisplayChar ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < DisplayChar.Length; i++)
            {
                Console.Write($"Enter a print character for {Name[i]}  ");
                string tempChar = Console.ReadLine();
                while (String.IsNullOrEmpty (tempChar) || String.IsNullOrWhiteSpace (tempChar) || tempChar.Length != 1)
                {
                    Console.WriteLine("Please enter a valid single character!");
                    tempChar = Console.ReadLine();
                }
                DisplayChar[i] = Convert.ToChar(tempChar);
            }
            Console.WriteLine("The contestants are ready to race...");
        }

        public void PrintRounds ()
        {
            Rounds++;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n\n--------------------Round# {Rounds}--------------------------\n");
        }
        
        public void ChangePositions (Random rand)
        {
            for (int i = 0; i < Position.Length; i++)
            {
                Position[i] += rand.Next(1,11);
            }
        }

        public void RoundResults ()
        {
            Console.WriteLine();
            for (int i = 0; i < Size; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{Name[i]}: ");
                for (int distance = 0; distance < Position[i]; distance++)
                {
                    Console.Write(DisplayChar[i]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\nPress enter to continue or 'q' to quit: ");
            string enter = Console.ReadLine();
            if (!string.IsNullOrEmpty(enter) && enter.Trim().ToLower() == "q")
            {
                GameOver = true;
            }
            Console.Clear();
            return;
        }

        public void CheckForWinner ()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < Position.Length && Winner == false; i++)
            {
                if (Position[i] >= EndingPoint)
                {
                    Winner = true;
                    WinnerNumber = i;
                    Console.WriteLine("********************News Flash********************");
                    Console.WriteLine("                We have a winner...               ");
                    Console.WriteLine("**************************************************");
                    Console.WriteLine();
                    continue;
                }
            }
        }

        public void DisplayResults ()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*************************************************************");
            Console.WriteLine($"   The winner is {Name[WinnerNumber]} with a score of {Position[WinnerNumber]}   ");
            Console.WriteLine("*************************************************************");
            Console.WriteLine();
            Console.WriteLine($"--------------------Result Summary-------------------------");
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine($"\tBiker: {Name[i]}   \tScore: {Position[i]} ");
            }
        }
    }
}