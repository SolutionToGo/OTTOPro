using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace DataAccess
{
    public class DSupplier
    {
        public ESupplier SaveSupplierDetails(XmlDocument XmlDoc,ESupplier ObjESupplier)
        {
            int SupplierID = -1;
            DataSet ds = new DataSet();
            try
            {

                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Supplier]";
                    SqlParameter param = new SqlParameter("@XMLSupplier", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out SupplierID))
                        {
                            ObjESupplier.SupplierID = SupplierID;
                            ObjESupplier.dtSupplier = ds.Tables[1];
                        }
                        else if (str.ToString().Contains("duplicate"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Dieser Kurzname ist bereits vergeben");
                            }
                            else
                            {
                                throw new Exception("ShortName is already exists.!");
                            }
                        }
                        else
                            throw new Exception(str);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public DataSet GetSupplier()
        {
            DataSet dsSupplier = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_Supplier]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsSupplier);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden des Kunden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Customer");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsSupplier;
        }

        public ESupplier SavedsSupplierContactDetails(XmlDocument XmlDoc,ESupplier ObjESupplier)
        {
            DataSet ds = new DataSet();
            int ContactPersonID = -1;
            try
            {
                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Supplier_Contact]";
                    SqlParameter param = new SqlParameter("@XMLSupplierContact", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out ContactPersonID))
                        {
                            ObjESupplier.ContactPersonID = ContactPersonID;
                            ObjESupplier.dtContact = ds.Tables[1];
                        }
                        else
                        {
                            throw new Exception(str);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier SaveSupplierAddressDetails(XmlDocument XmlDoc, ESupplier ObjESupplier)
        {
            DataSet ds = new DataSet();
            int AddressID = -1;
            try
            {
                string innerxml = XmlDoc.InnerXml;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Supplier_Address]";
                    SqlParameter param = new SqlParameter("@XMLSupplierAddress", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out AddressID))
                        {
                            ObjESupplier.AddressID = AddressID;
                            ObjESupplier.dtAddress = ds.Tables[1];
                        }
                        else if (str.ToString().Contains("DefaultAddress"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Diese Standardadresse existiert bereits");
                            }
                            else
                            {
                                throw new Exception("Default Address is already exists.!");
                            }
                        }
                        else
                            throw new Exception(str);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier SaveArticle(ESupplier ObjESupplier)
        {
             DataSet ds = new DataSet();
            int iArtcleID = -1;
            try
            {
                using ( SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_WGWA]";
                    cmd.Parameters.AddWithValue("@WGWAID", ObjESupplier.WGWAID);
                    cmd.Parameters.AddWithValue("@SupplierID", ObjESupplier.SupplierID);
                    cmd.Parameters.AddWithValue("@WG", ObjESupplier.WG);
                    cmd.Parameters.AddWithValue("@WA", ObjESupplier.WA);
                    cmd.Parameters.AddWithValue("@WGDescription", ObjESupplier.WGDescription);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out iArtcleID))
                        {
                            ObjESupplier.WGWAID = iArtcleID;
                            ObjESupplier.dtArticle = ds.Tables[1];
                        }
                        else if (str.ToString().Contains("UNIQUE"))
                        {
                            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                            {
                                throw new Exception("Der Artikel existiert bereits.");
                            }
                            else
                            {
                                throw new Exception("Article already exists..!");
                            }
                        }
                        else
                            throw new Exception(str);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        //SUPPLIER PROPOSAL
        public DataSet GetWGWaforProposal(int _Pid, string _LvSection, string wg, string wa)
        {
            DataSet dsWGWA = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_WGWAForProposal]";
                    cmd.Parameters.AddWithValue("@ProjectID", _Pid);
                    cmd.Parameters.AddWithValue("@LVSection", _LvSection);
                    cmd.Parameters.AddWithValue("@WG", wg);
                    cmd.Parameters.AddWithValue("@WA", wa);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsWGWA);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Daten");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving records");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsWGWA;
        }

        public DataSet GetLVSectionforProposal(int _Pid)
        {
            DataSet dsWGWA = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_LVSectionForProposal]";
                    cmd.Parameters.AddWithValue("@ProjectID", _Pid);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsWGWA);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Daten");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving records");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsWGWA;
        }

        public int SaveSupplierProposal(int _Pid, string _LvSection, string wg, string wa, DataTable _dtPosition, DataTable _dtSupplier, DataTable _dtDeletedPositions)
        {
            DataSet ds = new DataSet();
            int ProposalID = -1;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_SupplierProposal]";
                    cmd.Parameters.AddWithValue("@ProjectID", _Pid);
                    cmd.Parameters.AddWithValue("@LVSection", _LvSection);
                    cmd.Parameters.AddWithValue("@WG", wg);
                    cmd.Parameters.AddWithValue("@WA", wa);
                    cmd.Parameters.AddWithValue("@dtPositionID", _dtPosition);
                    cmd.Parameters.AddWithValue("@dtSupplierID", _dtSupplier);
                    cmd.Parameters.AddWithValue("@dtDeletedPositions", _dtDeletedPositions);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (!int.TryParse(str, out ProposalID))
                        {
                            throw new Exception(str);
                        }
                           
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot"))
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Die Preisanfrage ist auf 8 Lieferanten begrenzt");
                    else
                        throw new Exception("Cannot send proposal to more than 8 suppliers");
                }
                else
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Fehler beim Laden der Daten");
                    else
                        throw new Exception("Error occured while saving suplier proposal");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ProposalID;
        }

        public ESupplier GetProposalNumber(ESupplier ObjESupplier)
        {
            DataSet dsWGWA = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_SupplierProposal]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjESupplier.ProjectID);
                    cmd.Parameters.AddWithValue("@LVSsection", ObjESupplier.LVSection);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsWGWA);
                    }
                    if(dsWGWA != null && dsWGWA.Tables.Count > 0)
                    {
                        ObjESupplier.dtProposal = dsWGWA.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Daten");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving records");
                }                    
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier GetProposalPostions(ESupplier ObjESupplier)
        {
            DataSet dsPositions = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionsForProposal]";
                    cmd.Parameters.AddWithValue("@SupplierProposalID", ObjESupplier.SupplierProposalID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositions);
                    }
                    if (dsPositions != null && dsPositions.Tables.Count > 0)
                    {
                        ObjESupplier.dtPositions = dsPositions.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der LV Position");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Positions");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier UpdateSupplierPrice(ESupplier ObjESupplier)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[p_Upd_SupplierPrice]";
                    cmd.Parameters.AddWithValue("@dtPositons", ObjESupplier.dtUpdateSupplierPrice);
                    cmd.Parameters.AddWithValue("@ProjectID", ObjESupplier.ProjectID);
                    object ObjReturn = cmd.ExecuteScalar();
                    if(ObjReturn != null)
                    {
                        string str =Convert.ToString(ObjReturn);
                        if (!string.IsNullOrEmpty(str))
                        {
                            if(str.Contains("Zero"))
                            {
                                throw new Exception("Einige LV Positionen haben keinen Preiseintrag");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier SaveDeletePosition(ESupplier ObjESupplier)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_DeletePosition]";
                    cmd.Parameters.AddWithValue("@PositionID", ObjESupplier.PositionID);
                    cmd.Parameters.AddWithValue("@ProjectID", ObjESupplier.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }                  
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier SaveProposaleValues(ESupplier ObjESupplier)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_ProposalValues]";
                    cmd.Parameters.AddWithValue("@PostionID", ObjESupplier.PositionID);
                    cmd.Parameters.AddWithValue("@SupplierProposalID", ObjESupplier.SupplierProposalID);
                    cmd.Parameters.AddWithValue("@SupplierPrice", ObjESupplier.SupplierPrice);
                    cmd.Parameters.AddWithValue("@Multi1", ObjESupplier.Multi1);
                    cmd.Parameters.AddWithValue("@Multi2", ObjESupplier.Multi2);
                    cmd.Parameters.AddWithValue("@Multi3", ObjESupplier.Multi3);
                    cmd.Parameters.AddWithValue("@Multi4", ObjESupplier.Multi4);
                    cmd.Parameters.AddWithValue("@Fabrikate", ObjESupplier.Fabrikate);
                    cmd.Parameters.AddWithValue("@SupplierName", ObjESupplier.SupplierName);
                    cmd.Parameters.AddWithValue("@IsSingle", ObjESupplier.IsSingle);
                    object Objreturn = cmd.ExecuteScalar();
                    if (Objreturn != null)
                    {
                        int iValue = 0;
                        if (!int.TryParse(Convert.ToString(Objreturn), out iValue))
                            throw new Exception(Objreturn.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Speichern des Listenpreises");
                }
                else
                {
                    throw new Exception("Error While Saving the ListPrice");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier SaveSelection(ESupplier ObjESupplier)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_SaveSelection]";
                    cmd.Parameters.AddWithValue("@PositionID", ObjESupplier.PositionID);
                    cmd.Parameters.AddWithValue("@SupplierProposalID", ObjESupplier.SupplierProposalID);
                    cmd.Parameters.AddWithValue("@SelectedSupplier", ObjESupplier.SelectedColumn);
                    cmd.Parameters.AddWithValue("@NotSelectedSupplier", ObjESupplier.UncheckedColumn);
                    cmd.Parameters.AddWithValue("@IsSelected", ObjESupplier.IsSelected);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier GetSupplierMail(ESupplier ObjESupplier,int ProposalID,int ProjectID)
        {
            DataSet dsMail = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_SupplierMailID]";
                    cmd.Parameters.AddWithValue("@ProposalID", ProposalID);
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsMail);
                    }
                    if (dsMail != null && dsMail.Tables.Count > 0)
                    {
                        ObjESupplier.dtSupplierMail = dsMail.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Laden der Daten");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier CheckSupplierArticle(ESupplier ObjESupplier)
        {
            DataSet dsCheckSupplier = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Chk_SupplierArticle]";
                    cmd.Parameters.AddWithValue("@SupplierPorposalID", ObjESupplier.SupplierProposalID);
                    cmd.Parameters.AddWithValue("@SupplierID", ObjESupplier.SupplierID);
                    cmd.Parameters.AddWithValue("@WG", ObjESupplier.WG);
                    cmd.Parameters.AddWithValue("@WA", ObjESupplier.WA);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsCheckSupplier);
                    }
                    if(dsCheckSupplier != null)
                    {
                        if (dsCheckSupplier.Tables.Count > 0 && dsCheckSupplier.Tables[0].Rows.Count > 0)
                        {
                            ObjESupplier.strArticleExists = Convert.ToString(dsCheckSupplier.Tables[0].Rows[0][0]);
                            if (dsCheckSupplier.Tables.Count > 1 && dsCheckSupplier.Tables[1].Rows.Count > 0)
                            {
                                ObjESupplier.strSupplierExists = Convert.ToString(dsCheckSupplier.Tables[1].Rows[0][0]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Laden der Daten");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier UpdateSupplierProposal(ESupplier ObjESupplier)
        {
            DataSet dsWGWA = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_SupplierProposal]";
                    cmd.Parameters.AddWithValue("@SupplierProposalID", ObjESupplier.SupplierProposalID);
                    cmd.Parameters.AddWithValue("@SupplierID", ObjESupplier.SupplierID);
                    cmd.Parameters.AddWithValue("@ProjectID", ObjESupplier.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsWGWA);
                    }
                    if (dsWGWA != null && dsWGWA.Tables.Count > 0)
                    {
                        int IValue = 0;
                        if (int.TryParse(Convert.ToString(dsWGWA.Tables[0].Rows[0][0]), out IValue))
                            ObjESupplier.dtProposal = dsWGWA.Tables[0];
                        else
                            throw new Exception(Convert.ToString(dsWGWA.Tables[0].Rows[0][0]));
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot"))
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Die Preisanfrage ist auf 8 Lieferanten begrenzt");
                    else
                        throw new Exception("Cannot send proposal to more than 8 suppliers");
                }
                else
                {
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                        throw new Exception("Fehler beim Laden der Daten");
                    else
                        throw new Exception("Error Occured While Retreiving records");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }

        public ESupplier DeleteSupplierArticleMap(ESupplier ObjESupplier)
        {
            DataSet dsArticle = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Del_ArticleSupplierMap]";
                    cmd.Parameters.AddWithValue("@WGWAID", ObjESupplier.WGWAID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsArticle);
                    }
                    if(dsArticle != null && dsArticle.Tables.Count > 0)
                    {
                        ObjESupplier.dtArticle = dsArticle.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    throw new Exception("Fehler beim Löschen des Artikels");
                else
                    throw new Exception("Error while Deleting Article");
            }
            return ObjESupplier;
        }

        public ESupplier UpdateProposalDate(ESupplier ObjESupplier)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_SupplierproposalDate]";
                    cmd.Parameters.AddWithValue("@SupplierProposalID", ObjESupplier.SupplierProposalID);
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjESupplier;
        }
        
    }
}
