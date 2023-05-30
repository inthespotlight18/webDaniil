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

//Update: DZ230206 - Login method (AddUser) connected to the interface and works in system. This is test version,
//so username and password are given through GET method, so they should be typed in URL.
//Sample to use: http://localhost/wcfDaniil/AddUser?userName=Gordon&password=4321 - is your data, which will create Admin,
//and store the key in code. If you want to login as a user, use other data.
//Once you logged in, Version function should be tested; If your status is Admin, it will show assembly version. If status is User,
//it will deny access. 
//Format of output in console was changed. Error caused by writing a file in C:\ServiceLog.text now is fixed. Info and all other 
//methods work on my machine.

//Update: DZ230305 - Token system fixed, GordLogin() fixed, language issue in deployment is fixed.
//Update: DZ230330 - Created interface for Authentication and Login (iLoginHelper).
//User system was significantly updated. Converted hard code in the iLoginHelper class.




/*******************************************************************************************************************\
*                                                                                                                  *
\*******************************************************************************************************************/

using System;
using System.Net;
using System.ServiceProcess;
using System.Diagnostics;
using Model;
using System.Text;

namespace webDaniil
{

    class Program
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string SERVICE_NAME = "DZ_test";

        public static string domain = "http://localhost/wcfDaniil";

        public static Guid SERVICE_ID = Guid.NewGuid();

       // public static int classType = 1;

        enum UserStatus
        {
            User = 0,
            Admin = 1
        }

      

        static void Main()
        {

            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                if (GAPP.Gap.Test)
                {
                    //Console.OutputEncoding = System.Text.Encoding.Unicode;
                    testRingSMS testRingSMS = new testRingSMS();
                    testRingSMS.test_rcsms();

                    Service1 s1 = new Service1();

                    //Service1._HOST.ToString(); - doesn't work+
                    string str = "OK Launched:  " + domain;

                    byte[] utf8Bytes = Encoding.UTF8.GetBytes(str);
                    str = Encoding.UTF8.GetString(utf8Bytes);

                    Console.WriteLine(str);
                    Console.WriteLine(GAPP.Gap.AssemblyVersion());                  

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
                byte[] utf8Bytes = Encoding.UTF8.GetBytes(ex.Message);
                string str = Encoding.UTF8.GetString(utf8Bytes);
                Console.WriteLine(str);
                //Console.WriteLine(ex.Message);
                Trace.TraceWarning(ex.Message);
                if (GAPP.Gap.Test) Console.ReadKey();
            }

        }


        /*******************************************************************************************************************\
         *                                                                                                                  *
        \*******************************************************************************************************************/


    }

}

