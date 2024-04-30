using System;

namespace FirstApplication
{
    public class Program
    {
        static void Main()
        {
            // Define the folder path where the personal files will be stored
            var folderPath = @"*\PersonalFile Manager";

            // Instantiate the PersonalFileManager with the folder path
            var nameFileManager = new NameFileManager(@"*\\NameFile Manager\\names.txt", folderPath);
            var personalFileManager = new PersonalFileManager(folderPath);

            //load and unload data
            Console.WriteLine("Hello user! Have you been here before?");
            var wasHereBefore = UserStatus.HereBefore();

            if (wasHereBefore is null)
            {
                Console.WriteLine("Program terminated.");
                System.Environment.Exit(0);
            }

            if ((bool)wasHereBefore)
            {
                Console.WriteLine("Welcome Back! What is your Name?");
                string userInput;
                do
                {
                    // Prompt the user to input their name
                    Console.Write("Enter your name: ");
                    userInput = Console.ReadLine() ?? "";

                    // Check if the entered name exists in the names.txt file
                    if (string.IsNullOrWhiteSpace(userInput) || !nameFileManager.NameExists(userInput))
                    {
                        Console.WriteLine("Name does not exist in the list. Please enter a valid name.");
                        //implement return to line "Console.WriteLine("Hello user! Have you been here before?");"
                    }
                } while (!nameFileManager.NameExists(userInput));

                // If the name exists, you can proceed with further operations
                Console.WriteLine($"Welcome, {userInput}!");
            }
            else
            {
                Console.WriteLine("Let me add you to our system! What is your Name?");

                var newName = Console.ReadLine();
                if (newName != null)
                {
                    nameFileManager.AddName(newName);
                    nameFileManager.CreatePersonalFiles();
                }
            }

            // Call the UserInput method from UserOptions class
            UserOptions.UserInput(personalFileManager);

            // After UserInput returns true (when user selects logout), you can perform further actions if needed
            Console.WriteLine("Program terminated.");
        }
    }
}
