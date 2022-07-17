/*******************************************************************************************************************\
*                    
                     DZ220714 - DataTransfer
                     Version : 1.1
                     Release : July 14/2022
                    
                     Re : wcfDaniil REST API                                                                     
                     Update : Reorganised and cleaned up code
                                                                                                                    *
\*******************************************************************************************************************/


using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace ConsoleApp3
{
    class Program
    {
        public static WebServiceHost _HOST { get; set; }

        static void Main(string[] args)
        {
   
            Console.WriteLine("Begin");

            Console.WriteLine(oWCFDaniil.ShowTheIp());

            Uri httpUrl = new Uri("http://localhost:80/");

            _HOST = new WebServiceHost(typeof(oWCFDaniil), httpUrl);

            var binding = new WebHttpBinding(); 
            _HOST.AddServiceEndpoint(typeof(iWCFDaniil), binding, "wcfDaniil");

           
            _HOST.Open();

            Console.WriteLine("Commence with the testing!");
            Console.ReadLine();

            _HOST.Close();


            Console.WriteLine("End");
            Console.ReadLine();

        }
    }
}
/******************************************************************************************\
*                                                                                          * 
\******************************************************************************************/
