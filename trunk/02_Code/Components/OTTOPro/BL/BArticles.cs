using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EL;
using System.Data;
using System.Xml;
using System.Globalization;
using System.Data.OleDb;

namespace BL
{
    public class BArticles
    {
        DArticles ObjDArticles = null;
        CultureInfo CInfo = new CultureInfo("en-US");
        public EArticles SaveArticle(EArticles ObjEArticle)
        {
            try
            {
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Article";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WGID", ObjEArticle.WGID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WG", ObjEArticle.WG);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WA", ObjEArticle.WA);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WGDescription", ObjEArticle.WGDescription);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WADescription", ObjEArticle.WADescription);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WIID", ObjEArticle.WIID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WI", ObjEArticle.WI);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WIDescription", ObjEArticle.WIDescription);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Fabrikate", ObjEArticle.Fabrikate);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Typ", ObjEArticle.Typ);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Masseinheit", ObjEArticle.Masseinheit);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Dimension", ObjEArticle.Dimension);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Menegenheit", ObjEArticle.Menegenheit);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Remarks", ObjEArticle.Remarks);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TextKZ", ObjEArticle.TextKZ);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEArticle.ValidityDate.ToString("yyyy-MM-dd"));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1", ObjEArticle.Multi1.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2", ObjEArticle.Multi2.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3", ObjEArticle.Multi3.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4", ObjEArticle.Multi4.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DataNormNumber", ObjEArticle.DataNormNumber.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CreatedBy", ObjEArticle.CreatedBy.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LastUpdatedBy", ObjEArticle.LastUpdatedBy.ToString());
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.SaveArticle(Xdoc, ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetArticle(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.GetArticle(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles SaveDimension(EArticles ObjEArticle)
        {
            try
            {
             
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Dimension";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "DimensionID", ObjEArticle.DimensionID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WIID", ObjEArticle.WIID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "A", ObjEArticle.A);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "B", ObjEArticle.B);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "L", ObjEArticle.L);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ListPrice", ObjEArticle.ListPrice.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "GMulti", ObjEArticle.GMulti.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Minuten", ObjEArticle.Minuten.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEArticle.ValidityDate.ToString("yyyy-MM-dd"));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CreatedBy", ObjEArticle.CreatedBy.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LastUpdatedBy", ObjEArticle.LastUpdatedBy.ToString());
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.SaveDimension(Xdoc, ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles SaveTyp(EArticles ObjEArticle)
        {
            try
            {
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Typ";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TypID", ObjEArticle.TypID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "SupplierID", ObjEArticle.SupplierID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "WIID", ObjEArticle.WIID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Typ", ObjEArticle.Typ);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CreatedBy", ObjEArticle.CreatedBy.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LastUpdatedBy", ObjEArticle.LastUpdatedBy.ToString());
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.SaveTyp(Xdoc, ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetTyp(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.GetTyp(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles SaveRabatt(EArticles ObjEArticle)
        {
            try
            {
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Rabatt";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "RabattID", ObjEArticle.RabattID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Rabatt", ObjEArticle.Rabatt.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TypeID", ObjEArticle.TypID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1", ObjEArticle.Multi1.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2", ObjEArticle.Multi2.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3", ObjEArticle.Multi3.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4", ObjEArticle.Multi4.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEArticle.ValidityDate.ToString("yyyy-MM-dd"));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CreatedBy", ObjEArticle.CreatedBy.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LastUpdatedBy", ObjEArticle.LastUpdatedBy.ToString());
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.SaveRabatt(Xdoc, ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetRabatt(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.GetRabatt(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles SaveDimensionCopy(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.SaveDimensionCopy(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles ImportExcelXLS(string FilePath, EArticles ObjEArticle)
        {
            try
            {
                bool hasHeaders = true;
                string HDR = hasHeaders ? "Yes" : "No";
                string strConn;
                if (FilePath.Substring(FilePath.LastIndexOf('.')).ToLower() == ".xlsx")
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                else
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

                DataSet output = new DataSet();
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();

                    DataTable schemaTable = conn.GetOleDbSchemaTable(
                        OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    foreach (DataRow schemaRow in schemaTable.Rows)
                    {
                        string sheet = schemaRow["TABLE_NAME"].ToString();

                        if (!sheet.EndsWith("_"))
                        {
                            try
                            {
                                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                                cmd.CommandType = CommandType.Text;

                                DataTable outputTable = new DataTable(sheet);
                                output.Tables.Add(outputTable);
                                new OleDbDataAdapter(cmd).Fill(outputTable);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FilePath), ex);
                            }
                        }
                    }
                }
                if (output != null && output.Tables.Count > 0)
                {
                    ObjEArticle.dtArticleImport = output.Tables[0];
                    if(output.Tables.Count > 1)
                        ObjEArticle.dtDimensionImport = output.Tables[1];
                }
                CultureInfo ObjCulture = new CultureInfo("en-gb");
                if (ObjEArticle.dtArticleImport != null)
                {
                    DataTable dtTempArticle = ObjEArticle.dtArticleImport.Clone();
                    dtTempArticle.Locale = ObjCulture;
                    dtTempArticle.Columns["Key"].DataType = System.Type.GetType("System.Int32");
                    dtTempArticle.Columns["Warengrouppe"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["WGDesc"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["Warenart"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["WADesc"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["Warennummer"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["WIDesc"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["Fabrikat"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["TYP"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["Lieferant"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["Dimension"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["Masseinheit"].DataType = System.Type.GetType("System.String");
                    dtTempArticle.Columns["Rabattgruppe"].DataType = System.Type.GetType("System.String");
                    foreach (DataRow dr in ObjEArticle.dtArticleImport.Rows)
                        dtTempArticle.ImportRow(dr);
                    ObjEArticle.dtArticleImport = new DataTable();
                    ObjEArticle.dtArticleImport.Locale = ObjCulture;
                    ObjEArticle.dtArticleImport = dtTempArticle.Copy();
                }
                if(ObjEArticle.dtDimensionImport != null)
                {
                    DataTable dtTempDimensions = ObjEArticle.dtDimensionImport.Clone();
                    dtTempDimensions.Locale = ObjCulture;
                    dtTempDimensions.Columns["Key"].DataType = System.Type.GetType("System.Int32");
                    dtTempDimensions.Columns["A"].DataType = System.Type.GetType("System.String");
                    dtTempDimensions.Columns["B"].DataType = System.Type.GetType("System.String");
                    dtTempDimensions.Columns["L"].DataType = System.Type.GetType("System.String");
                    dtTempDimensions.Columns["ValidityDate"].DataType = System.Type.GetType("System.DateTime");
                    dtTempDimensions.Columns["L-Preis"].DataType = System.Type.GetType("System.Decimal");
                    dtTempDimensions.Columns["Multi1"].DataType = System.Type.GetType("System.Decimal");
                    dtTempDimensions.Columns["Multi2"].DataType = System.Type.GetType("System.Decimal");
                    dtTempDimensions.Columns["Multi3"].DataType = System.Type.GetType("System.Decimal");
                    dtTempDimensions.Columns["Multi4"].DataType = System.Type.GetType("System.Decimal");
                    dtTempDimensions.Columns["Montage Zeit"].DataType = System.Type.GetType("System.Decimal");
                    foreach (DataRow dr in ObjEArticle.dtDimensionImport.Rows)
                        dtTempDimensions.ImportRow(dr);
                    ObjEArticle.dtDimensionImport = new DataTable();
                    ObjEArticle.dtDimensionImport.Locale = ObjCulture;
                    ObjEArticle.dtDimensionImport = dtTempDimensions.Copy();
                }
            }
            catch (Exception ex)    
            {
                throw new Exception("Error While Importing");
            }
            return ObjEArticle;
        }

        public EArticles ImportArticleData(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.ImportArticleData(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles SaveArticleMapping(EArticles ObjEArticle)
        {
            try
            {
                if(ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.SaveArticleMapping(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetAccessories(EArticles ObjEArticle)
        {
            try
            {
                ObjEArticle = ObjDArticles.GetAccessories(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetAccessoriesForLVs(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.GetAccessoriesForLVs(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetArticleDetailsForAccessories(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.GetArticleDetailsForAccessories(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetArticleBytyp(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles(); 
                ObjEArticle = ObjDArticles.GetArticleBytyp(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles GetArticleByWG(EArticles ObjEArticle)
        {
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.GetArticleByWG(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public DataTable GetMultipleTyp(int _ID)
        {
            DataTable dt = new DataTable();
            try
            {                
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                 dt= ObjDArticles.GetMultipleTyp(_ID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public DataTable GetValidityDates(int _ID)
        {
            DataTable _dt = new DataTable();
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                _dt = ObjDArticles.GetValidityDates(_ID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _dt;
        }

        public DataTable GetValidityDatesDimensions(int _ID,DateTime _date)
        {
            DataTable _dt = new DataTable();
            try
            {
                if (ObjDArticles == null)
                    ObjDArticles = new DArticles();
                _dt = ObjDArticles.GetValidityDatesDimensions(_ID, _date);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _dt;
        }

        public EArticles GetTypByRabatt(EArticles ObjEArticle)
        {
            try
            {
                ObjEArticle = ObjDArticles.GetTypByRabatt(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }

        public EArticles CopyRabatt(EArticles ObjEArticle)
        {
            try
            {
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/Rabatt";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "RabattID", ObjEArticle.RabattID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Rabatt", ObjEArticle.Rabatt.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "TypeID", ObjEArticle.TypID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1", ObjEArticle.Multi1.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2", ObjEArticle.Multi2.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3", ObjEArticle.Multi3.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4", ObjEArticle.Multi4.ToString(CInfo));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEArticle.ValidityDate.ToString("yyyy-MM-dd"));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "CreatedBy", ObjEArticle.CreatedBy.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LastUpdatedBy", ObjEArticle.LastUpdatedBy.ToString());
                if(ObjEArticle.dtTypID != null)
                {
                    ObjEArticle.dtID = ObjEArticle.dtTypID.Copy();
                    ObjEArticle.dtID.Columns.Remove("Typ");
                }
                else
                {
                    ObjEArticle.dtID = new DataTable();
                    ObjEArticle.dtID.Columns.Add("TypID", typeof(int));
                }
                if(ObjDArticles == null)
                    ObjDArticles = new DArticles();
                ObjEArticle = ObjDArticles.CopyRabatt(Xdoc, ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }
    }
}
