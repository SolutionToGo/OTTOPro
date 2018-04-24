using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DFormBlatt
    {
        public EFormBlatt Get_tbl221_1(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                DataSet ds = new DataSet();
                ObjEFormBlatt.dtBlatt221_1 = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_tbl221_1]";
                    cmd.Parameters.Add("@ProjectID", ObjEFormBlatt.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        ObjEFormBlatt.dtBlatt221_1=ds.Tables[0];
                        ObjEFormBlatt.dtProjectDetails = ds.Tables[1];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden des Formblatts");
                }
                else
                {
                    throw new Exception("Error while retrieving form blatt");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt Get_tbl221_2(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                DataSet ds = new DataSet();
                ObjEFormBlatt.dtBlatt221_2 = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_tbl221_2]";
                    cmd.Parameters.Add("@ProjectID", ObjEFormBlatt.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        ObjEFormBlatt.dtBlatt221_2 = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    // throw new Exception("Fehler beim Laden der Generellen Kosten");
                }
                else
                {
                    throw new Exception("Error while retrieving form blatt");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt GetFormBlatttype(EFormBlatt ObjEFormBlatt)
        {
            DataSet dsFormBlatt = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_FormBlattType]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsFormBlatt);
                    }
                    if (dsFormBlatt != null && dsFormBlatt.Tables.Count > 0)
                    {
                        ObjEFormBlatt.dtBlattTypes = dsFormBlatt.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Ein Fehler ist aufgetreten beim Laden des Formulars (Kostentypen)");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Access FormBlatt Types");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt Get_FormBlattArticles(EFormBlatt ObjEFormBlatt)
        {
            DataSet dsFormBlattArticle = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_FormBlattArticlesByType]";
                    cmd.Parameters.Add("@LookUpID", ObjEFormBlatt.LookUpID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsFormBlattArticle);
                    }
                    if (dsFormBlattArticle != null && dsFormBlattArticle.Tables.Count > 0)
                    {
                        ObjEFormBlatt.dtBlattArticles = dsFormBlattArticle.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {

                    throw new Exception("Ein Fehler ist aufgetreten beim Laden des Formulars (Artikel)");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving FormBlatt Articles");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt Save_FormBlattArticles(EFormBlatt ObjEFormBlatt,DataTable _dt)
        {
            DataSet dsFormBlattArticle = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_FormBlattarticles]";
                    cmd.Parameters.Add("@LookupID", ObjEFormBlatt.LookUpID);
                    cmd.Parameters.Add("@dtBlattArticles", _dt);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsFormBlattArticle);
                    }                    
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Ein Fehler ist aufgetreten beim Speichern des Formulars");
                }
                else
                {
                    throw new Exception("Error Occured While Saving Titles Articles");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEFormBlatt;
        }

        public EFormBlatt GetFormBlattMapping(EFormBlatt ObjEFormBlatt)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_FormBlattMapping]";
                    cmd.Parameters.Add("@ProjectID", ObjEFormBlatt.ProjectID);
                    Object ObjReturn = cmd.ExecuteScalar();
                    if (!string.IsNullOrEmpty(Convert.ToString(ObjReturn)))
                        throw new Exception("Please Assign Articles to 'Nachunternehmerleistungen/Stoffkosten'");
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
            return ObjEFormBlatt;
        }
    }
}
