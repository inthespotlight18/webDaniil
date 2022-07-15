using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

using Model;

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
            //var host = new WebServiceHost(typeof(oWCFDaniil), httpUrl);

            _HOST = new WebServiceHost(typeof(oWCFDaniil), httpUrl);

            var binding = new WebHttpBinding(); // NetTcpBinding(); = SOAP // WebHttpBinding()' = REST
            _HOST.AddServiceEndpoint(typeof(iWCFDaniil), binding, "wcfDaniil");

            List<string> r = oWCFDaniil.GetWebMethods(_HOST, typeof(iWCFDaniil));
            
            //**********************

            _HOST.Open();

            Console.WriteLine("Commence with the testing!");
            Console.ReadLine();

            _HOST.Close();

            //**********************

            Console.WriteLine("End");
            Console.ReadLine();

        }
    }
}
