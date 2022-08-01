// DZ220714 - wcfDaniil
//
// Version : 1.3
// Release : July 14/2022
//                
// Re : wcfDaniil REST API                                                                     
//
// Update : DZ220718 - Reorganised and cleaned up code

using System;
using System.Reflection;
using System.Threading;
using System.Reflection.Emit;

using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using wcfDaniil;


namespace webDaniil
{
    class Program
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static WebServiceHost _HOST { get; set; }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        static void Main(string[] args)
        {
            Console.WriteLine(GAPP.GapLib.AssemblyVersion());

            Console.WriteLine("Begin");
          //  Console.WriteLine(GPC.get_the_ip());

            Uri httpUrl = new Uri("http://localhost:80/");

            _HOST = new WebServiceHost(typeof(wcfDaniil.oWCFDaniil), httpUrl);

            var binding = new WebHttpBinding();
            _HOST.AddServiceEndpoint(typeof(wcfDaniil.iWCFDaniil), binding, "wcfDaniil");

            _HOST.Open();

            Console.WriteLine("Commence with the testing!");
            Console.ReadLine();

            _HOST.Close();


            Console.WriteLine("End");
            Console.ReadLine();

        }

        /*******************************************************************************************************************\
         *                    Method reads a excel spreadsheet file and returns dataset                                     *
        \*******************************************************************************************************************/




    }
}

