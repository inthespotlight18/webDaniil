using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp3
{
    [ServiceContract]
    internal interface iWCFDaniil
    {
        [OperationContract]

        [WebGet]
        Stream Info();

        [WebGet]
        int GetInfo();

        [WebGet]
        Stream GetPage();



    }
}
