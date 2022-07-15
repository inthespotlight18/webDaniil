using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Description;
using System.Reflection;
using System.ServiceModel.Web;
using System.IO;
using System.Web;


using Model;


namespace ConsoleApp3
{
    class oWCFDaniil : iWCFDaniil
    {
        public int GetInfo()
        {
            return 99;
        }
        public static string ShowTheIp()
        {
            var ip = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "No IP";
            Console.WriteLine(ip);
            return ip;
        }

        public Stream GetPage()
        {
            string h = "<html><body>";

            h += "<h3>Hello Daniil</h3>";
            h += "</body></html";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            byte[] htmlBytes = Encoding.UTF8.GetBytes(h);
            return new MemoryStream(htmlBytes);

        }


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
        public Stream Info()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(VIEW.ListToHTML( GetWebMethods(Program._HOST, typeof(iWCFDaniil) ) ) ) );
        }

        
    }
}
