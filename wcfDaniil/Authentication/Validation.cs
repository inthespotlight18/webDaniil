using System;
using System.Collections.Generic;
using Model;


namespace wcfDaniil
{
    public class Validation
    {
        private List<string> AdminsId = new List<string>();


        public void AdministratorsAdd(string id)
        {
            
        }

        public User ValidateUserData(string userName, string password)
        {
            //string ValidateResponse;

            Console.WriteLine("ValidateUserData");

            Console.WriteLine("username - " + userName);
            Console.WriteLine("password - " + password);

            
            
            //Administrators
            if ((userName == "Daniil" && password == "1234") || (userName == "Gordon" && password == "4321"))
            {
                Guid key = User.UserAdd(userName, "Admin");

                //might be commented
                AdminsId.Add(key.ToString());

                return User.GetUser(key);    

            }   
            
            //Other users
            else
            {
                Guid key = User.UserAdd(userName, "User");
                return User.GetUser(key);
            }


        }

        //#1 way - identify administrator, using Id's list

        public bool AdminCheck(string id)
        {
            foreach(var item in AdminsId)
            {
                if (item == id)
                    return true;
            }
            return false;

        }

        //#2 way - identify administrator by the pattern in its Id

        //public bool AdminCheck(string id)
        //{
        //    string pattern = "Admin";
        //    if (id.Contains(pattern))
        //    { 
        //        return true;
        //    }

        //    return false;
        //}


    }
}