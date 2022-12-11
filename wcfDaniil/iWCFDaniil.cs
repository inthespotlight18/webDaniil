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
        Stream printUsersDictWeb();

        [WebGet]
        string Version();

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "ValidatePOST")]
        //UriTemplate = "/ValidatePOST?userName={userName}")]

        // [WebInvoke(Method = "POST", UriTemplate = "/ValidatePOST?userName={userName}")]
        string ValidatePOST(string userName, string password); //search using token key

        [WebGet]
        void UserAdd(string userName);

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

        [WebGet]
        void SendSMS();


    }
}
