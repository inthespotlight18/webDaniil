using System;
using System.Collections.Generic;
using System.Linq;
using wcfDaniil;

namespace Model
{
    public class User 
    {
        public string name, date, status;
        public Guid guid;

        private static List<string> TakenNames = new List<string>();

            
        private static IDictionary<Guid, User> LoggedUsers = new Dictionary<Guid, User>();//convert in DT

        public User (string Name, string Date, Guid Guid, string Status)
        {
            name = Name;
            date = Date;  //DateTime now = DateTime.Now;
            guid = Guid;
            status = Status;
        }
          
        public static Guid UserAdd(string userName, string status)
        {
            if (!userNameAvailability(userName)) return Guid.Empty;

            string dateTime = DateTime.Now.ToString();
            Guid key = Guid.NewGuid();
            User user = new User(userName, dateTime, key, status);

            LoggedUsers.Add(key, user);
            TakenNames.Add(userName);

            return key;      
        }

        public static bool userNameAvailability(string userName)
        {
            foreach(var x in TakenNames)
            {
                Console.WriteLine(x);
            }

            if (TakenNames.Contains(userName)) return false;

            return true;

            //return true || TakenNames.Contains(userName);         
        }

        public static User GetUser(Guid key)
        {
            // Commented code causes bags
            // return (User)(from kvp in LoggedUsers where kvp.Key == key select kvp.Value);
            return LoggedUsers[key];
        }

        public static IDictionary<Guid, User> printUsersDict()
        {
            //Dictionary<string, User> LoggedUsers = new Dictionary<string, User>();
            if (LoggedUsers != null)
            {
                foreach (KeyValuePair<Guid, User> x in LoggedUsers)
                {
                    Console.WriteLine("Key = {0}, Value = {1}, Name = {2}, IP = {3}", x.Key, x.Value, x.Value.name, x.Value.status);
                }
            }
            else
            {
                Console.WriteLine("CAUGHT NULL!!!");
            }

            return LoggedUsers;
            
        }

        public static IDictionary<Guid, User>  GetAllUsers()
        {
            return LoggedUsers;
        }


        public static Guid GetToken(string userName, string password)
        {
            
            if (LoggedUsers != null)
            {
                Validation V = new Validation();

                if (V.IsUserRegistered(userName, password))
                {
                    KeyValuePair<Guid, User> searchResult
                         = LoggedUsers.FirstOrDefault(s => s.Value.name == userName);

                    Guid k = searchResult.Key;
                    User u = GetUser(k);

                    LoggedUsers.Remove(k);
                    TakenNames.Remove(u.name);
                    Guid newKey = UserAdd(u.name, u.status);

                    return newKey;
                }               
                else return Guid.Empty;
                
            }
            return Guid.Empty;

        }


        
    }
}
