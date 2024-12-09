using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace CrazyBiker
{
    internal class Program
    {
        static void Main (string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("*************************News Flash*************************");
            Console.WriteLine("Americans are about to see something incredible.");
            Console.WriteLine("Dmitry is holding a bike race in the Arizona desert to see who is the fastest. The contestants are anyone who wants to race.");
            Console.WriteLine("Whoever wins will get a brand new racing bike and will get a chance to participate in the next biking competition in New York City next spring.");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            RaceGame biker = new RaceGame();
            Console.WriteLine("How many are racing?");
            int number = ValidateNumber(Console.ReadLine());
            biker.Size = number;
            Console.WriteLine("How far are they racing? Please enter a whole number in miles");
            int miles = ValidateMiles(Console.ReadLine());
            biker.EndingPoint = miles;
            biker.Name = new string[biker.Size];
            biker.Position = new int[biker.Size];
            biker.DisplayChar = new char[biker.Size];
            biker.AddNames();
            biker.AddDisplayChar();
            var rand = new Random();
            while (biker.Winner == false)
            {
                biker.PrintRounds();
                biker.ChangePositions(rand);
                biker.RoundResults();
                if (biker.GameOver == true)
                {
                    break;
                }
                biker.CheckForWinner();
                if (biker.Winner == true)
                {
                    biker.DisplayResults();
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("     Thank you for playing. Have a great day.     ");
            Console.WriteLine("**************************************************");
            Console.WriteLine();

        }
        
        public static int ValidateNumber(string data)
        {
            int number;
            while (!int.TryParse(data, out number) || number <= 1)
            {
                Console.WriteLine("The number of racers must be a number greater than 1, please try again");
                data = Console.ReadLine();
            }
            return number;
        }

        public static int ValidateMiles(string data)
        {
            int miles;
            while (!int.TryParse(data, out miles) || miles <= 0 || miles > 1000)
            {
                Console.WriteLine("The number of miles should be between 1 and 1000");
                data = Console.ReadLine();
            }
            return miles;
        }
    }
}

/*
1. Describe the purpose of the class you created and how a developer might use the class.   
--The purpose of the RaceGame class is to provide the programmer with the necessary method to create a race game like mine where a certain number of bikers race one another. It has the following methods: AddNames, AddDisplayChar, PrintRounds, ChangePositions, RoundResults, CheckForWinner, and DisplayResults. 
A developer might use this class if they want to create a race game that requires the user to input the names of the players, characters for those names, and display those names and characters in the result. 
2. Explain design considerations in selecting a menu vs a loop. If you use a menu, explain why you included or excluded different commands.  If you use a loop, explain why you didn’t opt to use a menu.
--I chose to use a loop instead of a menu because there is no reason for the user to select many options while playing the game. The only two options they have is either to continue playing the game or quit. Using a loop is more compact. 
3. Explain design considerations in using static methods vs class methods to validate data and process the data.
--I used a statid methid with my public Rounds property because I needed my rounds to add up rather than having the system create new instances of Rounds every time. I used class methods the rest of the time because I needed my public properties to create new instances of itself.
4. Discuss any problems you encountered when creating the project and how you resolved them. 
--I was getting an error in the RoundResults methods when I entered a white space because I was trying to convert the user's input (string) into a character. So, if I entered a white space, then the conversion would result into an error, as it is impossible to convert a white space into a character. I asked ChatGPT and it suggested that I add "!string.IsNullOrEmpty(enter)" into my if statement, and it solved the error because the if statement would only execute if the user did not input a white space and enter "q". Not only did ChatGPT suggest this, but it also suggested a few other ones that I understood and some that I did not. AddNames and AddDisplayChar || instead of &&.
*/