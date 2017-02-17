using DAL;
using EL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccess
{
    public class DPosition
    {
        public int SavePositionDetails(XmlDocument XmlDoc,byte[] LongDescription)
        {
            int ProjectID = -1;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Position]";
                    SqlParameter param = new SqlParameter("@XMLPositions", SqlDbType.Xml);
                    param.Value = XmlDoc.InnerXml;
                    cmd.Parameters.Add(param);
                    cmd.Parameters.AddWithValue("@LongDescription", LongDescription);

                    object returnObj = cmd.ExecuteScalar();
                    if (returnObj != null)
                    {
                        if (returnObj.ToString().Contains("UNIQUE"))
                            throw new Exception("OZ Already Exists");
                        else if (!int.TryParse(returnObj.ToString(), out ProjectID))
                            throw new Exception("Error Occured While Saving the Position Details");
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
            return ProjectID;
        }

        public DataSet GetPsoitionList(int ProjectID)
        {
            DataSet dsPositionsList = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionList]";
                    cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositionsList, "Positions");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured While Retreiving Position List");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return dsPositionsList;
        }

        public byte[] GetLongDescription(int PositionID)
        {
            byte[] LongDescription = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_LongDescription]";
                    cmd.Parameters.AddWithValue("@PositionID", PositionID);
                    Object ObjReturn = cmd.ExecuteScalar();
                    if (ObjReturn != null && ObjReturn != DBNull.Value)
                    {
                        IEnumerable en = (IEnumerable)ObjReturn;
                        LongDescription = en.OfType<byte>().ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured While Retreiving Position List");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return LongDescription;
        }

        public DataTable GetPositionKZ()
        {
            DataTable dt = null;
            try
            {
                 using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionList]";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }
    }
}
