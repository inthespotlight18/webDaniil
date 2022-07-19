using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Channels;
//using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
 
using System.ServiceModel.Web;
using System.IO;
using System.Web;

using View;


namespace ConsoleApp3
{
    class oWCFDaniil : iWCFDaniil
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public int GetInfo()
        {
            return 99;
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
        
        // This should be moved to Gapp namespace

  

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
            string html = View.DataPresenter.ListToHTML(DataGetter.GetWebMethods(Program._HOST, typeof(iWCFDaniil)));

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
    }
}
