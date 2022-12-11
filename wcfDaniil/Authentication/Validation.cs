using System;

namespace wcfDaniil
{
    public class Validation
    {
        public bool ValidateUserData(string userName, string password)
        {
            Console.WriteLine("ValidateUserData");

            Console.WriteLine("username - " + userName);
            Console.WriteLine("password - " + password);



            if (null == userName || null == password)
            {
                return false;
            }

            if ((userName == "Daniil" && password == "1234") || (userName == "Test" && password == "tttt"))
            {

                return true;
            }
            else
            {
                return false;
            }


        }
    }
}