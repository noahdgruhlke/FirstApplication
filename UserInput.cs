using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    public class UserOptions
    {
        public PersonalFileManager personalFileManager;

        public UserOptions(PersonalFileManager personalFileManager)
        {
            this.personalFileManager = personalFileManager;
        }

        public static bool UserInput(PersonalFileManager personalFileManager)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("What can I help you with?");
                Console.WriteLine("1: Add a number to my account");
                Console.WriteLine("2: Remove a number from my account");
                Console.WriteLine("3: Recall number(s) in my account");
                Console.WriteLine("4: Logout");

                var input = Console.ReadLine();

                if (input.ToLower() == "1")
                {
                    Console.Write("Enter the number to add: ");
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        personalFileManager.AddNumberToPersonalFile("user_personal_file", number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number format.");
                    }
                }
                else if (input.ToLower() == "2")
                {
                    Console.Write("Enter the number to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        personalFileManager.RemoveNumberFromPersonalFile("user_personal_file", number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number format.");
                    }
                }
                else if (input.ToLower() == "3")
                {
                    List<int> numbers = personalFileManager.GetAllNumbersFromPersonalFile("user_personal_file");
                    Console.WriteLine("Numbers in your account:");
                    foreach (int number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                }
                else if (input.ToLower() == "4")
                {
                    Console.WriteLine("Logging out...");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter the number 1, 2, 3, or 4.");
                }
            }
        }
    }
}