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
    public class DMulti
    {
        public EMulti GetArticleGroups(EMulti ObjEMulti)
        {
            try
            {
                ObjEMulti.dtArticles = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_WGForMulti]";
                    cmd.Parameters.Add("@ProjectID", ObjEMulti.ProjectID);
                    cmd.Parameters.Add("@LVSection", ObjEMulti.LVSection);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ObjEMulti.dtArticles);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Artikelgruppen");
                }
                else
                {
                    throw new Exception("Error while retrieving article groups");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEMulti;
        }

        public EMulti UpdateMulti5(EMulti ObjEMulti)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_Multi]";
                    cmd.Parameters.Add("@ProjectID", ObjEMulti.ProjectID);
                    cmd.Parameters.Add("@LVSection", ObjEMulti.LVSection);
                    cmd.Parameters.Add("@dt", ObjEMulti.dtArticles);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Aktualisierung von Multi 5");
                }
                else
                {
                    throw new Exception("Error while updating multi5");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEMulti;
        }

        public EMulti GetArticleGroupsForMulti6(EMulti ObjEMulti)
        {
            try
            {
                ObjEMulti.dtArticles = new DataTable();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_WGForMulti6]";
                    cmd.Parameters.Add("@ProjectID", ObjEMulti.ProjectID);
                    cmd.Parameters.Add("@LVSection", ObjEMulti.LVSection);
                    cmd.Parameters.Add("@Type", ObjEMulti.Type);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ObjEMulti.dtArticles);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Laden der Artikelgruppen");
                }
                else
                {
                    throw new Exception("Error while retrieving article groups");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEMulti;
        }

        public EMulti UpdateMulti6(EMulti ObjEMulti)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Upd_Multi6]";
                    cmd.Parameters.Add("@ProjectID", ObjEMulti.ProjectID);
                    cmd.Parameters.Add("@LVSection", ObjEMulti.LVSection);
                    cmd.Parameters.Add("@dt", ObjEMulti.dtArticles);
                    cmd.Parameters.Add("@Type", ObjEMulti.Type);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Aktualisierung von Multi 6");
                }
                else
                {
                    throw new Exception("Error while updating multi6");
                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEMulti;
        }
    }
}
