﻿using DAL;
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
            DataSet dsBlattDetails = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_BlattDetails]";
                    cmd.Parameters.AddWithValue("@BlattID", ObjEDeliveryNotes.BlattID);
                    cmd.Parameters.AddWithValue("@ProjetcID", ObjEDeliveryNotes.ProjectID);
                    cmd.Parameters.AddWithValue("@BlattNumber", ObjEDeliveryNotes.BlattName);
                    cmd.Parameters.AddWithValue("@IsActiveDelivery", ObjEDeliveryNotes.ISActiveDelivery);
                    cmd.Parameters.AddWithValue("@Delivery", ObjEDeliveryNotes.dtDelivery);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsBlattDetails);
                    }
                    int iValue = 0;
                    if(dsBlattDetails != null & dsBlattDetails.Tables.Count > 0)
                    {
                        string str = dsBlattDetails.Tables[0].Rows[0][0].ToString();
                        if (!int.TryParse(str, out iValue))
                            throw new Exception(str);
                        else if(dsBlattDetails.Tables.Count > 1)
                        {
                            ObjEDeliveryNotes.BlattID = iValue;
                            ObjEDeliveryNotes.dtPositions = dsBlattDetails.Tables[1];
                            if(dsBlattDetails.Tables.Count > 2)
                                ObjEDeliveryNotes.dtBlattNumbers = dsBlattDetails.Tables[2];    
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                    throw new Exception("Diese BLATT Nummer wurde bereits vergeben, bitte machen Sie eine neue Angabe. ");
                else if 
                    (ex.Message.Contains("Valid"))
                    throw new Exception("Bitte machen Sie einige gültige Mengenangabe");
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
                        ObjEDeliveryNotes.BlattID = dsPositions.Tables[1].Rows[0]["BlattID"] == DBNull.Value
                            ? -1 : Convert.ToInt32(dsPositions.Tables[1].Rows[0]["BlattID"]);
                        ObjEDeliveryNotes.BlattName = dsPositions.Tables[1].Rows[0]["BlattNumber"] == DBNull.Value
                            ? "" : dsPositions.Tables[1].Rows[0]["BlattNumber"].ToString();
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

        public EDeliveryNotes GetBlattNumbers(EDeliveryNotes ObjEDeliveryNotes)
        {
            DataSet dsBlattNumbers = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_BlattNumbers]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEDeliveryNotes.ProjectID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsBlattNumbers);
                    }
                    ObjEDeliveryNotes.dtBlattNumbers = dsBlattNumbers.Tables[0];
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

        public EDeliveryNotes GetNewBlattNumber(EDeliveryNotes ObjEDeliveryNotes)
        {
            DataSet dsDeliveryNumbers = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_NewBlattNumber]";
                    cmd.Parameters.AddWithValue("@ProjectID", ObjEDeliveryNotes.ProjectID);
                    object ObjReturn = cmd.ExecuteScalar();
                    if (ObjReturn != null)
                        ObjEDeliveryNotes.BlattName = ObjReturn.ToString();
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    throw new Exception("To Be Updated");
                else
                    throw new Exception("Error While Retrieving the New Blatt Number");
            }
            finally
            {
                SQLCon.Sqlconn().Close();
            }
            return ObjEDeliveryNotes;
        }

        public EDeliveryNotes GetBlattDetails(EDeliveryNotes ObjEDeliveryNotes)
        {
            DataSet dsPositions = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Get_BlattDetails]";
                    cmd.Parameters.AddWithValue("@BlattID", ObjEDeliveryNotes.BlattID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsPositions);
                    }
                    ObjEDeliveryNotes.dtNonActivedelivery = dsPositions.Tables[0];
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
    }
}   