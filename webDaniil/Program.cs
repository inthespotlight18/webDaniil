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



//Update: DZ220918 - Info() is method fixed, Assembly version added, testing with postman done
//Update: DZ220922 - Setting variable changed, webDaniil.exe now starts the program as well, OnDebug() function added
//Update: DZ220925 - File version changed, project rebuilt
//Update: DZ220929 - User.cs added to the model; now we can create users with parameters, and add them all to the dictionary
//Update: DZ221211 - Authentication finished, DLL remanaged, project was cleaned

//Update: DZ230110 - Converted AllUsers Dictionary in the DataTables, created public method showing the table - 
//changed Dict accesibillity, Dt->HTML code added

/* Instructions to test last update.
 * add few users using UsersAdd(userName) method. | http://localhost/wcfDaniil/UserAdd?userName=Test
 * Then, call printAllUsers(). | http://localhost/wcfDaniil/printAllUsers
 */



//Convert Dictionary in the DataTables, create public method showing the table - test it with postman,
//change class accesibillity, look for the code Dt->HTML



/*******************************************************************************************************************\
*                                                                                                                  *
\*******************************************************************************************************************/

using System;
using System.Net;
using System.ServiceProcess;
using System.Diagnostics;
using Model;
//using System.Collections.Generic;

namespace webDaniil
{

    class Program
    {

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string SERVICE_NAME = "DZ_test";

        
        public static Guid SERVICE_ID = Guid.NewGuid();

      
        static void Main()
        {

            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                if (GAPP.Gap.Test)
                {
                    testRingSMS testRingSMS = new testRingSMS();
                    testRingSMS.test_rcsms();


                    Console.WriteLine(SERVICE_NAME);
                    Console.WriteLine(GAPP.Gap.AssemblyVersion());

                    Service1 s1 = new Service1();

                    s1.OnDebug();
                    
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

