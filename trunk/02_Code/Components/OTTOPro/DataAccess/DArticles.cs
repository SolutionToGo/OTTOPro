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
                        string innerxml = xml.InnerXml;
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
                            else if (str.Contains("UNIQUE"))
                            {
                                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                                {
                                    throw new Exception("Der Artikel existiert bereits.");
                                }
                                else
                                {
                                    throw new Exception("Article Already Exists");
                                }
                            }
                             else
                                throw new Exception("Fehler beim Speichern des Artikels");
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
                   throw new Exception("Fehler bei der Datenaktualisierung für Artikel");
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
                   string innerxml = xml.InnerXml;
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
                       else if(str.Contains("UNIQUE"))
                       {
                           if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                           {
                               throw new Exception("Diese Maße gibt es bereits");
                           }
                           else
                           {
                               throw new Exception("Dimension Already Exists");
                           }
                       }
                       
                           else
                           throw new Exception("Fehler beim Speichern der Maße");
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
                       else if (str.Contains("UNIQUE"))
                       {
                           if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                           {
                               throw new Exception("Dieser TYP existiert bereits");
                           }
                           else
                           {
                               throw new Exception("Typ Already Exists");
                           }
                       }                       
                           else
                           throw new Exception("Fehler beim Speichern von TYP");
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
                   throw new Exception("Fehler bei der Datenaktualisierung für Typ");
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
                       else if(str.Contains("UNIQUE"))
                       {
                           if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                           {
                               throw new Exception("Diese Rabattgruppe existiert bereits");
                           }
                           else
                           {
                               throw new Exception("Rabatt Already Exists");
                           }
                       }                       
                           else
                           throw new Exception("Fehler beim Speichern der Rabattgruppe");
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
                   throw new Exception("Fehler bei der Datenaktualisierung für Rabattgruppen");
               else
                   throw new Exception("Error While Retrieving the Rabatt");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles SaveDimensionCopy(EArticles ObjEArticle)
       {
           DataSet dsDimesions = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Ins_DimensionCopy]";
                   cmd.Parameters.AddWithValue("@WIID", ObjEArticle.WIID);
                   cmd.Parameters.AddWithValue("@ValidityDate", ObjEArticle.ValidityDate);
                   cmd.Parameters.AddWithValue("@dtDimension", ObjEArticle.dtDimenstions);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsDimesions);
                   }
                   ObjEArticle.dtDimenstions = dsDimesions.Tables[0];
               }
           }
           catch (Exception ex)
           {
               if (ex.Message.Contains("UNIQUE"))
               {
                   if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   {
                       throw new Exception("Das angegebene Gültigkeitsdatum besteht bereits");
                   }
                   else
                   {
                       throw new Exception("Selected Validity Date Already Exists with Dimensions");
                   }
               }                   
               else
                   throw new Exception("Error While Saving the Dimension");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles ImportArticleData(EArticles ObjEArticle)
       {
           try
           {
               DataSet dsDimesions = new DataSet();
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Imp_ArticleData]";
                   cmd.Parameters.AddWithValue("@dtArticle", ObjEArticle.dtArticleImport);
                   cmd.Parameters.AddWithValue("@dtDimensions", ObjEArticle.dtDimensionImport);
                   cmd.ExecuteNonQuery();
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
               {
                   throw new Exception("Fehler beim Datenimport");
               }
               else
               {
                   throw new Exception("Error While Importing");
               }               
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles GetAticleForMapping(EArticles ObjEArticle)
       {
           DataSet dsTyp = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_ArticleForMapping]";
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsTyp);
                   }
                   ObjEArticle.dtWG = dsTyp.Tables[0];
                   ObjEArticle.dtWI = dsTyp.Tables[1];
                   ObjEArticle.dtDimenstions = dsTyp.Tables[2];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Typ");
               else
                   throw new Exception("Error While Retrieving the Typ");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles SaveArticleMapping(EArticles ObjEArticle)
       {
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Ins_Accessories]";
                   cmd.Parameters.AddWithValue("@ParentID", ObjEArticle.ParentID);
                   cmd.Parameters.AddWithValue("@ChildID", ObjEArticle.ChildID);
                   cmd.Parameters.AddWithValue("@UserID", ObjEArticle.UserID);
                   object ObjReturn = cmd.ExecuteScalar();
                   if (ObjReturn != null)
                       ObjEArticle.AccessoriesID = Convert.ToInt32(ObjReturn);
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
               {
                   throw new Exception("Error while saving the accessories");
               }
               else
               {
                   throw new Exception("Error while saving the accessories");
               }
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles GetAccessories(EArticles ObjEArticle)
       {
           DataSet dsAccessories = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_AccessorieS]";
                   cmd.Parameters.Add("@ParentID", ObjEArticle.ParentID);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsAccessories);
                   }
                   if (dsAccessories != null && dsAccessories.Tables.Count > 0)
                       ObjEArticle.dtAccessories = dsAccessories.Tables[0];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Accessories");
               else
                   throw new Exception("Error While Retrieving the Accessories");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles GetAccessoriesForLVs(EArticles ObjEArticle)
       {
           DataSet dsAccessories = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_AccessoriesForLVs]";
                   cmd.Parameters.Add("@WG", ObjEArticle.WG);
                   cmd.Parameters.Add("@WA", ObjEArticle.WA);
                   cmd.Parameters.Add("@WI", ObjEArticle.WI);
                   cmd.Parameters.Add("@A", ObjEArticle.A);
                   cmd.Parameters.Add("@B", ObjEArticle.B);
                   cmd.Parameters.Add("@L", ObjEArticle.L);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsAccessories);
                   }
                   if (dsAccessories != null && dsAccessories.Tables.Count > 0)
                       ObjEArticle.dtAccessories = dsAccessories.Tables[0];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Accessories");
               else
                   throw new Exception("Error While Retrieving the Accessories");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }
   }
}
