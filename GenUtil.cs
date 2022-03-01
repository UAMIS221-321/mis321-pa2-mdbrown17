using System;

namespace mis321_pa2_mdbrown17
{
    public class GenUtil
    {
        public static bool CheckDateTime(string input) // used to check that a user's input can be parsed to DateTime format
        {
            try 
            {
                DateTime.Parse(input);
            }
            catch
            {
                Console.WriteLine("ERROR: Invalid input or formatting, try again.");
                return false;
            }
            return true;
        }
        public static bool CheckInt(string input) // used to check that a user's input can be parsed to a double
        {
            try 
            {
                int.Parse(input);
            }
            catch
            {
                Console.WriteLine("ERROR: Invalid input, try again.");
                return false;
            }
            return true;
        }
        public static bool CheckDouble(string input) // used to check that a user's input can be parsed to a int
        {
            try 
            {
                double.Parse(input);
            }
            catch
            {
                Console.WriteLine("ERROR: Invalid input, try again.");
                return false;
            }
            return true;
        }
    }
}