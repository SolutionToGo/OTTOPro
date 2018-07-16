using BL;
using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTTOPro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Create a new object, representing the German culture.  
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                if (culture != null)
                {
                    if (culture.ToString() == "de-DE")
                        Utility._IsGermany = true;
                }
                // The following line provides localization for the application's user interface.  
                Thread.CurrentThread.CurrentUICulture = culture;

                // The following line provides localization for data formats.  
                Thread.CurrentThread.CurrentCulture = culture;

                // Set this culture as the default culture for all threads in this application.  
                // Note: The following properties are supported in the .NET Framework 4.5+ 
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmNewLogin());
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}
