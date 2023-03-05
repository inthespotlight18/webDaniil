using System;
using System.Collections.Generic;

namespace Model
{
    public class User 
    {
        public string name, date, status;
        public Guid guid;

        private static IDictionary<Guid, User> AllUsers = new Dictionary<Guid, User>();//convert in DT

        public User (string Name, string Date, Guid Guid, string Status)
        {
            name = Name;
            date = Date;  //DateTime now = DateTime.Now;
            guid = Guid;
            status = Status;
        }
          
        public static Guid UserAdd(string userName, string status)
        {
            string dateTime = DateTime.Now.ToString();
            Guid key = Guid.NewGuid();

            User user = new User(userName, dateTime, key, status);
            AllUsers.Add(key, user);
            //return key if user  new || found
            //Admin || User

            return key;

        }

        public static User GetUser(Guid key)
        {
            // Commented code causes bags
            // return (User)(from kvp in AllUsers where kvp.Key == key select kvp.Value);
            return AllUsers[key];
        }

        public static IDictionary<Guid, User> printUsersDict()
        {
            //Dictionary<string, User> AllUsers = new Dictionary<string, User>();
            if (AllUsers != null)
            {
                foreach (KeyValuePair<Guid, User> x in AllUsers)
                {
                    Console.WriteLine("Key = {0}, Value = {1}, Name = {2}, IP = {3}", x.Key, x.Value, x.Value.name, x.Value.status);
                }
            }
            else
            {
                Console.WriteLine("CAUGHT NULL!!!");
            }

            return AllUsers;
            
        }

        public static IDictionary<Guid, User>  GetAllUsers()
        {
            return AllUsers;
        }



        
    }
}
