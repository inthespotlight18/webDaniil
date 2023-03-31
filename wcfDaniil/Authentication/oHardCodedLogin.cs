using Model;
using System;
using System.Collections.Generic;


namespace wcfDaniil
{
    public class oHardCodedLogin : iLoginHelper
    {
        public Validation V = new Validation();

        private static IDictionary<string, string> HardCodedUsers = new Dictionary<string, string>();


        public string Login(string username, string password)
        {
            // hardcode users { Gordon, Daniil } and their claims

            HardCodedUsers.Add("Gordon", "4321");

            HardCodedUsers.Add("Herbert", "pass00");

            HardCodedUsers.Add("Daniil", "1234");

            foreach (KeyValuePair<string, string> pair in HardCodedUsers)
            {
                if (User.UserAdd(pair.Key, pair.Value) == Guid.Empty)
                {
                   //updating users and refreshing tokens, if they already exist
                    User.GetToken(pair.Key, pair.Value);
                }
            }



            //Gordon (Admin)
            //Guid key = V.UserClassification("Gordon", "4321");
            //if (key == Guid.Empty)  return "failed";

            //// Joe (User)
            //V.UserClassification("Joe", "pass01");



            return "oHardCodedLogin->Login() worked";
        }

        public bool Authorize(string token, string security_action)
        {
            Guid t = Guid.Parse(token);

            if (User.GetUser(t).status == "Admin")
            {

            }

            // hardcode permissions as per token for each security_action
            throw new NotImplementedException();
        }

        
    }
}
