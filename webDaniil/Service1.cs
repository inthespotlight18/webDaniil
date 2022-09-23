using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;

namespace webDaniil
{
    public partial class Service1 : ServiceBase
    {
        public static WebServiceHost _HOST { get; set; }
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            File.WriteAllText(@"C:\ServiceLog.txt", "\n OnStart() +_+_+");

            Uri httpUrl = new Uri("http://localhost:80/");

            _HOST = new WebServiceHost(typeof(wcfDaniil.oWCFDaniil), httpUrl);

            var binding = new WebHttpBinding();
            _HOST.AddServiceEndpoint(typeof(wcfDaniil.iWCFDaniil), binding, "wcfDaniil");

            _HOST.Open();
            
        }

        protected override void OnStop()
        {
            File.WriteAllText(@"C:\ServiceLog.txt", "\n OnStop() -_-_-");

            _HOST.Close();
        }

        public void OnDebug()
        { 
            OnStart(null);
        }
    }
}

