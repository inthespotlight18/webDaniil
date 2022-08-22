using System.Reflection;

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
