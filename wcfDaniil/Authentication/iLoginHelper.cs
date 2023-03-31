using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using wcfDaniil;

namespace wcfDaniil
{
    [ServiceContract]
    public interface iLoginHelper
    {
        [WebGet]
        string Login(string username, string password);

        [WebGet]
        bool Authorize(string token, string security_action); // TugAssist calls it a node

    }
}


//LoginHelper.Authorize(“token”, “Dispatch”)  // example of calling the Authorize method with a nodeid

//LoginHelper.Authorize(“token”, “Boom Movement”)  // example of calling the Authorize method with a nodeid
