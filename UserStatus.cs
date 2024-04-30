using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    internal class UserCheck
    { 
        //May implement code from Program.cs here to check if user has been here before
    }
    internal class UserStatus
    {
        public static bool? HereBefore()
        {
            //has user been here before?
            var input = Console.ReadLine();
            do
            {
                switch (input?.ToLower())
                {
                    case "yes":
                        return true;
                    // Check if the input is "No"
                    case "no":
                        return false;
                    case "exit":
                        return null;
                    default:
                        Console.WriteLine("Invalid input. Please enter 'Yes', 'No' or 'Exit'.");
                        break;
                }
            } while (true);

        }
    }
}
