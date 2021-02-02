using System;

namespace GuessingGame
{
    internal class Program
    {
        /*
        Guessing game exercise.

        Write a guessing game program that will ask the user to guess a 'secret number' from 1 - 100 inclusively.
        The program should keep re-prompting the user to guess again until he/she 1) guesses the secret number OR
        2) hit the limit of guesses allowed. You can give the user however many guesses that you would like to.
        Tell the user if they guess too high or too low before re-prompting them.

        Keep a record in the form of an integer array of all of the attempts made by the user. If the user has
        remaining guesses, those attempts will be logged as zeroes (the default value of an integer if it is
        not assigned).

        After the user wins or loses, congratulate (or scold) them accordingly and print out the each guess from
        the attempt log.

        Then ask the user if he/she would like to play again. If so, repeat the whole process, otherwise say goodbye.

        *Note* - Try and put all of the code into different methods that you will call from the main method.

        METHODS:

        1. Greet and get user name
        2. Guess number
        3. Print attempt log
        4. Ask to play again
        5. Say goodbye

        **HINTS**
        - Method 1
            parameters - none
            returns -> username
        - Method 2
            parameters - the secret number
            returns -> An array of the attempts
        - Method 3
            parameters - 1) The attempt log. 2) The username (if you want)
            returns -> void (nothing)
        - Method 4
            parameters - none
            returns -> a boolean indicating if the user wants to play (true) or not (false)
        - Method 5
            parameters - user name
            returns -> void

        - In the main method, a while loop should be run to allow the user to keep playing if they wish.
        All of the methods will be called inside of this while loop aside from the Method 5.

        */

        private static void Main(string[] args)
        {
            bool play = true;
            string name = "";
            while (play)
            {
                name = UserName();
                int[] attemptLog = GuessNumber(25);
                PrintLog(attemptLog, name);
                play = PlayAgain();
            }
            Farewell(name);
        }

        // Greet user and get their name
        public static string UserName()
        {
            Console.WriteLine("Welcome to the secret guessing game!");
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        // Prompt user for guesses and return a log of all attempts
        public static int[] GuessNumber(int secretNum)
        {
            Console.WriteLine();
            Console.WriteLine("Please guess a number from 1 - 100");

            // record each attempt the user makes. All leftover guesses (guesses not used)
            // will be recorded as zero (the default value).
            int[] log = new int[12];
            bool win = false;

            // prompt user to guess secret number
            for (int i = 0; i <= 11; i++)
            {
                Console.Write($"Attempt {i + 1}: ");
                int attempt = int.Parse(Console.ReadLine());

                log[i] = attempt;

                // if user guesses to high
                if (attempt > secretNum)
                    Console.WriteLine("Too high");

                // if user guesses to low
                else if (attempt < secretNum)
                    Console.WriteLine("Too low");

                // if user guesses correctly
                else
                {
                    win = true;
                    break;
                }

                Console.WriteLine();
            }

            if (win)
                Console.WriteLine("Congratulations! You win!");
            else
                Console.WriteLine("You lose...");

            return log;
        }

        // print each attempt in the attempt log
        public static void PrintLog(int[] log, string name)
        {
            Console.WriteLine();
            Console.WriteLine($"{name}'s attempts: ");

            for (int i = 0; i < log.Length; i++)
                Console.Write(log[i] + ", ");

            Console.WriteLine();
        }

        // ask user if they want to play again
        public static bool PlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to play again?");
            Console.Write("Please enter 'yes / y' to play again or press enter to exit: ");

            string input = Console.ReadLine();

            if (input == "yes" || input == "y")
                return true;

            return false;
        }

        // Say farewell to user if they choose to not play again
        public static void Farewell(string name)
        {
            Console.WriteLine();
            Console.WriteLine($"Thank you for playing {name}! Have a nice day.");
        }
    }
}