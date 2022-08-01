using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

using System.Configuration;
using System.Security.Principal;

using System.IO;
using System.Diagnostics;
using System.Reflection;

using System;
using System.Reflection;
using System.Threading;
using System.Reflection.Emit;





namespace XRAY
{

    /*******************************************************************************************************************\
     *                                                                                                                 *
    \*******************************************************************************************************************/

    [ServiceContract]
    public interface iWCFXray
    {
        [OperationContract]

        [WebGet]

        string Test();

        [WebGet]
        string Notify(string mb, string msg, string app, string node, string user, string level, string ver, string exmsg);

    }

    /// <summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    

    public class clientXRAY : ClientBase<iWCFXray>, iWCFXray
    {
        public const string ENDPOINT = "XRAY";

        //static private Uri ENDURL = new Uri(string.Format("https://gp03.garnet.ca:{0}/{1}", GAPP.Gap.HttpsPort, ENDPOINT));
        static private Uri ENDURL = new Uri(string.Format("http://gp02.garnet.ca:80/{0}", ENDPOINT));

        //Don't use for Proxy
        //const string _name_url_post = "URLPost";

        //const string _url = @"http://vancouver.garnet.ca/wcfPostCPMS";
        //const string _url = @"http://localhost/wcfPostCPMS";

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
 

        //private static string _url_post = ConfigurationManager.ConnectionStrings[_name_url_post].ToString();


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/



        public static string idUSER = WindowsIdentity.GetCurrent().Name;
        public static string idAPP = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        public static string idNODE = Environment.MachineName;


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/


        public clientXRAY(string endpointConfigurationName)

            : base(endpointConfigurationName)
        {
        }


        public clientXRAY()

            : base(ENDPOINT)
        {
        }


        private static WebHttpBinding _web_http_binding = new WebHttpBinding()
        {
            MaxReceivedMessageSize = 2147483647L,
            MaxBufferSize = 2147483647
        };



        public static WebHttpBinding _web_https_binding = new WebHttpBinding()
        {
            //CrossDomainScriptAccessEnabled = true,
            Security = { Mode = WebHttpSecurityMode.Transport },
            MaxReceivedMessageSize = 2147483647L,
            MaxBufferSize = 2147483647

        };


        public clientXRAY(bool use)
            //: base(_web_http_binding, new EndpointAddress(GAPP.Gap.EpUploadHodder))
            //: base(_web_https_binding, new EndpointAddress(ENDURL))
            : base(_web_http_binding, new EndpointAddress(ENDURL))
        {
            WebHttpBehavior behavior = new WebHttpBehavior();

            base.Endpoint.Behaviors.Add(behavior);

        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();    
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public string Test()
        {
            //return base.Channel.Alert(src, msg);
            try
            {
                using (new OperationContextScope(this.InnerChannel))
                {
                    return base.Channel.Test();
                }

            }

            catch (Exception ex)
            {
                return string.Format("FAIL | [{0}]", ex.Message);
            }

        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public string Notify(string mb, string msg, string app, string node, string user, string level, string ver, string exmsg = null)
        {
            try
            {
                using (new OperationContextScope(this.InnerChannel))
                {
                   return base.Channel.Notify(mb, msg, app, node, user, level, ver, exmsg);
                }

            }
            catch (Exception ex)
            {
                DateTime n = DateTime.Now;
                EventLog.WriteEntry("GarNet", ex.ToString());

                string fail = string.Format("clientXRAY.Notify - app[{0}] node[{1}] user[{2}] msg[{3}] l[{4}] v[{5}] ex[{6}] now[{7}]",
                    app, node, user, msg, level, ver, ex.Message, n);

                Trace.TraceWarning(fail);
                Console.WriteLine(fail);

                return string.Format("FAIL Remote Notify : local trace reported [{0}]", n);

            }

        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public string Error(System.Reflection.MethodBase mb, string msg, Exception ex)
        {
            return Notify(mb.Name, msg, idAPP, idNODE, idUSER, "Error", AssemblyVersion(), ex.Message);
        }

        public string Memo(System.Reflection.MethodBase mb, string msg)
        {
            return Notify(mb.Name, msg, idAPP, idNODE, idUSER, "Memo", AssemblyVersion());
        }
    



    }

}
