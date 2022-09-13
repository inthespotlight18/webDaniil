using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;
using System.Data;


namespace wcfDaniil
{
    [ServiceContract]
    public interface iWCFDaniil
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        [OperationContract]

        [WebGet]
        Stream Info();

        [WebGet]
        Stream ShowClientIP();

        [WebGet]
        int GetInfo();

        [WebGet]
        Stream GetPage(); 

        [WebGet]
        DataSet dsExcelSheetGet();

        [WebGet]
        string Version();

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "ValidatePOST")]
        //UriTemplate = "/ValidatePOST?userName={userName}")]

        // [WebInvoke(Method = "POST", UriTemplate = "/ValidatePOST?userName={userName}")]
        string ValidatePOST(string userName, string password);

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************

        [WebGet]
        string CallMS();

        [WebGet]
        string Trap(int n);

        [WebGet]
        DataSet SampleDS();

        [WebInvoke(Method = "POST")]
        int PostTest(DataSet ds);

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/


    }
}
