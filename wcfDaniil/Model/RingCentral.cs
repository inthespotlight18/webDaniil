using RestSharp;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class testRingSMS
    {

        const string tophonenumber = "+12369713928`";
        const string fromphonenumber = "+16045126200";
        const string extension = "101";


        string textmsg = string.Format("Text test from c# [{0}]", DateTime.Now);

        //var postbody = new
        //{
        //    text = textmsg,
        //    from = new { phoneNumber = fromphonenumber },
        //    to = new[] { new { phoneNumber = tophonenumber } }
        //};


        //postrequest.AddJsonBody(postbody);

        //IRestResponse postresponse = client.Execute(postrequest);
        //Console.WriteLine("postresponse.content[{0}]", postresponse.Content);

 

        public static void test_rcsms()
        {
            try
            {

                string auth_url = "https://platform.ringcentral.com/restapi/oauth/token";
                string client_id = "7BuEjO4VRDu1ZgF2UKcASA";
                string client_secret = "5rX2Sz-7S5uTCBu_g_sz9gVA5ICgs_QEeNkvh_vVkHjQ";
                string accountID = "+18778225251";
                string password = "Mink@$5051";

                string basicauth = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", client_id, client_secret)));
                //7BuEjO4VRDu1ZgF2UKcASA:5rX2Sz-7S5uTCBu_g_sz9gVA5ICgs_QEeNkvh_vVkHjQ


                var restClient = new RestClient(auth_url);
                RestRequest authrequest = new RestRequest() { Method = Method.Post };

                string ah = string.Format("Basic {0}", basicauth);
                authrequest.AddHeader("Authorization", ah);

                //authrequest.AddHeader("Accept", "application/json");

                authrequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");


                authrequest.AddParameter("grant_type", "password");
                authrequest.AddParameter("username", accountID);
                authrequest.AddParameter("password", password);

                var authResponse = restClient.Execute(authrequest);
                var responseJson = authResponse.Content;

                //Console.WriteLine(responseJson);
                //Console.ReadLine();

                var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();

                Console.WriteLine(token);

                Console.WriteLine("***************");


                ///////////////////
                //////////////////
                ///

                var client = new RestClient("https://platform.ringcentral.com");

                //client.Timeout = -1;
                /// var datarequest = new RestRequest("https://platform.ringcentral.com/restapi/v1.0/account/~/extension/~/sms", Method.Get);

                //datarequest.AddHeader("Authorization", "Bearer " + token);
                ////ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //RestResponse dataresponse = client.Execute(datarequest);

                //Console.WriteLine("Ready to show dataResponse");
                //Console.WriteLine("dataresponse.content[{0}]", dataresponse.Content);

                //Console.WriteLine("***************");


                var postrequest = new RestRequest("/restapi/v1.0/account/~/extension/~/sms", Method.Post);

                postrequest.AddHeader("Authorization", "Bearer " + token);
                postrequest.AddHeader("Accept", "application/json");
                postrequest.AddHeader("Content-Type", "application/json");

                string textmsg = string.Format("Another message", DateTime.Now);

                var postbody = new
                {
                    text = textmsg,
                    from = new { phoneNumber = fromphonenumber },
                    to = new[] { new { phoneNumber = tophonenumber } }
                };

                postrequest.AddJsonBody(postbody);

                RestResponse postresponse = client.Execute(postrequest);
                Console.WriteLine("postresponse.content[{0}]", postresponse.Content);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            


        }


    }

}