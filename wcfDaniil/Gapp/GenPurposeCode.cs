using System.Web;
using System;
using System.Reflection;
using System.Threading;
using System.Reflection.Emit;


namespace Gapp
{
    public class GPC
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string get_the_ip()
        {
            var ip = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "No IP";
            //Console.WriteLine(ip);
            return ip;
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
            
        }

    

}
