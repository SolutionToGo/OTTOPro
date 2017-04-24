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
    public class DDeliveryNotes
    {
        public EDeliveryNotes GetPositions(EDeliveryNotes ObjEDeliveryNotes)
        {
            DataSet dsPositions = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_PositionsForDelivery]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEDeliveryNotes.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositions);
                    }
                    ObjEDeliveryNotes.dtPositions = dsPositions.Tables[0];
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    throw new Exception("To Be Updated");
                else
                    throw new Exception("Error While Retrieving the Positions");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes SaveDelivery(EDeliveryNotes ObjEDeliveryNotes)
        {
            DataSet dsDeliveryNumbers = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Delivery]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEDeliveryNotes.ProjectID);
                    cmd.Parameters.AddWithValue("@DeliveryNumberID", ObjEDeliveryNotes.DeliveryNumberID);
                    cmd.Parameters.AddWithValue("@DeliveryNumber", ObjEDeliveryNotes.DeliveryNumber);
                    cmd.Parameters.AddWithValue("@dtPositions", ObjEDeliveryNotes.dtDelivery);
                    cmd.Parameters.AddWithValue("@ISActiveDelivery", ObjEDeliveryNotes.ISActiveDelivery);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsDeliveryNumbers);
                    }
                    int iValue =0;
                    if(dsDeliveryNumbers != null && dsDeliveryNumbers.Tables.Count > 0)
                    {
                        string strDNID = dsDeliveryNumbers.Tables[0].Rows[0][0].ToString();
                        if(!string.IsNullOrEmpty(strDNID) && int.TryParse(strDNID,out iValue))
                        {
                            ObjEDeliveryNotes.DeliveryNumberID = iValue;
                            ObjEDeliveryNotes.dtDeliveryNumbers = dsDeliveryNumbers.Tables[1];
                            if(dsDeliveryNumbers.Tables.Count > 1)
                                ObjEDeliveryNotes.dtPositions = dsDeliveryNumbers.Tables[2];
                        }
                        else
                            throw new Exception(strDNID);
                    }
                    else
                        throw new Exception("Error While Saving Delivery");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                    throw new Exception("Delivery Number Already Exists, Enter Another One");
                else
                    throw new Exception("Error While Saving Delivery");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes GetNonActiveDelivery(EDeliveryNotes ObjEDeliveryNotes)
        {
            DataSet dsPositions = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_NonActivedelivery]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEDeliveryNotes.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositions);
                    }
                    ObjEDeliveryNotes.dtNonActivedelivery = dsPositions.Tables[0];
                    if (ObjEDeliveryNotes.dtNonActivedelivery.Rows.Count > 0)
                    {
                        ObjEDeliveryNotes.DeliveryNumberID = dsPositions.Tables[1].Rows[0]["DeliveryNumberID"] == DBNull.Value
                            ? -1 : Convert.ToInt32(dsPositions.Tables[1].Rows[0]["DeliveryNumberID"]);
                        ObjEDeliveryNotes.DeliveryNumber = dsPositions.Tables[1].Rows[0]["DeliveryNumberName"] == DBNull.Value
                            ? "" : dsPositions.Tables[1].Rows[0]["DeliveryNumberName"].ToString();

                        ObjEDeliveryNotes.BlattNumber = dsPositions.Tables[2].Rows.Count;
                        ObjEDeliveryNotes.BlattName = dsPositions.Tables[2].Rows[0]["BlattNumberName"] == DBNull.Value
                            ? "" : dsPositions.Tables[2].Rows[0]["BlattNumberName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    throw new Exception("To Be Updated");
                else
                    throw new Exception("Error While Retrieving the Positions");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes GetdeliveryNumbers(EDeliveryNotes ObjEDeliveryNotes)
        {
            DataSet dsDeliveryNumbers = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_DeliveryNumbers]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEDeliveryNotes.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsDeliveryNumbers);
                    }
                    ObjEDeliveryNotes.dtDeliveryNumbers = dsDeliveryNumbers.Tables[0];
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    throw new Exception("To Be Updated");
                else
                    throw new Exception("Error While Retrieving the Delivery Numbers");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEDeliveryNotes;
        }

    }
}
