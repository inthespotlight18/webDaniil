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
