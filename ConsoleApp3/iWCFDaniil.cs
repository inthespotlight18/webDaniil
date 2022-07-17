using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

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
/******************************************************************************************\
*                                                                                          *                                                                                                                                                                                                                      *
\******************************************************************************************/