using System.Text;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;

using System.ComponentModel;



// http://www.codeproject.com/Articles/571813/A-Beginners-Tutorial-on-Creating-WCF-REST-Services

//https://journalofasoftwaredev.wordpress.com/2008/07/16/multiple-instances-of-same-windows-service/


// GS220704 (V1.21.1.13) - ProjectInstaller : RetrieveServiceName()

namespace webDaniil
{

    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceInstaller service;
        private ServiceProcessInstaller process;

        private void RetrieveServiceName()
        {
            object serviceName = Context.Parameters["servicename"];
            if (!string.IsNullOrEmpty((string)serviceName))
            {
                this.service.ServiceName = (string)serviceName;
                this.service.DisplayName = (string)serviceName;
            }
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            RetrieveServiceName();
            base.Install(stateSaver);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            RetrieveServiceName();
            base.Uninstall(savedState);
        }

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            service = new ServiceInstaller();
            service.ServiceName = Program.SERVICE_NAME;
            service.Description = string.Format("DZ WindowsServiceCS (V{0} DZ220814) by GarNet RC 604-512-6200", "[V1.0]");

            Installers.Add(process);
            Installers.Add(service);
        }

    }

}