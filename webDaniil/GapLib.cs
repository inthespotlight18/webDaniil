using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAPP
{
    public class GapLib
    {

        public static string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

    }
}
