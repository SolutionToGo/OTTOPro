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

namespace OTTOPro
{
    public partial class frmAccessories : DevExpress.XtraEditors.XtraForm
    {
        List<Control> Requirefields = new List<Control>();
        EArticles ObjEArticles = null;
        BArticles ObjBArticles = null;

        public frmAccessories()
        {
            InitializeComponent();
        }

        private void frmAccessories_Load(object sender, EventArgs e)
        {
            Requirefields.Add(txtParentWG);
            Requirefields.Add(txtParentWA);
            Requirefields.Add(txtParentA);
            Requirefields.Add(txtChildWG);
            Requirefields.Add(txtChildWA);
            Requirefields.Add(txtChildA);
            if (ObjEArticles == null)
                ObjEArticles = new EArticles();
            if (ObjBArticles == null)
                ObjBArticles = new BArticles();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Utility.ValidateRequiredFields(Requirefields))
                    return;
                ObjEArticles.WG = txtParentWG.Text;
                ObjEArticles.WA = txtParentWA.Text;
                ObjEArticles.WI = txtParentWI.Text;
                ObjEArticles.A = txtParentA.Text;
                ObjEArticles.B = txtParentB.Text;
                ObjEArticles.L = txtParentL.Text;
                ObjEArticles.ChildWG = txtChildWG.Text;
                ObjEArticles.ChildWA = txtChildWA.Text;
                ObjEArticles.ChildWI = txtChildWI.Text;
                ObjEArticles.ChildA = txtChildA.Text;
                ObjEArticles.ChildB = txtChildB.Text;
                ObjEArticles.ChildL = txtChildL.Text;
                ObjEArticles.UserID = Utility.UserID;
                ObjEArticles = ObjBArticles.SaveArticleMapping(ObjEArticles);
                BindAccessories();
                ObjEArticles.ChildWG = string.Empty;
                ObjEArticles.ChildWA = string.Empty;
                ObjEArticles.ChildWI = string.Empty;
                txtChildTyp.Text = string.Empty;
                txtChildWG.Text = string.Empty;
                txtChildWA.Text = string.Empty;
                txtChildWI.Text = string.Empty;
                txtChildA.Text = string.Empty;
                txtChildB.Text = string.Empty;
                txtChildL.Text = string.Empty;
                txtChildLifrant.Text = string.Empty;
                txtChildFabrikate.Text = string.Empty;
                txtChildWADescription.Text = string.Empty;
                txtChildWGDescription.Text = string.Empty;
                txtChildWIDescription.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void BindAccessories()
        {
            try
            {
                if (ObjBArticles == null)
                    ObjBArticles = new BArticles();
                if (ObjEArticles == null)
                    ObjEArticles = new EArticles();
                ObjEArticles.WG = txtParentWG.Text;
                ObjEArticles.WA = txtParentWA.Text;
                ObjEArticles.WI = txtParentWI.Text;
                ObjEArticles.A = txtParentA.Text;
                ObjEArticles.B = txtParentB.Text;
                ObjEArticles.L = txtParentL.Text;
                ObjEArticles = ObjBArticles.GetAccessories(ObjEArticles);
                gcArticles.DataSource = ObjEArticles.dtAccessories;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void txtParentWG_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ObjEArticles.WG = txtParentWG.Text;
                    ObjEArticles.WA = txtParentWA.Text;
                    ObjEArticles.WI = txtParentWI.Text;
                    ObjEArticles = ObjBArticles.GetArticleByWG(ObjEArticles);
                    if(ObjEArticles.dtArticleDetails.Rows.Count > 0)
                    {
                        txtParentWG.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WG"]);
                        txtParentWA.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WA"]);
                        txtParentWI.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WI"]);
                        txtParentWGDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WGDescription"]);
                        txtParentWADescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WADescription"]);
                        txtParentWIDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WIDescription"]);
                        txtParentLifrant.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["FullName"]);
                        txtParentFabrikate.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Fabrikate"]);
                        txtParentTyp.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Typ"]);

                        if (ObjEArticles.dtDimenstions != null && ObjEArticles.dtDimenstions.Rows.Count > 0)
                        {
                            if (ObjEArticles.dtDimenstions.Rows.Count > 1)
                            {
                                EPosition ObjEPosition = new EPosition();
                                ObjEPosition.dtDimensions = ObjEArticles.dtDimenstions;
                                frmSelectDimension Obj = new frmSelectDimension();
                                Obj.ObjEPosition = ObjEPosition;
                                Obj.ShowInTaskbar = false;
                                Obj.ShowDialog();
                                txtParentA.Text = ObjEPosition.Dim1;
                                txtParentB.Text = ObjEPosition.Dim2;
                                txtParentL.Text = ObjEPosition.Dim3;
                            }
                            else
                            {
                                txtParentA.Text = ObjEArticles.dtDimenstions.Rows[0]["A"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["A"].ToString();
                                txtParentB.Text = ObjEArticles.dtDimenstions.Rows[0]["B"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["B"].ToString();
                                txtParentL.Text = ObjEArticles.dtDimenstions.Rows[0]["L"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["L"].ToString();
                            }
                        }
                        BindAccessories();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtParentWG_EditValueChanged(object sender, EventArgs e)
        {
            gcArticles.DataSource = null;
        }

        private void txtParentA_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    BindAccessories();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtParentTyp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (ObjBArticles == null)
                        ObjBArticles = new BArticles();
                    if (ObjEArticles == null)
                        ObjEArticles = new EArticles();
                    ObjEArticles.Typ = txtParentTyp.Text;
                    ObjEArticles = ObjBArticles.GetArticleBytyp(ObjEArticles);
                    if (ObjEArticles.dtArticleDetails != null && ObjEArticles.dtArticleDetails.Rows.Count > 0)
                    {
                        txtParentWG.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WG"]);
                        txtParentWA.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WA"]);
                        txtParentWI.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WI"]);
                        txtParentWGDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WGDescription"]);
                        txtParentWADescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WADescription"]);
                        txtParentWIDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WIDescription"]);
                        txtParentLifrant.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["FullName"]);
                        txtParentFabrikate.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Fabrikate"]);
                        txtParentTyp.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Typ"]);
                        if (ObjEArticles.dtDimenstions != null && ObjEArticles.dtDimenstions.Rows.Count > 0)
                        {
                            if (ObjEArticles.dtDimenstions.Rows.Count > 1)
                            {
                                EPosition ObjEPosition = new EPosition();
                                ObjEPosition.dtDimensions = ObjEArticles.dtDimenstions;
                                frmSelectDimension Obj = new frmSelectDimension();
                                Obj.ObjEPosition = ObjEPosition;
                                Obj.ShowInTaskbar = false;
                                Obj.ShowDialog();
                                txtParentA.Text = ObjEPosition.Dim1;
                                txtParentB.Text = ObjEPosition.Dim2;
                                txtParentL.Text = ObjEPosition.Dim3;
                            }
                            else
                            {
                                txtParentA.Text = ObjEArticles.dtDimenstions.Rows[0]["A"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["A"].ToString();
                                txtParentB.Text = ObjEArticles.dtDimenstions.Rows[0]["B"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["B"].ToString();
                                txtParentL.Text = ObjEArticles.dtDimenstions.Rows[0]["L"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["L"].ToString();
                            }
                        }
                        else
                        {
                            txtParentA.Text = string.Empty;
                            txtParentB.Text = string.Empty;
                            txtParentL.Text = string.Empty;
                        }
                        BindAccessories();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtChildWG_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ObjEArticles.WG = txtChildWG.Text;
                    ObjEArticles.WA = txtChildWA.Text;
                    ObjEArticles.WI = txtChildWI.Text;
                    ObjEArticles = ObjBArticles.GetArticleByWG(ObjEArticles);
                    if (ObjEArticles.dtArticleDetails.Rows.Count > 0)
                    {
                        txtChildWG.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WG"]);
                        txtChildWA.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WA"]);
                        txtChildWI.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WI"]);
                        txtChildWGDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WGDescription"]);
                        txtChildWADescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WADescription"]);
                        txtChildWIDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WIDescription"]);
                        txtChildLifrant.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["FullName"]);
                        txtChildFabrikate.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Fabrikate"]);
                        txtChildTyp.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Typ"]);

                        if (ObjEArticles.dtDimenstions != null && ObjEArticles.dtDimenstions.Rows.Count > 0)
                        {
                            if (ObjEArticles.dtDimenstions.Rows.Count > 1)
                            {
                                EPosition ObjEPosition = new EPosition();
                                ObjEPosition.dtDimensions = ObjEArticles.dtDimenstions;
                                frmSelectDimension Obj = new frmSelectDimension();
                                Obj.ObjEPosition = ObjEPosition;
                                Obj.ShowInTaskbar = false;
                                Obj.ShowDialog();
                                txtChildA.Text = ObjEPosition.Dim1;
                                txtChildB.Text = ObjEPosition.Dim2;
                                txtChildL.Text = ObjEPosition.Dim3;
                            }
                            else
                            {
                                txtChildA.Text = ObjEArticles.dtDimenstions.Rows[0]["A"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["A"].ToString();
                                txtChildB.Text = ObjEArticles.dtDimenstions.Rows[0]["B"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["B"].ToString();
                                txtChildL.Text = ObjEArticles.dtDimenstions.Rows[0]["L"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["L"].ToString();
                            }
                        }
                        else
                        {
                            txtChildA.Text = string.Empty;
                            txtChildB.Text = string.Empty;
                            txtChildL.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtChildTyp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (ObjBArticles == null)
                        ObjBArticles = new BArticles();
                    if (ObjEArticles == null)
                        ObjEArticles = new EArticles();
                    ObjEArticles.Typ = txtChildTyp.Text;
                    ObjEArticles = ObjBArticles.GetArticleBytyp(ObjEArticles);
                    if (ObjEArticles.dtArticleDetails != null && ObjEArticles.dtArticleDetails.Rows.Count > 0)
                    {
                        txtChildWG.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WG"]);
                        txtChildWA.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WA"]);
                        txtChildWI.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WI"]);
                        txtChildWGDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WGDescription"]);
                        txtChildWADescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WADescription"]);
                        txtChildWIDescription.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["WIDescription"]);
                        txtChildLifrant.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["FullName"]);
                        txtChildFabrikate.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Fabrikate"]);
                        txtChildTyp.Text = Convert.ToString(ObjEArticles.dtArticleDetails.Rows[0]["Typ"]);
                        if (ObjEArticles.dtDimenstions != null && ObjEArticles.dtDimenstions.Rows.Count > 0)
                        {
                            if (ObjEArticles.dtDimenstions.Rows.Count > 1)
                            {
                                EPosition ObjEPosition = new EPosition();
                                ObjEPosition.dtDimensions = ObjEArticles.dtDimenstions;
                                frmSelectDimension Obj = new frmSelectDimension();
                                Obj.ObjEPosition = ObjEPosition;
                                Obj.ShowInTaskbar = false;
                                Obj.ShowDialog();
                                txtChildA.Text = ObjEPosition.Dim1;
                                txtChildB.Text = ObjEPosition.Dim2;
                                txtChildL.Text = ObjEPosition.Dim3;
                            }
                            else
                            {
                                txtChildA.Text = ObjEArticles.dtDimenstions.Rows[0]["A"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["A"].ToString();
                                txtChildB.Text = ObjEArticles.dtDimenstions.Rows[0]["B"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["B"].ToString();
                                txtChildL.Text = ObjEArticles.dtDimenstions.Rows[0]["L"] == DBNull.Value ? "" : ObjEArticles.dtDimenstions.Rows[0]["L"].ToString();
                            }
                        }
                        else
                        {
                            txtChildA.Text = string.Empty;
                            txtChildB.Text = string.Empty;
                            txtChildL.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowError(ex);
            }
        }

        private void txtParentWG_Enter(object sender, EventArgs e)
        {
            try
            {
                var edit = ((DevExpress.XtraEditors.TextEdit)sender);
                BeginInvoke(new MethodInvoker(() =>
                {
                    edit.SelectionStart = 0;
                    edit.SelectionLength = edit.Text.Length;
                }));
            }
            catch (Exception ex){}
        }
    }
}