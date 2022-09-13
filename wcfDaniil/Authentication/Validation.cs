using System;

namespace wcfDaniil
{
    public class Validation
    {
        public string ValidateUserData(string userName, string password)
        {
            Console.WriteLine("ValidateUserData");

            Console.WriteLine("username - " + userName);
            Console.WriteLine("password - " + password);

            if (null == userName || null == password)
            {
                return "NULL error";
            }

            if ((userName == "Daniil" && password == "1234") || (userName == "Test" && password == "tttt"))
            {
                return "Welcome";
            }
            else
            {
                return "Unknown user";
            }


        }
    }
}