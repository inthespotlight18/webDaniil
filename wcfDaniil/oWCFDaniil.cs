﻿using System;
using System.Text;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using View;
using Model;
using System.Reflection;
using System.Collections.Generic;

namespace wcfDaniil
{
    
    public class oWCFDaniil : iWCFDaniil
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public Validation V = new Validation();
        

        public int GetInfo()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            return 99;
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
 
        private string GetClientIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
               prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;

            return ip;
        }


        public Stream ShowClientIP()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            string html = "<html><body>";

            html += string.Format("<h3>{0}|{1}</h3>", DateTime.Now, GetClientIP());
            html += "</body></html>";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public Stream GetPage()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            string html = "<html><body>";

            html += "<h3>Hello Daniil</h3>";
            html += "</body></html>";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public Stream Info()
        {
            WebServiceHost Host = (WebServiceHost)OperationContext.Current.Host;

            string html = View.DataPresenter.ListToHTML(DataGetter.GetWebMethods(Host, typeof(wcfDaniil.iWCFDaniil)));
            //string html = "info";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************


        public DataSet SampleDS()
        {
            DataTable dt = new DataTable("Nadia");
            dt.Columns.Add("code");
            dt.Columns.Add("First Name");
            dt.Rows.Add("1", "sister");
            dt.Rows.Add("2", "brother");

            DataSet ds = new DataSet("dsTest");
            ds.Tables.Add(dt);

            return ds;
        }


        public int PostTest(DataSet ds)
        {
            return ds.Tables.Count;
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************

        public string Trap(int n)
        {
            try
            {
                if (n == 666) throw new ArgumentNullException(paramName: nameof(n), message: "parameter can't be 666.");
                return String.Format("OK|{0}|{1}", DateTime.Now, n);
            }
            catch (Exception ex)
            {
                return String.Format("FAIL |{0}", ex.Message);
            }
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************

        public string CallMS()
        {
            try
            {
                int[] array = { 12 };
                return array[2].ToString();
            }
            catch (Exception ex)
            {
                string msg = "additional info";
                Console.WriteLine(ex.Message);
                new XRAY.clientXRAY().Error(System.Reflection.MethodBase.GetCurrentMethod(), msg, ex);
                return string.Format("FAIL|[{0}]", ex.Message);

            }
            return "nothing";
        }


        /*******************************************************************************************************************\
         *                                                                                                                  *
        \*******************************************************************************************************************/


        public DataSet dsExcelSheetGet()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                DataTable dt = Model.lclExcel.dtExcelSheetGet(@"Book2.xlsx");
                DataSet ds = new DataSet(String.Format("{0}_{1}", "dsExcelSheetGet", DateTime.Now));
                ds.Tables.Add(dt.Copy());
                return ds;
            }
            catch (Exception ex)
            {
                new XRAY.clientXRAY().Error(System.Reflection.MethodBase.GetCurrentMethod(), ex.Source, ex);
                return new DataSet(ex.Message);
            }
        }

        /*******************************************************************************************************************\
        *                                                                                                                  *
        \*******************************************************************************************************************/

        public string ValidatePOST(string userName, string password)//get token (put it as a parameter)
        {
            string access = "";

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("U - " + userName);
            Console.WriteLine("P - " + password);


            Validation V = new Validation();

            //name, ip, password

            //boolean or check string
            if (V.ValidateUserData(userName, password).status == "Admin")
            {
                string ip = GetClientIP();
                Model.User.UserAdd(userName, ip);
                access = "Access was granted, Welcome!";
            }
            if (V.ValidateUserData(userName, password).status == "User")
            {
                access = "Access was Blocked, try again.";
            }


            // return V.ValidateUserData(userName, password);

            //tell the browser to create cookie, using key later in security, 
            return access;

        }

        /*******************************************************************************************************************\
        *                                                                                                                  *
        \*******************************************************************************************************************/

        public Stream printUsersDictWeb()
        {
            Model.User.printUsersDict();
            string html = View.DataPresenter.DictToHTML(Model.User.GetAllUsers());
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            //return new MemoryStream(Encoding.UTF8.GetBytes(DataPresenter.LoginFormsHTML()));
            return new MemoryStream(Encoding.UTF8.GetBytes(html));


        }


        public Stream printAllUsers()
        {
            DataTable dt = new DataTable("User");

            dt.Columns.Add("UserName");
            //dt.Columns.Add("id");
            dt.Columns.Add("Date");
            dt.Columns.Add("Guid");
            dt.Columns.Add("Status");


            //dt.Columns.Add("Authentication");

            //dt.Columns.Add("stamp", typeof(DateTime));

            var dic = User.GetAllUsers();

            foreach (KeyValuePair<Guid, User> d in dic)
            {
                dt.Rows.Add(d.Value.name, d.Value.date, d.Value.guid.ToString(), d.Value.status);
                //    Console.WriteLine("FOREACH ALIVE - " + d.Value.name);
            }

            string html = View.DataPresenter.DTtoHTML(dt);
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            //return new MemoryStream(Encoding.UTF8.GetBytes(DataPresenter.LoginFormsHTML()));
            return new MemoryStream(Encoding.UTF8.GetBytes(html));


        }
       
        public string UserAdd(string userName)
        {

            //string ip = GetClientIP();
            string status = "User";
            var key = User.UserAdd(userName, status);
            Console.WriteLine($"{key} {status}");
            var U = User.GetUser(key);


            foreach (var prop in U.GetType().GetProperties())
            {
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(U, null) + "$%$%$%$%");
            }

            //return str.Remove(str.Length - 1) + "}";


            /*******************************************************************************************************************\
             *                                                                                                                 *
            \*******************************************************************************************************************/


           


            ///* 
            // *
            // */
            //ShowConsoleOutput(dt);



            string html = View.DataPresenter.CommonPageHTML();

            Console.WriteLine("UserAdd() works");

            return "UserAdd() is working";

        }


        static void ShowConsoleOutput(DataTable dt)
        {

            foreach (DataColumn col in dt.Columns)
                Console.Write("{0} ", col.ColumnName);


            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine();
                foreach (DataColumn col in dt.Columns)
                    Console.Write("{0} ", row[col.ColumnName]);
            }
            Console.WriteLine();

        }

        //#$%^&*
        public string Version()
        {
            //e.g. - you have to take Guid from User's session data
            Guid key = Guid.NewGuid();
            if (User.GetUser(key).status == "Admin")
            {
                //Execute function
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                return Gapp.Gap.AssemblyVersion();
            }


            return "Access denied";
        }

        public void SendSMS()
        {
            //Model.testRingSMS RC = new Model.testRingSMS();
            Model.testRingSMS.test_rcsms();
        }


      

        /*******************************************************************************************************************\
        *                                                                                                                  *
        \*******************************************************************************************************************/
    }
}
