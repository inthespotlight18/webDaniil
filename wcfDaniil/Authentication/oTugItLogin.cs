using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wcfDaniil
{
    public class oTugItLogin : iLoginHelper
    {
        public string Login(string username, string password)
        {

            // something like this ->        gUserData = "UID=" & Me.txtUserName.text & ";PWD=" & Me.txtPassword.text
            // concatenate it to the connection string
            // use MS-SQL verify the user has access

            // connection to GP01 -> ConnectString="Provider=SQLOLEDB;Data Source=gp01.garnet.ca;Initial Catalog=TugAssist_Thunder_live;"
            // OR connection to GP01 -> ConnectString="Provider=SQLOLEDB;Data Source=gp01.garnet.ca;Initial Catalog=TugAssist_Harken_live;"
            return "";
        }

        public bool Authorize(string token, string security_action)
        {
            throw null;
        }
    }
}
