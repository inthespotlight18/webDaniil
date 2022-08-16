using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAPP
{
    public class Gap
    {
        static public bool Test = webDaniil.Properties.Settings.Default.Test;

        public static string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

    }
}
