using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int guess;
            int attempts = 0;

            Console.WriteLine("Welcome to Guess My Number!");

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {attempts} guess(es).");
                }

            } while (guess != magicNumber);

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
