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
                               throw new Exception("Dieser Datensatz existiert bereits.");
                           }
                           else
                           {
                               throw new Exception("Data Already Exists");
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
                       else if (str.Contains("UC_RabattTypMap"))
                       {
                           if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                           {
                               throw new Exception("Dieser TYP existiert bereits.");
                           }
                           else
                           {
                               throw new Exception("Typ OR Rabattgruppe Already Exists With Given ValidityDate");
                           }
                       }
                       else if (str.Contains("UC_Rabatt"))
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
               string STR = string.Empty;
               DataSet dsDimesions = new DataSet();
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Imp_ArticleData]";
                   cmd.Parameters.AddWithValue("@dtArticle", ObjEArticle.dtArticleImport);
                   cmd.Parameters.AddWithValue("@dtDimensions", ObjEArticle.dtDimensionImport);
                   object ObjReturn = cmd.ExecuteScalar();
                   STR = Convert.ToString(ObjReturn);
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

       public EArticles SaveArticleMapping(EArticles ObjEArticle)
       {
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Ins_Accessories]";
                   cmd.Parameters.AddWithValue("@ParentWG", ObjEArticle.WG);
                   cmd.Parameters.AddWithValue("@ParentWA", ObjEArticle.WA);
                   cmd.Parameters.AddWithValue("@ParentWI", ObjEArticle.WI);
                   cmd.Parameters.AddWithValue("@ParentA", ObjEArticle.A);
                   cmd.Parameters.AddWithValue("@ParentB", ObjEArticle.B);
                   cmd.Parameters.AddWithValue("@ParentL", ObjEArticle.L);
                   cmd.Parameters.AddWithValue("@ChildWG", ObjEArticle.ChildWG);
                   cmd.Parameters.AddWithValue("@ChildWA", ObjEArticle.ChildWA);
                   cmd.Parameters.AddWithValue("@ChildWI", ObjEArticle.ChildWI);
                   cmd.Parameters.AddWithValue("@ChildA", ObjEArticle.ChildA);
                   cmd.Parameters.AddWithValue("@ChildB", ObjEArticle.ChildB);
                   cmd.Parameters.AddWithValue("@ChildL", ObjEArticle.ChildL);
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
                   throw new Exception("Fehler beim Speichern von Zubehörangaben");
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
                   cmd.Parameters.Add("@ParentWG", ObjEArticle.WG);
                   cmd.Parameters.Add("@ParentWA", ObjEArticle.WA);
                   cmd.Parameters.Add("@ParentWI", ObjEArticle.WI);
                   cmd.Parameters.Add("@ParentA", ObjEArticle.A);
                   cmd.Parameters.Add("@ParentB", ObjEArticle.B);
                   cmd.Parameters.Add("@ParentL", ObjEArticle.L);
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
                   throw new Exception("Fehler bei der Datenaktualisierung für Zubehör");
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
                   throw new Exception("Fehler bei der Datenaktualisierung für Zubehör");
               else
                   throw new Exception("Error While Retrieving the Accessories");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles GetArticleDetailsForAccessories(EArticles ObjEArticle)
       {
           DataSet dsArticleDetails = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_ArticleForDetailKz]";
                   cmd.Parameters.Add("@WG", ObjEArticle.WG);
                   cmd.Parameters.Add("@WA", ObjEArticle.WA);
                   cmd.Parameters.Add("@WI", ObjEArticle.WI);
                   cmd.Parameters.Add("@A", ObjEArticle.A);
                   cmd.Parameters.Add("@B", ObjEArticle.B);
                   cmd.Parameters.Add("@L", ObjEArticle.L);
                   cmd.Parameters.Add("@dtSubmitDate", ObjEArticle.ValidityDate);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsArticleDetails);
                   }
                   if (dsArticleDetails != null && dsArticleDetails.Tables.Count > 0)
                       ObjEArticle.dtArticleDetails = dsArticleDetails.Tables[0];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler beim Laden von Artikeldaten");
               else
                   throw new Exception("Error While Retrieving article details");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles GetTypForArticle(EArticles ObjEArticle)
       {
           DataSet dsTyp = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_TypForMApping]";
                   cmd.Parameters.AddWithValue("@WG", ObjEArticle.ChildWG);
                   cmd.Parameters.AddWithValue("@WA", ObjEArticle.ChildWA);
                   cmd.Parameters.AddWithValue("@WI", ObjEArticle.ChildWI);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsTyp);
                   }
                   if (dsTyp != null && dsTyp.Tables.Count > 0)
                       ObjEArticle.dtTyp = dsTyp.Tables[0];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Typ");
               else
                   throw new Exception("Error While Retrieving Typ");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles GetArticleBytyp(EArticles ObjEArticle)
       {
           DataSet dsAccessories = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_ArticleByType_Mapping]";
                   cmd.Parameters.Add("@TypID", ObjEArticle.TypID);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsAccessories);
                   }
                   if (dsAccessories != null && dsAccessories.Tables.Count > 0)
                       ObjEArticle.dtArticleDetails = dsAccessories.Tables[0];
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Typ");
               else
                   throw new Exception("Error While Retrieving ArticleDetails");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles GetArticleByWG(EArticles ObjEArticle)
       {
           DataSet dsArticleDetails = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_ArticleByWG_Mapping]";
                   cmd.Parameters.Add("@WG", ObjEArticle.WG);
                   cmd.Parameters.Add("@WA", ObjEArticle.WA);
                   cmd.Parameters.Add("@WI", ObjEArticle.WI);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dsArticleDetails);
                   }
                   if (dsArticleDetails != null && dsArticleDetails.Tables.Count > 0)
                   {
                       ObjEArticle.dtArticleDetails = dsArticleDetails.Tables[0];
                       ObjEArticle.dtDimenstions = dsArticleDetails.Tables[1];
                   }
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Typ");
               else
                   throw new Exception("Error While Retrieving ArticleDetails");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public DataTable GetMultipleTyp(int _ID)
       {
           DataTable dtTyp = new DataTable();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_MultipleTyp]";
                   cmd.Parameters.Add("@WIID", _ID);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dtTyp);
                   }                   
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Typ");
               else
                   throw new Exception("Error While Retrieving Typ");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return dtTyp;
       }

       public DataTable GetValidityDates(int _ID)
       {
           DataTable dtDates = new DataTable();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_DimensionValidiyDates]";
                   cmd.Parameters.Add("@WIID", _ID);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dtDates);
                   }
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Datum");
               else
                   throw new Exception("Error While Retrieving ValidityDate");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return dtDates;
       }

       public DataTable GetValidityDatesDimensions(int _ID,DateTime _date)
       {
           DataTable dtDates = new DataTable();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_DimensionsByDate]";
                   cmd.Parameters.Add("@WIID", _ID);
                   cmd.Parameters.Add("@ValidityDate", _date);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dtDates);
                   }
               }
           }
           catch (Exception ex)
           {
               if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                   throw new Exception("Fehler bei der Datenaktualisierung für Datum");
               else
                   throw new Exception("Error While Retrieving ValidityDate");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return dtDates;
       }

       public EArticles GetTypByRabatt(EArticles ObjEArticle)
       {
           try
           {
               ObjEArticle.dtTypID = new DataTable();
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Get_TypByRabatt]";
                   cmd.Parameters.Add("@RabattID", ObjEArticle.RabattID);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(ObjEArticle.dtTypID);
                   }
               }
           }
           catch (Exception ex)
           {
               throw new Exception("Error While Retrieving Types");
           }
           finally
           {
               SQLCon.Sqlconn().Close();
           }
           return ObjEArticle;
       }

       public EArticles CopyRabatt(XmlDocument xml, EArticles ObjEArticle)
       {
           DataSet dsRabatt = new DataSet();
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   string innerxml = xml.InnerXml;
                   cmd.Connection = SQLCon.Sqlconn();
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.CommandText = "[P_Ins_Rabatt_Copy]";
                   SqlParameter param = new SqlParameter("@XMLRabatt", SqlDbType.Xml);
                   param.Value = innerxml;
                   cmd.Parameters.Add(param);
                   cmd.Parameters.Add("@dtTyp", ObjEArticle.dtID);
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
                       else if (str.Contains("UC_RabattTypMap"))
                       {
                           if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                           {
                               throw new Exception("Dieser TYP existiert bereits.");
                           }
                           else
                           {
                               throw new Exception("Typ OR Rabattgruppe Already Exists With Given ValidityDate");
                           }
                       }
                       else if (str.Contains("UC_Rabatt"))
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
   }
}
