//DZ220718 - wcfDaniil

 //Version : 1.6
 //Release : August 25/2022

 //Re : wcfDaniil REST API / Windows Service                                                                     

 //Update : DZ220718 - Reorganised and cleaned up code
 //Update : DZ220817 - Cleaned up references
 //Update : DZ220822 - Version() method, comments
 //Update : DZ220825 - Info() and Version() method fixed, comments
 //Update : DZ220829 - Rebuilded bin folder, solving github issues
 //Update : DZ220830 - fixed Info(), style changes, Assembly version

 //Update : DZ220912 - Authentication added, works with POSTMAN, to get expected results,
 //     please follow next instructions: 
 //In the POSTMAN, choose POST method, enter http://localhost/wcfDaniil/ValidatePOST,
 //go to the Body (under website url), click raw, and add JSON code similar to the one below:

 /*  

 {
     "userName" : "Daniil",
     "password" : "1234"
 }

  */
 
//Update: DZ220918 - Info() is method fixed, Assembly version added, testing with postman done



/*******************************************************************************************************************\
*                                                                                                                  *
\*******************************************************************************************************************/

using System;
using System.Net;
using System.ServiceProcess;
using System.Diagnostics;


namespace webDaniil
{

    class Program
    {

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string SERVICE_NAME = "DZ_test";
      
        static void Main()
        {
            try
            {
                // GS2110125 : ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                if (GAPP.Gap.Test)
                {
                    // Console.WriteLine("Public ... {0}\n", GAPP.GapLib.GetPUBurl());
                    Console.WriteLine("\n");
                    Console.ReadLine();
                }
                else
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                         new Service1()
                    };
                    ServiceBase.Run(ServicesToRun);
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Trace.TraceWarning(ex.Message);
                if (GAPP.Gap.Test) Console.ReadKey();
            }

        }


        /*******************************************************************************************************************\
         *                                                                                                                  *
        \*******************************************************************************************************************/


    }

}

