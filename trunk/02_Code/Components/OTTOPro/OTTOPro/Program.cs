using BL;
using DevExpress.LookAndFeel;
using log4net;
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
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                log4net.Config.XmlConfigurator.Configure();

                AppDomain.CurrentDomain.FirstChanceException += (sender, e) =>
                {
                    System.Text.StringBuilder msg = new System.Text.StringBuilder();
                    msg.AppendLine("Version 9.5.8 - UAT  ");
                    msg.AppendLine(e.Exception.GetType().FullName);
                    msg.AppendLine(e.Exception.Message);
                    System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                    msg.AppendLine(st.ToString());
                    msg.AppendLine();
                    Log.Error(msg);
                };
                Application.Run(new frmNewLogin());
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }
    }
}
