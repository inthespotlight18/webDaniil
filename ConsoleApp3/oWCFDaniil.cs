using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Channels;
//using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
//using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

using System.Reflection;
using System.ServiceModel.Web;
using System.IO;
using System.Web;

//using View;

// Only Interface functions should be in oWCFDaniil (other methods get moved to Model, View, Gapp)

namespace ConsoleApp3
{
    class oWCFDaniil : iWCFDaniil
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public int GetInfo()
        {
            return 99;
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
        
        // This should be moved to Gapp namespace

        public static string get_the_ip()
        {
            var ip = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "No IP";
            //Console.WriteLine(ip);
            return ip;
        }

        private string GetClientIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
               prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;

            return ip;
        }


        public Stream ShowClientIP()
        {
            string html = "<html><body>";

            html += string.Format("<h3>{0}|{1}</h3>", DateTime.Now, GetClientIP());
            html += "</body></html>";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public Stream GetPage()
        {
            string html = "<html><body>";

            html += "<h3>Hello Daniil</h3>";
            html += "</body></html>";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        // This should be moved to VIEW namespace
        public static List<string> GetWebMethods(WebServiceHost host, Type intf)
        {
            List<string> methods = new List<string>();

            foreach (ServiceEndpoint ep in host.Description.Endpoints)
            {
                methods.Add(ep.ListenUri.ToString());

                MethodInfo[] members = intf.GetMethods();

                foreach (MethodInfo mi in members)
                {
                    StringBuilder s = new StringBuilder();

                    s.AppendFormat("  {0}(", mi.Name);

                    string parameters = string.Join(",", Array.ConvertAll((object[])mi.GetParameters(), x => x.ToString()));
                    s.Append(parameters);
                    s.Append(")");

                    methods.Add(s.ToString());

                }
                //GS210421
                break; // Only on endpoint needed
            }
            Console.WriteLine("NEW_LIST=[{0}]", string.Join(", ", methods));

            return methods;
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public Stream Info()
        {
            string html = View.DataPresenter.ListToHTML(GetWebMethods(Program._HOST, typeof(iWCFDaniil)));

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
    }
}
