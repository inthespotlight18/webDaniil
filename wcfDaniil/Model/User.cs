using System;
using System.Collections.Generic;

namespace Model
{
    public class User 
    {
        public string name, date;
        public Guid guid;

        public static IDictionary<Guid, User> AllUsers = new Dictionary<Guid, User>();

        public User (string Name, string Date, Guid Guid)
        {
            name = Name;
            date = Date;  //DateTime now = DateTime.Now;
            guid = Guid;
        }


        public static void UserAdd(string userName)
        {
            string dateTime = DateTime.Now.ToString();
            Guid key = Guid.NewGuid();

            User user = new User(userName, dateTime, key);
            AllUsers.Add(key, user);

        }



        public static IDictionary<Guid, User> printUsersDict()
        {
            //Dictionary<string, User> AllUsers = new Dictionary<string, User>();
            if (AllUsers != null)
            {
                foreach (KeyValuePair<Guid, User> x in AllUsers)
                {
                    Console.WriteLine("Key = {0}, Value = {1}, Name = {2}", x.Key, x.Value, x.Value.name );
                }
            }
            else
            {
                Console.WriteLine("CAUGHT NULL!!!");
            }

            return AllUsers;
            
        }
        
    }
}
