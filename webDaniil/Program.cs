﻿/*******************************************************************************************************************\
*                                                                                                                  *
\*******************************************************************************************************************

    DZ220718 - wcfDaniil

    Version : 1.5
    Release : August 22/2022
                
    Re : wcfDaniil REST API / Windows Service                                                                     

    Update : DZ220718 - Reorganised and cleaned up code
    Update : DZ220817 - Cleaned up references
    Update : DZ220822 - AssemblyVersion() method, comments

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
         *                                                                                                                 *
        \*******************************************************************************************************************/


    }

}

