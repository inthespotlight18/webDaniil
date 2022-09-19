using System;
using System.Collections.Generic;

//using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Reflection;
using System.Text;
using System.ServiceModel.Web;

namespace View
{
    public class DataGetter
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static List<string> GetWebMethods(WebServiceHost host, Type intf)
        {
            List<string> methods = new List<string>();

            methods.Add("Assembly version - " + Gapp.Gap.AssemblyVersion());

            foreach (ServiceEndpoint ep in host.Description.Endpoints)
            {
                methods.Add(ep.ListenUri.ToString());

                MethodInfo[] members = intf.GetMethods();

                foreach (MethodInfo mi in members)
                {
                    System.Text.StringBuilder s = new StringBuilder();
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
    }
}
