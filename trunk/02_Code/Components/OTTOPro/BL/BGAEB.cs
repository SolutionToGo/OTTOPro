using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace BL
{
    public class BGAEB
    {   
        DGAEB ObjGAEB = new DGAEB();
        public XmlDocument Export(int ProjectID, string strLVSection, string strFormat, string _Raster, EGAEB ObjEGAEB)
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                DataSet dsTMLData = null;
                DataSet dsTMLPositionsData = null;
                dsTMLData = ObjGAEB.Export(ProjectID, _Raster);
                dsTMLPositionsData = ObjGAEB.GetPositionsDataForTML(ProjectID, strLVSection, _Raster);
                
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
                dsTMLPositionsData.Locale = CultureInfo.CreateSpecificCulture("de-DE");
                if (dsTMLPositionsData != null && dsTMLPositionsData.Tables.Count > 1)
                {
                    dsTMLPositionsData.Tables[1].TableName = "LVPos";
                    if (strFormat.Contains("D"))
                    {
                        foreach (DataRow dr in dsTMLPositionsData.Tables[1].Rows)
                        {
                            string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                            string strPlantext = GetPlaintext(strKurztext);
                            dr["Kurztext"] = strPlantext;
                        }
                    }
                    if(dsTMLPositionsData.Tables.Count > 2)
                    {
                        dsTMLPositionsData.Tables[2].TableName = "LVPos1";
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
                            dsTMLPositionsData.Tables[3].TableName = "LVPos2";
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
                                dsTMLPositionsData.Tables[4].TableName = "LVPos3";
                                if (strFormat.Contains("D"))
                                {
                                    foreach (DataRow dr in dsTMLPositionsData.Tables[4].Rows)
                                    {
                                        string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                                        string strPlantext = GetPlaintext(strKurztext);
                                        dr["Kurztext"] = strPlantext;
                                    }
                                }
                                if (dsTMLPositionsData.Tables.Count > 5)
                                {
                                    dsTMLPositionsData.Tables[5].TableName = "LVPos4";
                                    if (strFormat.Contains("D"))
                                    {
                                        foreach (DataRow dr in dsTMLPositionsData.Tables[5].Rows)
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

                dsTMLPositionsData.Tables[0].TableName = "ZuschlTMenge";

                StringBuilder strTMLdata = new StringBuilder();
                strTMLdata.Append(dsTMLData.GetXml());
                bool _IsBind = false;
                if (dsTMLPositionsData.Tables.Count > 0 && strFormat.Contains("X"))
                {
                    DataTable dt = new DataTable("ExtDat");
                    dt.Columns.Add("PositionID", typeof(int));
                    dt.Columns.Add("Parent_OZ", typeof(int));
                    dt.Columns.Add("ExtDatName", typeof(string));
                    dt.Columns.Add("ExtDatBeschr", typeof(string));
                    foreach (DataRow dr in dsTMLPositionsData.Tables[1].Rows)
                    {
                        int IValue = 0;
                        if (int.TryParse(Convert.ToString(dr["PositionID"]), out IValue))
                        {
                            dt = ExtractImages(dt, Convert.ToString(dr["Langtext"]), IValue, ObjEGAEB);
                        }
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _IsBind = true;
                        DataSet dsTemp = new DataSet();
                        dsTemp.Tables.Add(dt);
                        for (int i = 0; i < dsTMLPositionsData.Tables.Count; i++)
                        {
                            DataTable dtTemp = dsTMLPositionsData.Tables[i].Copy();
                            dsTemp.Tables.Add(dtTemp);
                        }
                        dsTMLPositionsData = new DataSet();
                        dsTMLPositionsData = dsTemp.Copy();
                        dsTMLPositionsData.DataSetName = "LV";
                    }
                }


                if(dsTMLPositionsData != null && dsTMLPositionsData.Tables.Count > 1)
                {
                    int iValue = 0;
                    if (_IsBind)
                        iValue = 1;

                    DataColumn ParentColumn, ChildColumn; DataRelation dr;
                    for (int i = dsTMLPositionsData.Tables.Count - 1; i > iValue; i--)
                    {
                        ParentColumn = dsTMLPositionsData.Tables[i].Columns["PositionID"];
                        ChildColumn = dsTMLPositionsData.Tables[i - 1].Columns["Parent_OZ"];
                        dr = new DataRelation("Relation" + i, ParentColumn, ChildColumn);
                        dr.Nested = true;
                        dsTMLPositionsData.Relations.Add(dr);
                    }
                }

                if(_IsBind)
                {
                    DataColumn ParentColumn, ChildColumn; DataRelation dr;
                    ParentColumn = dsTMLPositionsData.Tables[2].Columns["PositionID"];
                    ChildColumn = dsTMLPositionsData.Tables[0].Columns["Parent_OZ"];
                    dr = new DataRelation("RelationDisc", ParentColumn, ChildColumn);
                    dr.Nested = true;
                    dsTMLPositionsData.Relations.Add(dr);
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
                        case "extdat":
                        case "zuschltmenge":
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
                        case "menge":
                            strtype = "12";
                            if (Thread.CurrentThread.CurrentCulture.Name == "de-DE")
                           {
                               string strValue = node.InnerText.Replace(".", ",");
                               node.InnerText = strValue;
                           }
                            break;
                        case "ep":
                        case "gb":
                            if (strFormat.Contains("81"))
                                node.InnerText = "0";
                            strtype = "12";
                            if (Thread.CurrentThread.CurrentCulture.Name == "de-DE")
                           {
                               string strValue = node.InnerText.Replace(".", ",");
                               node.InnerText = strValue;
                           }
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

        public int Import(int ProjectID, DataSet dsTMLData, string Raster)
        {

            int iValue = 0;
            try
            {
                iValue = ObjGAEB.Import(ProjectID, dsTMLData, Raster);
            }
            catch (Exception ex)
            {
                throw;
            }
            return iValue;
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

        public string GetOld_Raster(int _ProjectID)
        {
            string Old_raster = string.Empty;

            try
            {
                Old_raster = ObjGAEB.GetOld_LVRaster(_ProjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Old_raster;
        }

        public string PrepareOZ(string strOZ, string strRaster)
        {
            string str = string.Empty;
            try
            {
                string[] strPOZ = strOZ.Split('.');
                string[] strPRaster = strRaster.Split('.');
                int Count = -1;
                int i = -1;
                Count = strPOZ.Count();
                while (Count > 0)
                {
                    i = i + 1;
                    Count = Count - 1;
                    string OZ = string.Empty;
                    int OZLength = 0;
                    int RasterLength = 0;

                    OZ = strPOZ[i].Trim();
                    RasterLength = strPRaster[i].Length;
                    OZLength = OZ.Length;
                    if (Count == 0)
                    {
                        if (RasterLength == 1 && OZLength > 0)
                        {
                            str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ;
                        }
                        else if (OZLength > 0)
                        {
                            str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ + ".";
                        }
                    }
                    else
                    {
                        str = str + string.Concat(Enumerable.Repeat("0", RasterLength - OZLength)) + OZ + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return str;
        }

        public EGAEB ProjectImport(EGAEB objEGAEB)
        {
            try
            {
                DataRow[] TopRows = objEGAEB.dsLVData.Tables[0].Select("Art NOT IN ('NG','H')");
                if (TopRows != null && TopRows.Count() > 0)
                {
                    string strFirstOZ = string.Empty;
                    string strSecondOZ = string.Empty;
                    if (TopRows.Count() > 0)
                    {
                        strFirstOZ = TopRows[0]["OZ"] == DBNull.Value ? "" : Convert.ToString(TopRows[0]["OZ"]);
                        if (TopRows.Count() > 1)
                            strSecondOZ = TopRows[1]["OZ"] == DBNull.Value ? "" : Convert.ToString(TopRows[1]["OZ"]);
                    }
                    string[] FirstOZ = strFirstOZ.Split('.');
                    string[] SecondOZ = strSecondOZ.Split('.');
                    int IValue = 0;
                    int FirstValue = 0;
                    int SecondValue = 0;
                    if (FirstOZ != null)
                    {
                        if (FirstOZ.Count() > 2 && int.TryParse(FirstOZ[FirstOZ.Count() - 2], out IValue))
                        {
                            FirstValue = IValue;
                            if (SecondOZ != null)
                            {
                                if (SecondOZ.Count() > 2 && int.TryParse(SecondOZ[SecondOZ.Count() - 2], out IValue))
                                {
                                    SecondValue = IValue;
                                    if (SecondValue > FirstValue && SecondValue > 0 && FirstValue > 0)
                                    {
                                        objEGAEB.LVSprunge = SecondValue - FirstValue;
                                    }
                                    else
                                        objEGAEB.LVSprunge = 10;
                                }
                                else
                                    objEGAEB.LVSprunge = 10;
                            }
                            else
                                objEGAEB.LVSprunge = 10;
                        }
                        else
                            objEGAEB.LVSprunge = 10;
                    }
                    else
                        objEGAEB.LVSprunge = 10;
                }
                else
                    objEGAEB.LVSprunge = 10;
                ObjGAEB.ProjectImport(objEGAEB);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEGAEB;
        }
        
        public EGAEB SaveeProject(EGAEB objEGAEB)
        {
            try
            {
                ObjGAEB.ProjectImport(objEGAEB);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEGAEB;
        }

        private DataTable ExtractImages(DataTable dt, string strRtf, int PositionID, EGAEB ObjEGAEB)
        {
            try
            {
                int IVlaue = 0;
                int pictTagIdx = strRtf.IndexOf("{\\pict\\");
                while (pictTagIdx > 0)
                {
                    IVlaue++;
                    int startIndex = strRtf.IndexOf(" ", pictTagIdx) + 1;
                    int endIndex = strRtf.IndexOf("}", startIndex);
                    string imageDataHex = strRtf.Substring(startIndex, endIndex - startIndex);
                    string strTemp = string.Empty;
                    if (imageDataHex.Contains("http"))
                    {
                        strTemp = strRtf.Replace(imageDataHex + "}", "");
                        strRtf = strTemp;
                        startIndex = strTemp.IndexOf(" ", pictTagIdx) + 1;
                        endIndex = strTemp.IndexOf("}", startIndex);
                        imageDataHex = strTemp.Substring(startIndex, endIndex - startIndex);
                    }
                    if (imageDataHex.Contains("data"))
                    {
                        strTemp = strRtf.Replace(imageDataHex + "}", "");
                        strRtf = strTemp;
                        startIndex = strTemp.IndexOf(" ", pictTagIdx) + 1;
                        endIndex = strTemp.IndexOf("}", startIndex);
                        imageDataHex = strTemp.Substring(startIndex, endIndex - startIndex);
                    }
                    byte[] imageBuffer = ToBinary(imageDataHex);
                    string strFileName = ObjEGAEB.DirPath + ObjEGAEB.ProjectNumber + "_" + PositionID.ToString() + "_" + IVlaue.ToString() + ".jpg";
                    File.WriteAllBytes(strFileName, imageBuffer);
                    DataRow drTemp = dt.NewRow();
                    drTemp["PositionID"] = IVlaue;
                    drTemp["Parent_OZ"] = PositionID;
                    drTemp["ExtDatName"] = strFileName;
                    drTemp["ExtDatBeschr"] = "GAEB-XML";
                    dt.Rows.Add(drTemp);
                    pictTagIdx = strRtf.IndexOf("{\\pict\\", endIndex);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public static byte[] ToBinary(string imageDataHex)
        {
            byte[] imageDataBinary = null;
            try
            {
                if (imageDataHex == null)
                {
                    throw new ArgumentNullException("imageDataHex");
                }

                int hexDigits = imageDataHex.Length;
                int dataSize = hexDigits / 2;
                imageDataBinary = new byte[dataSize];

                StringBuilder hex = new StringBuilder(2);

                int dataPos = 0;
                for (int i = 0; i < hexDigits; i++)
                {
                    char c = imageDataHex[i];
                    if (char.IsWhiteSpace(c))
                    {
                        continue;
                    }
                    hex.Append(imageDataHex[i]);
                    if (hex.Length == 2)
                    {
                        imageDataBinary[dataPos] = byte.Parse(hex.ToString(), System.Globalization.NumberStyles.HexNumber);
                        dataPos++;
                        hex.Remove(0, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return imageDataBinary;
        }

        public XmlDocument ExportSupplierproposal(int SupplierProposalID, int ProjectID,string strFormat, string _Raster, EGAEB ObjEGAEB)
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                DataSet dsTMLData = null;
                DataSet dsTMLPositionsData = null;
                dsTMLData = ObjGAEB.Export(ProjectID, _Raster);
                dsTMLPositionsData = ObjGAEB.GetSupplierProposalExport(SupplierProposalID);

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
                dsTMLPositionsData.Locale = CultureInfo.CreateSpecificCulture("de-DE");
                if (dsTMLPositionsData != null && dsTMLPositionsData.Tables.Count > 1)
                {
                    dsTMLPositionsData.Tables[1].TableName = "LVPos";
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
                        dsTMLPositionsData.Tables[2].TableName = "LVPos1";
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
                            dsTMLPositionsData.Tables[3].TableName = "LVPos2";
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
                                dsTMLPositionsData.Tables[4].TableName = "LVPos3";
                                if (strFormat.Contains("D"))
                                {
                                    foreach (DataRow dr in dsTMLPositionsData.Tables[4].Rows)
                                    {
                                        string strKurztext = dr["Kurztext"] == DBNull.Value ? "" : dr["Kurztext"].ToString();
                                        string strPlantext = GetPlaintext(strKurztext);
                                        dr["Kurztext"] = strPlantext;
                                    }
                                }
                                if (dsTMLPositionsData.Tables.Count > 5)
                                {
                                    dsTMLPositionsData.Tables[5].TableName = "LVPos4";
                                    if (strFormat.Contains("D"))
                                    {
                                        foreach (DataRow dr in dsTMLPositionsData.Tables[5].Rows)
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

                dsTMLPositionsData.Tables[0].TableName = "ZuschlTMenge";

                StringBuilder strTMLdata = new StringBuilder();
                strTMLdata.Append(dsTMLData.GetXml());
                bool _IsBind = false;
                if (dsTMLPositionsData.Tables.Count > 0 && strFormat.Contains("X"))
                {
                    DataTable dt = new DataTable("ExtDat");
                    dt.Columns.Add("PositionID", typeof(int));
                    dt.Columns.Add("Parent_OZ", typeof(int));
                    dt.Columns.Add("ExtDatName", typeof(string));
                    dt.Columns.Add("ExtDatBeschr", typeof(string));
                    foreach (DataRow dr in dsTMLPositionsData.Tables[1].Rows)
                    {
                        int IValue = 0;
                        if (int.TryParse(Convert.ToString(dr["PositionID"]), out IValue))
                        {
                            dt = ExtractImages(dt, Convert.ToString(dr["Langtext"]), IValue, ObjEGAEB);
                        }
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _IsBind = true;
                        DataSet dsTemp = new DataSet();
                        dsTemp.Tables.Add(dt);
                        for (int i = 0; i < dsTMLPositionsData.Tables.Count; i++)
                        {
                            DataTable dtTemp = dsTMLPositionsData.Tables[i].Copy();
                            dsTemp.Tables.Add(dtTemp);
                        }
                        dsTMLPositionsData = new DataSet();
                        dsTMLPositionsData = dsTemp.Copy();
                        dsTMLPositionsData.DataSetName = "LV";
                    }
                }


                if (dsTMLPositionsData != null && dsTMLPositionsData.Tables.Count > 1)
                {
                    int iValue = 0;
                    if (_IsBind)
                        iValue = 1;

                    DataColumn ParentColumn, ChildColumn; DataRelation dr;
                    for (int i = dsTMLPositionsData.Tables.Count - 1; i > iValue; i--)
                    {
                        ParentColumn = dsTMLPositionsData.Tables[i].Columns["PositionID"];
                        ChildColumn = dsTMLPositionsData.Tables[i - 1].Columns["Parent_OZ"];
                        dr = new DataRelation("Relation" + i, ParentColumn, ChildColumn);
                        dr.Nested = true;
                        dsTMLPositionsData.Relations.Add(dr);
                    }
                }

                if (_IsBind)
                {
                    DataColumn ParentColumn, ChildColumn; DataRelation dr;
                    ParentColumn = dsTMLPositionsData.Tables[2].Columns["PositionID"];
                    ChildColumn = dsTMLPositionsData.Tables[0].Columns["Parent_OZ"];
                    dr = new DataRelation("RelationDisc", ParentColumn, ChildColumn);
                    dr.Nested = true;
                    dsTMLPositionsData.Relations.Add(dr);
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
                foreach (XmlNode node in xn)
                {
                    string strtype = string.Empty;
                    string strNodeName = node.Name;
                    switch (strNodeName.ToLower())
                    {
                        case "generic":
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
                        case "extdat":
                        case "zuschltmenge":
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
                        case "menge":
                        case "ep":
                        case "gb":
                            strtype = "12";
                            if (Thread.CurrentThread.CurrentCulture.Name == "de-DE")
                            {
                                string strValue = node.InnerText.Replace(".", ",");
                                node.InnerText = strValue;
                            }
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

        public EGAEB SupplierProposalImport(EGAEB ObjEGAEB)
        {
            try
            {
                if (ObjGAEB == null)
                    ObjGAEB = new DGAEB();
                ObjEGAEB = ObjGAEB.SupplierProposalImport(ObjEGAEB);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEGAEB;
        }
    }
}
