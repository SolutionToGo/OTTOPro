using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace OTTOPro
{
    public partial class frmSplashScreen : SplashScreen
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            //timer1.Interval = 100;// 2000;
            //timer1.Enabled = true;
            //timer1.Start();
            //timer1.Tick += new System.EventHandler(OnTimerEvent);
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            //timer1.Stop();
            //this.Hide(); 


        }
    }
}