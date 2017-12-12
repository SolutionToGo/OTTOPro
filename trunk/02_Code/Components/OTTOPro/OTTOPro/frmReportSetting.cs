using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EL;
using BL;
using DevExpress.XtraEditors.Controls;

namespace OTTOPro
{
    public partial class frmReportSetting : DevExpress.XtraEditors.XtraForm
    {
        EReportDesign ObjEReport = null;
        BReportDesign ObjBReport = null;
        public bool _ISave = false;

        public frmReportSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjBReport == null)
                    ObjBReport = new BReportDesign();
                if (ObjEReport == null)
                    ObjEReport = new EReportDesign();
                ParseReportSettings();
                ObjBReport.SaveReportSetting(ObjEReport);
                frmOTTOPro.UpdateStatus("Vorgang abgeschlossen: Speichern des drucken");
                _ISave = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void frmReportSetting_Load(object sender, EventArgs e)
        {
            try
            {
                if (ObjBReport == null)
                    ObjBReport = new BReportDesign();
                if (ObjEReport == null)
                    ObjEReport = new EReportDesign();
                ObjBReport.GetReportSettings(ObjEReport);
                if (ObjEReport.dtReportSettings.Rows.Count > 0)
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void ParseReportSettings()
        {
            try
            {
                if(radioGroupSorting.SelectedIndex==0)
                {
                    ObjEReport.LVPosition = true;
                }
                if (radioGroupSorting.SelectedIndex == 1)
                {
                    ObjEReport.ArticlNr = true;
                }
                if (radioGroupSorting.SelectedIndex == 2)
                {
                    ObjEReport.Lieferant = true;
                }
                if (radioGroupSorting.SelectedIndex == 3)
                {
                    ObjEReport.Fabrikat = true;
                }
                if (radioGroupShowText.SelectedIndex==0)
                {
                    ObjEReport.LangText = true;
                }
                if (radioGroupShowText.SelectedIndex == 1)
                {
                    ObjEReport.KurzText = true;
                }

                foreach (CheckedListBoxItem i in chkSelectOptions.CheckedItems)
                {
                    string _value = i.Value.ToString();

                    if (_value =="sender")
                    {
                        ObjEReport.Sender = true;
                    }
                    if (_value=="menge")
                    {
                        ObjEReport.Menge = true;
                    }
                    if (_value=="GB")
                    {
                        ObjEReport.GB = true;
                    }
                    if (_value=="prices")
                    {
                        ObjEReport.Prices = true;
                    }
                    if (_value=="EP")
                    {
                        ObjEReport.EP = true;
                    }
                }                
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void BindData()
        {
            try
            {
                bool _values = false;
                foreach (DataRow row in ObjEReport.dtReportSettings.Rows)
                {
                    //Sorting
                    if (bool.TryParse(row["LVPosition"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 0;
                        }
                    }
                    if (bool.TryParse(row["Fabrikat"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 3;
                        }
                    }
                    if (bool.TryParse(row["ArticleNr"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 1;
                        }
                    }
                    if (bool.TryParse(row["LieferantMA"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupSorting.SelectedIndex = 2;
                        }
                    }
                    //Select Text
                    if (bool.TryParse(row["LangText"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupShowText.SelectedIndex = 0;
                        }
                    }
                    if (bool.TryParse(row["KurzText"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            radioGroupShowText.SelectedIndex = 1;
                        }
                    }
                    //Selection Option
                    if (bool.TryParse(row["Sender"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(0, true);
                        }
                    }
                    if (bool.TryParse(row["Menge"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(1, true);
                        }
                    }
                    if (bool.TryParse(row["GB"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(2, true);
                        }
                    }
                    if (bool.TryParse(row["EP"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(4, true);
                        }
                    }
                    if (bool.TryParse(row["Prices"].ToString(), out _values))
                    {
                        if (_values == true)
                        {
                            chkSelectOptions.SetItemChecked(3, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

//************************
    }
}