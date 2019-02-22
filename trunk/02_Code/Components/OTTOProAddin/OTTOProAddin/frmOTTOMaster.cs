using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace OTTOProAddin
{
    public partial class frmOTTOMaster : Form
    {
        EOTTO ObjEOTTO = new EOTTO();
        BOTTO ObjBOTTO = new BOTTO();
        DataTable _dtOtto = new DataTable();
        DataTable _dtContact = new DataTable();
        int _OTTOID;
        public frmOTTOMaster()
        {
            InitializeComponent();
        }

        private void frmOTTOMaster_Load(object sender, EventArgs e)
        {
            BindOTTOData();
        }

        public void BindOTTOData()
        {
            try
            {
                ObjBOTTO.GetOTTODetails(ObjEOTTO);
                if (ObjEOTTO.dsOTTO != null)
                {
                    DataView dvOTTO = ObjEOTTO.dsOTTO.Tables[0].DefaultView;
                    dvOTTO.RowFilter = "IsBranch = '" + false + "'";
                    _dtOtto = dvOTTO.ToTable();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void rbFullName_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("FullName");
        }

        private void rbShortName_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("ShortName");
        }

        private void FillDetails(string _Type)
        {
            try
            {
                if (_dtOtto.Rows.Count > 0 || _dtOtto != null)
                {
                    switch(_Type)
                    {
                        case "FullName":
                            foreach (DataRow row in _dtOtto.Rows)
                            {
                                txtDescription.Text = string.Empty;
                                txtDescription.Text = row["FullName"].ToString();
                                _OTTOID =Convert.ToInt32(row["OttoID"]);
                            }
                            break;

                        case "ShortName":
                            foreach (DataRow row in _dtOtto.Rows)
                            {
                                txtDescription.Text = string.Empty;
                                txtDescription.Text = row["ShortName"].ToString();
                            }
                            break;

                        case "Address":
                            foreach (DataRow row in _dtOtto.Rows)
                            {
                                txtDescription.Text = string.Empty;
                                txtDescription.AppendText(row["FullName"].ToString() + "\r\n" + row["Street"].ToString() + "\r\n" + row["PostalCode"].ToString()
                                    + "\r\n" + row["City"].ToString() + "\r\n" + row["Country"].ToString() + "\r\n" + row["ILN"].ToString()
                                    + "\r\n" + row["Telefon"].ToString() + "\r\n" + row["Website"].ToString());
                                txtDescription.ScrollToCaret();
                            }
                            break;

                        case "ContactPerson":
                           
                                txtDescription.Text = string.Empty;
                                DataView dvContactPerson = ObjEOTTO.dsOTTO.Tables[1].DefaultView;
                                dvContactPerson.RowFilter = "OttoID = '" + _OTTOID + "'";
                                _dtContact = dvContactPerson.ToTable();
                                foreach (DataRow row in _dtContact.Rows)
                                {
                                    txtDescription.Text = row["ContactPerson"].ToString();
                                }
                                
                            break;

                        case "ContactMail":
                                txtDescription.Text = string.Empty;
                                DataView dvContactMail = ObjEOTTO.dsOTTO.Tables[1].DefaultView;
                                dvContactMail.RowFilter = "OttoID = '" + _OTTOID + "'";
                                _dtContact = dvContactMail.ToTable();
                                foreach (DataRow row in _dtContact.Rows)
                                {
                                    txtDescription.Text = row["EmailID"].ToString();
                                }

                            break;
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void rbAddress_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("Address");
        }

        private void rbOfcEmail_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("EmailID");
        }

        private void rbContactPerson_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("ContactPerson");
        }

        private void rbContactEmail_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("ContactMail");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                Word.Application WordApp = new Word.Application();
                Word.Document WordDoc = Globals.ThisAddIn.Application.ActiveDocument;
                WordDoc.ActiveWindow.Selection.Text = txtDescription.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

//*************
    }
}
