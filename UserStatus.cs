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
        public static bool HereBefore()
        {
            //has user been here before?
            var input = Console.ReadLine();

            // Check if the input is "Yes"
            if (input.ToLower() == "yes")
            {
                return true;
            }
            // Check if the input is "No"
            else if (input.ToLower() == "no")
            {
                return false;
            }
            // Handle invalid input
            else
            {
                Console.WriteLine("Invalid input. Please enter 'Yes' or 'No'.");
                // Recursively call the method until valid input is received
                return HereBefore();
            }
        }
    }
}
