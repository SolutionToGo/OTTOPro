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
   public class DArticles
    {
       public EArticles SaveArticle(XmlDocument xml, EArticles ObjEArticle)
        {
            DataSet dsArticles = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string innerxml = xml.InnerXml.Replace(',', '.');
                    cmd.Connection = SQLCon.Sqlconn();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[P_Ins_Article]";
                    SqlParameter param = new SqlParameter("@XMLArticle", SqlDbType.Xml);
                    param.Value = innerxml;
                    cmd.Parameters.Add(param);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dsArticles);
                    }
                    if(dsArticles != null && dsArticles.Tables.Count > 0)
                    {
                        int iValue = 0;
                        int iValue1 = 0;
                        string str = dsArticles.Tables[0].Rows[0][0] == DBNull.Value ? "" : dsArticles.Tables[0].Rows[0][0].ToString();
                        if(int.TryParse(str,out iValue))
                        {
                            ObjEArticle.WGID = iValue;
                            string str1 = dsArticles.Tables[0].Rows[0][1] == DBNull.Value ? "" : dsArticles.Tables[0].Rows[0][1].ToString();
                            if (int.TryParse(str1, out iValue1))
                            {
                                ObjEArticle.WIID = iValue1;
                                ObjEArticle.dtWG = dsArticles.Tables[1];
                                ObjEArticle.dtWI = dsArticles.Tables[2];
                            }
                        }
                        else
                        {
                            if (str.Contains("UNIQUE"))
                                throw new Exception("Article Already Exists");
                            else
                                throw new Exception("Error While Saving the Article");
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
            return ObjEArticle;
        }

       public EArticles GetArticle(EArticles ObjEArticle)
       {
           DataSet dsArticles = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_article]";
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsArticles);
                   }
                   ObjEArticle.dtWG = dsArticles.Tables[0];
                   ObjEArticle.dtWI = dsArticles.Tables[1];
                   ObjEArticle.dtDimenstions = dsArticles.Tables[2];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("To Be Updated");
               else
                   throw new Exception("Error While Retrieving the Articles");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles SaveDimension(XmlDocument xml, EArticles ObjEArticle)
       {
           DataSet dsDimensions = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   string innerxml = xml.InnerXml.Replace(',', '.');
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Ins_Dimension]";
                   SqlParameter param = new SqlParameter("@XMlDimension", SqlDbType.Xml);
                   param.Value = innerxml;
                   cmd.Parameters.Add(param);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsDimensions);
                   }
                   if (dsDimensions != null && dsDimensions.Tables.Count > 0)
                   {
                       int iValue = 0;
                       string str = dsDimensions.Tables[0].Rows[0][0] == DBNull.Value ? "" : dsDimensions.Tables[0].Rows[0][0].ToString();
                       if (int.TryParse(str, out iValue))
                       {
                           ObjEArticle.DimensionID = iValue;
                           ObjEArticle.dtDimenstions = dsDimensions.Tables[1];
                       }
                       else
                       {
                           if (str.Contains("UNIQUE"))
                               throw new Exception("Dimension Already Exists");
                           else
                               throw new Exception("Error While Saving the Dimension");
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
           return ObjEArticle;
       }

       public EArticles SaveTyp(XmlDocument xml, EArticles ObjEArticle)
       {
           DataSet dsType = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   string innerxml = xml.InnerXml;
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Ins_Typ]";
                   SqlParameter param = new SqlParameter("@XMLTyp", SqlDbType.Xml);
                   param.Value = innerxml;
                   cmd.Parameters.Add(param);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsType);
                   }
                   if (dsType != null && dsType.Tables.Count > 0)
                   {
                       int iValue = 0;
                       string str = dsType.Tables[0].Rows[0][0] == DBNull.Value ? "" : dsType.Tables[0].Rows[0][0].ToString();
                       if (int.TryParse(str, out iValue))
                       {
                           ObjEArticle.TypID = iValue;
                           ObjEArticle.dtTyp = dsType.Tables[1];
                       }
                       else
                       {
                           if (str.Contains("UNIQUE"))
                               throw new Exception("Typ Already Exists");
                           else
                               throw new Exception("Error While Saving the Typ");
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
           return ObjEArticle;
       }

       public EArticles GetTyp(EArticles ObjEArticle)
       {
           DataSet dsTyp = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_Typ]";
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsTyp);
                   }
                   ObjEArticle.dtWG = dsTyp.Tables[0];
                   ObjEArticle.dtWI = dsTyp.Tables[1];
                   ObjEArticle.dtSupplier = dsTyp.Tables[2];
                   ObjEArticle.dtTyp = dsTyp.Tables[3];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("To Be Updated");
               else
                   throw new Exception("Error While Retrieving the Typ");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles SaveRabatt(XmlDocument xml, EArticles ObjEArticle)
       {
           DataSet dsRabatt = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   string innerxml = xml.InnerXml;
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Ins_Rabatt]";
                   SqlParameter param = new SqlParameter("@XMLRabatt", SqlDbType.Xml);
                   param.Value = innerxml;
                   cmd.Parameters.Add(param);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsRabatt);
                   }
                   if (dsRabatt != null && dsRabatt.Tables.Count > 0)
                   {
                       int iValue = 0;
                       string str = dsRabatt.Tables[0].Rows[0][0] == DBNull.Value ? "" : dsRabatt.Tables[0].Rows[0][0].ToString();
                       if (int.TryParse(str, out iValue))
                       {
                           ObjEArticle.RabattID = iValue;
                           ObjEArticle.dtRabatt = dsRabatt.Tables[1];
                       }
                       else
                       {
                           if (str.Contains("UNIQUE"))
                               throw new Exception("Rabatt Already Exists");
                           else
                               throw new Exception("Error While Saving the Rabatt");
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
           return ObjEArticle;
       }

       public EArticles GetRabatt(EArticles ObjEArticle)
       {
           DataSet dsRabatt = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_Rabatt]";
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsRabatt);
                   }
                   ObjEArticle.dtTyp = dsRabatt.Tables[0];
                   ObjEArticle.dtRabatt = dsRabatt.Tables[1];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("To Be Updated");
               else
                   throw new Exception("Error While Retrieving the Rabatt");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }
   }
}
