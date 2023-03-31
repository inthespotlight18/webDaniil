using System;
using System.Collections.Generic;
using Model;


namespace wcfDaniil
{
    public class Validation
    {
        private List<string> AdminsId = new List<string>();

        private static IDictionary<string, string> RegisteredUsers = new Dictionary<string, string>();//converts in DT

      
        public void AddUsersCredentials(string userName, string password)
        {
            RegisteredUsers.Add(userName, password);
        }

        public bool IsUserRegistered(string userName, string password)
        {
            if (!RegisteredUsers.ContainsKey(userName)) return false;

            return true ? (RegisteredUsers[userName] == password) : false;
         
        }


        public Guid UserClassification(string userName, string password)
        {
            //string ValidateResponse;

            Console.WriteLine("UserClassification");

            Console.WriteLine("username - " + userName);
            Console.WriteLine("password - " + password);

            if (User.userNameAvailability(userName) == true)
            {
                Console.WriteLine("USERNAME WAS AVALIABLE");     
                
                    //Administrators
                    if ((userName == "Daniil" && password == "1234") || (userName == "Gordon" && password == "4321"))
                    {
                        Guid key = User.UserAdd(userName, "Admin");
                        RegisteredUsers.Add(userName, password);    
                        return key;

                    }

                    //Other users
                    else
                    {
                        Guid key = User.UserAdd(userName, "User");
                        RegisteredUsers.Add(userName, password);
                        return key;
                    }
            }                    
            else
            {
                Console.WriteLine("USERNAME IS TAKEN");
                return Guid.Empty;

                //if userName is already used, we can refresh token
                //return User.TokenRefresh(userName, password);
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


    }
}