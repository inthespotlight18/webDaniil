using System;
using System.Text;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using View;
using Model;
using System.Collections.Generic;


namespace wcfDaniil
{
     
    public class oWCFDaniil : iWCFDaniil
    {
        /*******************************************************************************************************************\                           
         *                            Implementation of iWCFDaniil interface                                              *                          
        \*******************************************************************************************************************/

        //private static Guid? key;

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


        public WebServiceHost GetHost() 
        {
            WebServiceHost Host = (WebServiceHost)OperationContext.Current.Host;
            return Host;
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

        public string ValidatePOST(string userName, string password)
        {
            string access = "";

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Console.WriteLine("U - " + userName);
            Console.WriteLine("P - " + password);


            Validation V = new Validation();

    
            return access;

        }

        /*******************************************************************************************************************\
        *                                                                                                                  *
        \*******************************************************************************************************************/

        public Stream printUsersDictWeb()
        {
            Model.User.printUsersDict();

            //oHardCodedLogin x = new oHardCodedLogin();
            //x.Login("qwe", "abc");

            iLoginHelper y = new oHardCodedLogin();
            y.Login("qwe", "abc");
            iLoginHelper z = new oTugItLogin();
            z.Login("qwe", "abc");


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
       
        public string AddUser(string userName, string password)
        {
            Guid key = V.UserClassification(userName, password);

            if (key == Guid.Empty) return "Can't create a user. If you want to refresh token, use another method.";

            return key.ToString();   
        }

        public string GetToken (string userName, string password)
        {
            return User.GetToken(userName, password).ToString();
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
       
        //STATUS dependent function

        public string Version(string token)
        {
            Guid k = Guid.Parse(token);
            
            //Login first - admin only allowed to see the version output
            try
            {  
                if (User.GetUser( k ).status == "Admin")
                {

                    //Execute function
                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return Gapp.Gap.AssemblyVersion();
                }
                Console.WriteLine(User.GetUser( k ).status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());         
            }
            return "Access denied. Check if ^key^ value was defined. Exception is in console.";

        }



        public void SendSMS()
        {
            //Model.testRingSMS RC = new Model.testRingSMS();
            Model.testRingSMS.test_rcsms();
        }


        public string GordLogin()
        {
            Guid key = V.UserClassification("Gordon", "4321");        

            return key == Guid.Empty ? "User with this name already logged in!" : key.ToString();

            ////string s = (key == null) ?  "NULL" : key.ToString();
            //Console.WriteLine(key.ToString());

            //return key.ToString();
        }

     

        public string TEST()
        {
           // Guid k = Guid.Parse("rytuwqe-213123-sadasjdkas");

            //Console.WriteLine(User.GetUser( k ));
            Console.WriteLine("TEST()");

            return "";
        }


        /*******************************************************************************************************************\                            
         *                            Implementation of iLoginHelper objects                                              *                            
        \*******************************************************************************************************************/

        public Stream Login(string userName, string password)
        {
            //oHardCodedLogin x = new oHardCodedLogin();
            //x.Login("qwe", "abc");

            iLoginHelper oHardCoded = new oHardCodedLogin();
            oHardCoded.Login("qwe", "abc");

            iLoginHelper oTugIt = new oTugItLogin();
            oTugIt.Login("qwe", "abc");


            string html = View.DataPresenter.LoginFormsHTML();
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            //return new MemoryStream(Encoding.UTF8.GetBytes(DataPresenter.LoginFormsHTML()));
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }
         

        public bool Authorize(string token, string security_action)
        {
            return true;
        }

    }

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
 *                                                                                                                 *
\*******************************************************************************************************************

AddUser()

////string ip = GetClientIP();
    //string status = "User";
    //var key = User.UserAdd(userName, status);
    //Console.WriteLine($"{key} {status}");
    //var U = User.GetUser(key);


    //foreach (var prop in U.GetType().GetProperties())
    //{
    //    Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(U, null) + "$%$%$%$%");
    //}

    ////return str.Remove(str.Length - 1) + "}";


    ///*******************************************************************************************************************\
    // *                                                                                                                 *
    //\*******************************************************************************************************************/

//string html = View.DataPresenter.CommonPageHTML();

//Console.WriteLine("UserAdd() works");

//return "UserAdd() is working";

///*******************************************************************************************************************\
// *                                                                                                                 *
//\*******************************************************************************************************************/



