using OTTOProAddin;
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
    public partial class frmCustomerMaster : Form
    {
        ECustomer ObjECustomer = new ECustomer();
        BCustomer ObjBCustomer = new BCustomer();
        DataTable _dtCustomer =null;
        DataTable _dtContact = new DataTable();
        DataTable _CustomerDetails = new DataTable();
        int _CustomerID;

        public frmCustomerMaster()
        {
            InitializeComponent();
        }

        public void BindCustomerData()
        {
            try
            {
                ObjBCustomer.GetCustomers(ObjECustomer);
                if (ObjECustomer.dsCustomer != null)
                {
                    //DataView dvCustomer = ObjECustomer.dsCustomer.Tables[0].DefaultView;
                    //dvCustomer.RowFilter = "IsActive = '" + false + "'";
                    //_dtCustomer = dvCustomer.ToTable();
                    _dtCustomer = ObjECustomer.dsCustomer.Tables[0];
                    cmbCustomerName.DataSource = ObjECustomer.dsCustomer.Tables[0];
                    cmbCustomerName.DisplayMember = "CustomerFullName";
                    cmbCustomerName.ValueMember = "CustomerID";
                    cmbCustomerName.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            BindCustomerData();
            cmbCustomerName.DropDownHeight = cmbCustomerName.ItemHeight * 8;
        }

        private void cmbCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbCustomerName.Text != string.Empty)
                {
                    if (int.TryParse(cmbCustomerName.SelectedValue.ToString(), out _CustomerID))

                        if (_CustomerID > 0)
                        {
                            _dtCustomer = ObjECustomer.dsCustomer.Tables[0].Copy();
                            DataView dvCustomerDetails = _dtCustomer.DefaultView;
                            dvCustomerDetails.RowFilter = "CustomerID = '" + _CustomerID + "'";
                            _CustomerDetails = dvCustomerDetails.ToTable();                            
                        }
                }
                txtDescription.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void FillDetails(string _Type)
        {
            try
            {
                if (_CustomerDetails.Rows.Count > 0 || _CustomerDetails != null)
                {
                    switch (_Type)
                    {
                        case "FullName":
                            foreach (DataRow row in _CustomerDetails.Rows)
                            {
                                txtDescription.Text = string.Empty;
                                txtDescription.Text = row["CustomerFullName"].ToString();
                            }
                            break;

                        case "ShortName":
                            foreach (DataRow row in _CustomerDetails.Rows)
                            {
                                txtDescription.Text = string.Empty;
                                txtDescription.Text = row["CustomerShortName"].ToString();
                            }
                            break;

                        case "Address":
                            foreach (DataRow row in _CustomerDetails.Rows)
                            {
                                txtDescription.Text = string.Empty;
                                txtDescription.AppendText(row["CustomerFullName"].ToString() + "\r\n" + row["Street"].ToString() + "\r\n" + row["PostalCode"].ToString()
                                    + "\r\n" + row["City"].ToString() + "\r\n" + row["Country"].ToString() + "\r\n" + row["ILN"].ToString()
                                    + "\r\n" + row["Telephone"].ToString() + "\r\n" + row["EmailID"].ToString());
                                txtDescription.ScrollToCaret();
                            }
                            break;

                        case "ContactPerson":

                            txtDescription.Text = string.Empty;
                            DataView dvContactPerson = ObjECustomer.dsCustomer.Tables[1].DefaultView;
                            dvContactPerson.RowFilter = "CustomerID = " + _CustomerID + " AND  DefaultContact = '" + true + "'";
                            
                            _dtContact = dvContactPerson.ToTable();
                            foreach (DataRow row in _dtContact.Rows)
                            {
                                txtDescription.Text = row["ContatPersonName"].ToString();
                            }

                            break;

                        case "ContactMail":
                            txtDescription.Text = string.Empty;
                            DataView dvContactMail = ObjECustomer.dsCustomer.Tables[1].DefaultView;
                            dvContactMail.RowFilter = "CustomerID = " + _CustomerID + " AND DefaultContact = '" + true + "'";
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

        private void rbFullName_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("FullName");
        }

        private void rbShortName_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("ShortName");
        }

        private void rbAddress_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("Address");
        }

        private void rbContactPerson_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("ContactPerson");
        }

        private void rbContactEmail_CheckedChanged(object sender, EventArgs e)
        {
            FillDetails("ContactMail");
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

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

//************
    }
}
