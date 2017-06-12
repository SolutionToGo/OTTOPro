using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace BL
{
    public class BGAEB
    {
        DGAEB ObjGAEB = new DGAEB();
        EGAEB objEGAEB = new EGAEB();

        public XmlDocument Export(int ProjectID, string strLVSection,string strFormat)
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                DataSet dsTMLData = null;
                DataSet dsTMLPositionsData = null;
                dsTMLData = ObjGAEB.Export(ProjectID);
                dsTMLPositionsData = ObjGAEB.GetPositionsDataForTML(ProjectID, strLVSection);
                dsTMLData.DataSetName = "Generic";
                dsTMLData.Tables[0].TableName = "DateiInfo";
                dsTMLData.Tables[1].TableName = "AG";
                dsTMLData.Tables[2].TableName = "AN";
                dsTMLData.Tables[3].TableName = "PrjInfo";
                dsTMLData.Tables[4].TableName = "VergabeInfo";
                dsTMLData.Tables[5].TableName = "KalkInfo";
                dsTMLData.Tables[6].TableName = "ReInfo";
                dsTMLData.Tables[7].TableName = "BestInfo";
                dsTMLData.Tables[8].TableName = "LVInfo";
               
                dsTMLPositionsData.DataSetName = "LV";
                if (dsTMLPositionsData != null && dsTMLPositionsData.Tables.Count > 0)
                {
                    dsTMLPositionsData.Tables[0].TableName = "LVPos";
                    if(strFormat.Contains("D"))
                        {
                            foreach(DataRow dr in dsTMLPositionsData.Tables[0].Rows)
                            {
                                string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                                string strPlantext = GetPlaintext(strKurztext);
                                dr["Kurztext"] = strPlantext;
                            }
                        }
                    if(dsTMLPositionsData.Tables.Count > 1)
                    {
                        dsTMLPositionsData.Tables[1].TableName = "LVPos1";
                        if (strFormat.Contains("D"))
                        {
                            foreach (DataRow dr in dsTMLPositionsData.Tables[1].Rows)
                            {
                                string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                                string strPlantext = GetPlaintext(strKurztext);
                                dr["Kurztext"] = strPlantext;
                            }
                        }
                        if (dsTMLPositionsData.Tables.Count > 2)
                        {
                            dsTMLPositionsData.Tables[2].TableName = "LVPos2";
                            if (strFormat.Contains("D"))
                            {
                                foreach (DataRow dr in dsTMLPositionsData.Tables[2].Rows)
                                {
                                    string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                                    string strPlantext = GetPlaintext(strKurztext);
                                    dr["Kurztext"] = strPlantext;
                                }
                            }
                            if (dsTMLPositionsData.Tables.Count > 3)
                            {
                                dsTMLPositionsData.Tables[3].TableName = "LVPos3";
                                if (strFormat.Contains("D"))
                                {
                                    foreach (DataRow dr in dsTMLPositionsData.Tables[3].Rows)
                                    {
                                        string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                                        string strPlantext = GetPlaintext(strKurztext);
                                        dr["Kurztext"] = strPlantext;
                                    }
                                }
                                if (dsTMLPositionsData.Tables.Count > 4)
                                {
                                    dsTMLPositionsData.Tables[4].TableName = "LVPos4";
                                    if (strFormat.Contains("D"))
                                    {
                                        foreach (DataRow dr in dsTMLPositionsData.Tables[4].Rows)
                                        {
                                            string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                                            string strPlantext = GetPlaintext(strKurztext);
                                            dr["Kurztext"] = strPlantext;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                StringBuilder strTMLdata = new StringBuilder();
                strTMLdata.Append(dsTMLData.GetXml());

                if(dsTMLPositionsData != null && dsTMLPositionsData.Tables.Count > 1)
                {
                    DataColumn ParentColumn, ChildColumn; DataRelation dr;
                    for (int i = dsTMLPositionsData.Tables.Count - 1; i > 0; i--)
                    {
                        ParentColumn = dsTMLPositionsData.Tables[i].Columns["PositionID"];
                        ChildColumn = dsTMLPositionsData.Tables[i - 1].Columns["Parent_OZ"];
                        dr = new DataRelation("Relation" + i, ParentColumn, ChildColumn);
                        dr.Nested = true;
                        dsTMLPositionsData.Relations.Add(dr);
                    }
                }

                StringBuilder strTMLPosData = new StringBuilder();
                strTMLPosData.Append(dsTMLPositionsData.GetXml());
                strTMLPosData.Replace("LVPos1", "LVPos");
                strTMLPosData.Replace("LVPos2", "LVPos");
                strTMLPosData.Replace("LVPos3", "LVPos");
                strTMLPosData.Replace("LVPos4", "LVPos");
                strTMLdata.Replace("</Generic>", strTMLPosData.ToString() + "</Generic>");
                xmldoc.LoadXml(strTMLdata.ToString());

                XmlNodeList xn = xmldoc.GetElementsByTagName("*");
                int Count = -1;
                foreach(XmlNode node in xn)
                {
                    string strtype = string.Empty;
                    string strNodeName = node.Name;
                    switch (strNodeName.ToLower())
                    {
                        case "generic" :
                            XmlAttribute idGeneric = xmldoc.CreateAttribute("Id");
                            idGeneric.Value = "0";
                            node.Attributes.Append(idGeneric);
                            break;
                        case "dateiinfo":
                        case "ag":
                        case "an":
                        case "prjinfo":
                        case "vergabeinfo":
                        case "kalkinfo":
                        case "reinfo":
                        case "bestinfo":
                        case "lvinfo":
                        case "lv":
                            strtype = "0";
                            break;
                        case "lvpos":
                            strtype = "512";
                            break;
                        case "version":
                        case "versmon":
                        case "versjahr":
                        case "progsystem":
                        case "progname":
                        case "zeichensatz":
                        case "dp":
                        case "textformat":
                        case "nachlassbasis":
                        case "ia_state":
                        case "ia_format":
                        case "ia_dp":
                        case "ia_kurztext":
                        case "ia_langtext":
                        case "treecheckbox":
                        case "aufmassmenge":
                        case "berechnungsmenge":
                            strtype = "8";
                            break;
                        case "datum":
                        case "uhrzeit":
                            strtype = "7";
                            break;
                        case "zertifikat":
                            strtype = "20";
                            break;
                        default:
                            strtype = "12";
                            break;
                    }
                    if (strNodeName.ToLower() != "generic")
                    {
                        Count++;
                        XmlAttribute id = xmldoc.CreateAttribute("Id");
                        XmlAttribute type = xmldoc.CreateAttribute("type");
                        id.Value = Count.ToString();
                        type.Value = strtype;
                        node.Attributes.Append(id);
                        node.Attributes.Append(type);
                    }
                }
                xmldoc = DeleteNodes(xmldoc, "PositionID");
                xmldoc = DeleteNodes(xmldoc, "Parent_OZ");
            }
            catch (Exception ex)
            {
                throw;
            }
            return xmldoc;
        }

        public int Import(int ProjectID,string strFilePath,string strLVSection)
        {

            int iValue = 0;
            bool _IsRaster_found = false;
            try
            {
                DataSet dsTMLData = CreateDatasetSchema(strFilePath,strLVSection);
                string Raster = GetRaster(strFilePath);
                objEGAEB.dtLVRaster = Get_LVRasters();

                if (objEGAEB.dtLVRaster.Rows != null)
                {
                    foreach (DataRow dr in objEGAEB.dtLVRaster.Rows)
                    {
                        if (Raster == dr["LVRasterName"].ToString())
                        {
                            _IsRaster_found = true;
                        }
                    }
                }                
                if (_IsRaster_found == true)
                {
                    iValue = ObjGAEB.Import(ProjectID, dsTMLData, Raster);
                }
                else
                {
                    string _message = null;
                    if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                    {
                        _message = "Neues Raster wurde in der Importdatei erkennt, wollen Sie es lokal speichern?";
                    }
                    else
                    {
                        _message = "New Raster Detected, do you want save the Raster..?";
                    }
                    DialogResult dialogResult = MessageBox.Show(_message, "Bestätigung", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        iValue = ObjGAEB.Import(ProjectID, dsTMLData, Raster);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return iValue;
        }

        private DataSet CreateDatasetSchema(string strFilePath, string strLVSection)
        {
            DataSet dsXmlData = new DataSet("Generic");
            try
            {
                DataTable dtV = new DataTable("LVPos");
                dtV.Columns.Add("Art", typeof(string));
                dtV.Columns.Add("OZ", typeof(string));
                dtV.Columns.Add("Menge", typeof(int));
                dtV.Columns.Add("Einheit", typeof(string));
                dtV.Columns.Add("Kurztext", typeof(string));
                dtV.Columns.Add("Langtext", typeof(string));
                dtV.Columns.Add("EP", typeof(decimal));
                dtV.Columns.Add("GB", typeof(decimal));
                dtV.Columns.Add("Nachlass", typeof(string));
                dtV.Columns.Add("ParentOz", typeof(string));
                dtV.Columns.Add("Title", typeof(string));
                dtV.Columns.Add("SNO", typeof(int));
                dsXmlData.Tables.Add(dtV);

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strFilePath);
                XmlNodeList xnLVPos = xDoc.GetElementsByTagName("LVPos");
                string strART = string.Empty;
                int iSNO = 0;
                foreach(XmlNode xnPos in xnLVPos)
                {
                    iSNO++;
                    DataRow drLVPos = dtV.NewRow();
                    XmlNode xnArt = xnPos.SelectSingleNode("Art");
                    if (xnArt != null)
                    {
                        drLVPos["Art"] = strART = xnArt.InnerText;
                    }
                   XmlNode xnOZ = xnPos.SelectSingleNode("OZ");
                   if (xnOZ != null)
                   {
                       if (!xnOZ.InnerText.Contains("Z"))
                       {
                           drLVPos["OZ"] = xnOZ.InnerText;
                       }
                       else
                       {
                           continue;
                       }
                   }
                    XmlNode xnMenge = xnPos.SelectSingleNode("Menge");
                    if (xnMenge != null)
                    {
                        decimal dValue = 0;
                        if (decimal.TryParse(xnMenge.InnerText, out dValue))
                            drLVPos["Menge"] = dValue;

                    }
                    XmlNode xnEinheit = xnPos.SelectSingleNode("Einheit");
                    if (xnEinheit != null)
                        drLVPos["Einheit"] = xnEinheit.InnerText;

                    XmlNode xnKurztext = xnPos.SelectSingleNode("Kurztext");
                    if (xnKurztext != null)
                    {
                        if (IsRtfText(xnKurztext.InnerText))
                        {
                            drLVPos["Kurztext"] = xnKurztext.InnerText;
                            if (strART.ToLower() == "ng")
                                drLVPos["Title"] = GetPlaintext(xnKurztext.InnerText);
                        }
                        else
                        {
                            drLVPos["Kurztext"] = GetRTFFormat(xnKurztext.InnerText);
                            if (strART.ToLower() == "ng")
                                drLVPos["Title"] = xnKurztext.InnerText;
                        }
                    }
                    XmlNode xnLangtext = xnPos.SelectSingleNode("Langtext");
                    if (xnLangtext != null)
                    {
                        if (IsRtfText(xnLangtext.InnerText))
                            drLVPos["Langtext"] = xnLangtext.InnerText;
                        else
                            drLVPos["Langtext"] = GetRTFFormat(xnLangtext.InnerText);
                    }
                    XmlNode xnEP = xnPos.SelectSingleNode("EP");
                    if (xnEP != null)
                    {
                        decimal dValue = 0;
                        if (decimal.TryParse(xnEP.InnerText, out dValue))
                            drLVPos["EP"] = dValue;
                        else
                            drLVPos["EP"] = 0;
                    }
                    XmlNode xnGB = xnPos.SelectSingleNode("GB");
                    if (xnGB != null)
                    {
                        decimal dValueDB = 0;
                        if (decimal.TryParse(xnGB.InnerText, out dValueDB))
                            drLVPos["GB"] = dValueDB;
                        else
                            drLVPos["GB"] = 0;
                    }
                    XmlNode xnNachlass = xnPos.SelectSingleNode("Nachlass");
                    if (strLVSection != string.Empty)
                        drLVPos["Nachlass"] = strLVSection;
                    else if (xnNachlass != null)
                    {
                        string str = xnNachlass.InnerText;
                        if (string.IsNullOrEmpty(str))
                            drLVPos["Nachlass"] = "HA";
                        else
                            drLVPos["Nachlass"] = str;
                    }

                    drLVPos["SNO"] = iSNO.ToString(); ;
                    dtV.Rows.Add(drLVPos);
                }

                foreach (DataRow dr in dsXmlData.Tables[0].Rows)
                {
                    string strPositionOZ = dr["OZ"].ToString();
                    if (strPositionOZ != string.Empty)
                    {
                        dr["ParentOz"] = GetParentOZ(strPositionOZ);
                    }
                    else
                    {
                        string strSNO = dr["SNO"].ToString();
                        string MaxValue = dsXmlData.Tables[0].Compute("MIN(SNO)", "SNO >'" + strSNO + "'AND Art <> 'H'").ToString();
                        DataRow[] drNextPosition = dsXmlData.Tables[0].Select("SNO='" + MaxValue + "'");
                        dr["ParentOz"] = GetParentOZ(drNextPosition[0]["OZ"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Beim Import der GAEB-Datei ist ein Fehler aufgetreten!");
                }
                else
                {
                    throw new Exception("Error While Importing GAEB File");
                }
            }
            return dsXmlData;
        }

        private string GetParentOZ(string strPositionOZ)
        {
            string[] strOZ = strPositionOZ.Split('.');
            StringBuilder strParentOZ = new StringBuilder();
            try
            {
                if (strOZ != null && strOZ.Count() > 2)
                {
                    if (strOZ.Count() > 2)
                    {
                        strParentOZ.Append(strOZ[0] + ".");
                        if (strOZ.Count() > 3)
                        {
                            if (!string.IsNullOrEmpty(strOZ[1].Trim()))
                                strParentOZ.Append(strOZ[1] + ".");
                            if (strOZ.Count() > 4)
                            {
                                if (!string.IsNullOrEmpty(strOZ[2].Trim()))
                                strParentOZ.Append(strOZ[2] + ".");
                                if (strOZ.Count() > 5 && !string.IsNullOrEmpty(strOZ[3].Trim()))
                                {
                                    strParentOZ.Append(strOZ[3] + ".");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strParentOZ.ToString();
        }

        private string GetRaster(string strFilePath)
        {
            StringBuilder strRaster = new StringBuilder();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strFilePath);
                XmlNodeList xnLVInfo = xDoc.SelectNodes("/Generic/LVInfo");
                string strNew = string.Empty;
                foreach (XmlNode xn in xnLVInfo)
                {
                    XmlNode xnTyp1 = xn.SelectSingleNode("LVGliedTyp1");
                    if (xnTyp1 != null)
                    {
                        XmlNode xnLng1 = xn.SelectSingleNode("LVGliedLen1");
                        strNew = new string('9', Convert.ToInt32(xnLng1.InnerText));
                        strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp2 = xn.SelectSingleNode("LVGliedTyp2");
                    if (xnTyp2 != null && xnTyp2.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng2 = xn.SelectSingleNode("LVGliedLen2");
                        if (xnTyp2.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng2.InnerText));
                        else if (xnTyp2.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng2.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp3 = xn.SelectSingleNode("LVGliedTyp3");
                    if (xnTyp3 != null && xnTyp3.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng3 = xn.SelectSingleNode("LVGliedLen3");
                        if (xnTyp3.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng3.InnerText));
                        else if (xnTyp3.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng3.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp4 = xn.SelectSingleNode("LVGliedTyp4");
                    if (xnTyp4 != null && xnTyp4.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng4 = xn.SelectSingleNode("LVGliedLen4");
                        if (xnTyp4.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng4.InnerText));
                        else if (xnTyp4.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng4.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }

                    XmlNode xnTyp5 = xn.SelectSingleNode("LVGliedTyp5");
                    if (xnTyp5 != null && xnTyp5.InnerText.ToLower() != "")
                    {
                        strNew = string.Empty;
                        XmlNode xnLng5 = xn.SelectSingleNode("LVGliedLen5");
                        if (xnTyp5.InnerText.ToLower() == "lvstufe")
                            strNew = new string('9', Convert.ToInt32(xnLng5.InnerText));
                        else if (xnTyp5.InnerText.ToLower() == "position")
                            strNew = new string('1', Convert.ToInt32(xnLng5.InnerText));
                        if (strNew != string.Empty)
                            strRaster.Append(strNew + ".");
                    }
                    strRaster.Append("9");
                }
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Beim Import der GAEB-Datei ist ein Fehler aufgetreten!");
                }
                else
                {
                    throw new Exception("Error While Importing GAEB File");
                }
            }
            return strRaster.ToString();
        }

        public DataTable Get_LVRasters()
        {
            DataTable dt_raster = new DataTable();

            try
            {
                dt_raster = ObjGAEB.Get_LVRaster();
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt_raster;

        }

        private XmlDocument DeleteNodes(XmlDocument Xdoc,string strName)
        {
            try
            {
                XmlNodeList xn = Xdoc.GetElementsByTagName(strName);
                for (int i = xn.Count - 1; i >= 0; i--)
                {
                    xn[i].ParentNode.RemoveChild(xn[i]);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Xdoc;
        }

        public DataTable GetLVSection(int ProjectID)
        {
            DataTable dtLVSection = null;
            try
            {
                dtLVSection = ObjGAEB.GetLVSection(ProjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtLVSection;
        }

        public bool IsRtfText(string text)
        {
            bool _ISRTF = false;
            try
            {
                if (text.TrimStart().StartsWith("{\\rtf1", StringComparison.Ordinal))
                {
                    if (IsValidRtf(text))
                        _ISRTF = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return _ISRTF;
        }

        private bool IsValidRtf(string text)
        {
            try
            {
                new RichTextBox().Rtf = text;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private string GetRTFFormat(string Plaintext)
        {
            try
            {
                System.Windows.Forms.RichTextBox rtf = new System.Windows.Forms.RichTextBox();
                rtf.Text = Plaintext;
                return rtf.Rtf;
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Datenimport langtext");
                }
                else
                {
                    throw new Exception("Error while importing langtext");
                }
            }
        }

        private string GetPlaintext(string RTFText)
        {
            try
            {
                System.Windows.Forms.RichTextBox rtf = new System.Windows.Forms.RichTextBox();
                rtf.Rtf = RTFText;
                return rtf.Text;
            }
            catch (Exception ex)
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString() == "de-DE")
                {
                    throw new Exception("Fehler beim Datenimport langtext");
                }
                else
                {
                    throw new Exception("Error while importing langtext");
                }
            }
        }

    }
}
