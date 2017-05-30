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
    public class DUserInfo
    {
        public int SaveUserDetails(XmlDocument XmlDoc, EUserInfo ObjEUserInfo)
        {
            int UserID = -1;
            DataSet ds = new DataSet();
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_UserInfo]";
                    SqlParameter param = new SqlParameter("@XMLUserInfo", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out UserID))
                        {
                            ObjEUserInfo.UserID = UserID;
                            ObjEUserInfo.dtUserInfo = ds.Tables[0];
                        }
                        else if (str.ToString().Contains("UNIQUE"))
                        {
                            throw new Exception("UserName is already exists.!");
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
            return UserID;
        }

        public DataSet GetUser()
        {
            DataSet dsUser = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_UserInfo]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsUser);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                   // throw new Exception("Fehler beim Laden des Kunden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Users");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsUser;
        }

        public int SaveUserRoles(XmlDocument XmlDoc, EUserInfo ObjEUserInfo)
        {
            int RoleID = -1;
            DataSet ds = new DataSet();
            try
            {

                string innerxml = XmlDoc.InnerXml.Replace(',', '.');
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_UserRole]";
                    SqlParameter param = new SqlParameter("@XMLUserRole", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    string str = ds.Tables[0].Rows[0][0] == DBNull.Value ? "" : ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (int.TryParse(str, out RoleID))
                        {
                            ObjEUserInfo.RoleID = RoleID;
                            ObjEUserInfo.dtUserRole = ds.Tables[0];
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
            return RoleID;
        }

        public DataSet GetUserRoles()
        {
            DataSet dsUserRole = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_UserRoles]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsUserRole);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    // throw new Exception("Fehler beim Laden des Kunden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving UserRoles");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsUserRole;
        }

        public EUserInfo GetFeatureDetails(EUserInfo ObjEUserInfo)
        {
            DataSet dsFeature = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_Feature]";
                    cmd.Parameters.Add("@RoleID", ObjEUserInfo.RoleID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsFeature);
                    }
                    if (dsFeature != null && dsFeature.Tables.Count > 0)
                    {
                        ObjEUserInfo.dtFeature = dsFeature.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    // throw new Exception("Fehler beim Laden des Kunden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Data");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEUserInfo;
        }

        public EUserInfo GetAceesLevels(EUserInfo ObjEUserInfo)
        {
            DataSet dsAccessLevels = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_AccessLevels]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsAccessLevels);
                    }
                    if (dsAccessLevels != null && dsAccessLevels.Tables.Count > 0)
                    {
                        ObjEUserInfo.dtAccessLevels = dsAccessLevels.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    // throw new Exception("Fehler beim Laden des Kunden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Access Levels");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEUserInfo;
        }

        public EUserInfo SaveFeatureMap(EUserInfo ObjEUserInfo,DataTable dt)
        {
            DataSet dsFeature = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_RoleFeatureMap]";
                    cmd.Parameters.Add("@RoleID", ObjEUserInfo.RoleID);
                    cmd.Parameters.Add("@dtFeatureMap", dt);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsFeature);
                    }
                    if (dsFeature != null && dsFeature.Tables.Count > 0)
                    {
                        ObjEUserInfo.dtFeature = dsFeature.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    // throw new Exception("Fehler beim Laden des Kunden");
                }
                else
                {
                    throw new Exception("Error Occured While Retreiving Data");

                }
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEUserInfo;
        }

        public EUserInfo CheckUserCredentials(EUserInfo ObjEUserInfo)
        {
            DataSet dsFeature = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_CheckUserCredentials]";
                    cmd.Parameters.Add("@UserName", ObjEUserInfo.UserName);
                    cmd.Parameters.Add("@Password", ObjEUserInfo.Password);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsFeature);
                    }
                    if (dsFeature != null && dsFeature.Tables.Count > 0)
                    {
                        string strUserID = dsFeature.Tables[0].Rows[0][0].ToString();
                        int UserID = 0;
                        if (int.TryParse(strUserID, out UserID))
                        {
                            ObjEUserInfo.dtUserDetails = dsFeature.Tables[0];
                            if (dsFeature.Tables.Count > 1)
                                ObjEUserInfo.dtFeature = dsFeature.Tables[1];
                        }
                        else
                        {
                            throw new Exception(strUserID);
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
            return ObjEUserInfo;
        }
    }
}
