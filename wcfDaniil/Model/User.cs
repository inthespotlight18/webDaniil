using System;
using System.Collections.Generic;

namespace Model
{
    public class User 
    {
        public string name, date, ip;
        public Guid guid;

        public static IDictionary<Guid, User> AllUsers = new Dictionary<Guid, User>();

        public User (string Name, string Date, Guid Guid, string Ip)
        {
            name = Name;
            date = Date;  //DateTime now = DateTime.Now;
            guid = Guid;
            ip = Ip;
        }
          

        public static Guid UserAdd(string userName, string ip)
        {
            string dateTime = DateTime.Now.ToString();
            Guid key = Guid.NewGuid();

            User user = new User(userName, dateTime, key, ip);
            AllUsers.Add(key, user);
            //return key if user  new || found

            return key;

        }



        public static IDictionary<Guid, User> printUsersDict()
        {
            //Dictionary<string, User> AllUsers = new Dictionary<string, User>();
            if (AllUsers != null)
            {
                foreach (KeyValuePair<Guid, User> x in AllUsers)
                {
                    Console.WriteLine("Key = {0}, Value = {1}, Name = {2}, IP = {3}", x.Key, x.Value, x.Value.name, x.Value.ip);
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
