//using Newtonsoft.Json;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RingCentral
//{
//    public class smsSend
//    {
//        public static void test_rcsms()
//        {
//            try
//            {
//                string auth_url = "https://platform.ringcentral.com/restapi/oauth/token";

//                string client_id = "7BuEjO4VRDu1ZgF2UKcASA";
//                string client_secret = "5rX2Sz-7S5uTCBu_g_sz9gVA5ICgs_QEeNkvh_vVkHjQ";
//                string accountID = "+18778225251";
//                string password = "Mink@$5051";

//                string basicauth = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", client_id, client_secret)));

//                //request token

//                var restClient = new RestClient(auth_url);
//                RestRequest authrequest = new RestRequest() { Method = Method.Post };
//                string ah = string.Format("Basic {0}", basicauth);
//                authrequest.AddHeader("Authorization", ah);

//                //authrequest.AddHeader("Accept", "application/json");

//                authrequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

//                authrequest.AddParameter("grant_type", "password");
//                authrequest.AddParameter("username", accountID);
//                authrequest.AddParameter("password", password);



//                var authResponse = restClient.Execute(authrequest);
//                var responseJson = authResponse.Content;

//                //Console.WriteLine(responseJson);
//                //Console.ReadLine();

//                var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();

//                Console.WriteLine(token);
//                Console.WriteLine("***************");
//            }

//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//            Console.ReadLine();

//        }
         
//    }

//}