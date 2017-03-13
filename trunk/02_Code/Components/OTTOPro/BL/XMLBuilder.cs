using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class XMLBuilder
    {
        public static XmlDocument XmlConstruct(XmlDocument xmlDocument, string xpath, string Name, string Value)
        {
            try
            {
                XmlNode parentNode = xmlDocument;
                xpath += "/" + Name;
                if (xmlDocument != null && !string.IsNullOrEmpty(xpath))
                {
                    string[] partsOfXPath = xpath.Split('/');
                    string xPathSoFar = string.Empty;
                    foreach (string xPathElement in partsOfXPath)
                    {
                        if (string.IsNullOrEmpty(xPathElement))
                            continue;
                        xPathSoFar += "/" + xPathElement.Trim();
                        XmlNode childNode = xmlDocument.SelectSingleNode(xPathSoFar);
                        if (childNode == null)
                        {
                            childNode = xmlDocument.CreateElement(xPathElement);
                        }
                        parentNode.AppendChild(childNode);
                        parentNode = childNode;
                    }
                    XmlText text1 = xmlDocument.CreateTextNode(Value);
                    parentNode.AppendChild(text1);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return xmlDocument;
        }

        public static XmlDocument XmlConstructWithIndex(XmlDocument XMLDoc,string XPath,string Name,string Value,int Index)
        {
            try
            {
                XmlNode parentNode = XMLDoc;
                XPath += "/" + Name;
                if (XMLDoc != null && !string.IsNullOrEmpty(XPath))
                {
                    string[] partsOfXPath = XPath.Split('/');
                    string xPathSoFar = string.Empty;
                    foreach (string xPathElement in partsOfXPath)
                    {
                        if (string.IsNullOrEmpty(xPathElement))
                            continue;
                        xPathSoFar += "/" + xPathElement.Trim();
                        XmlNode childNode = XMLDoc.SelectSingleNode(xPathSoFar);
                        if (childNode == null)
                        {
                            childNode = XMLDoc.CreateElement(xPathElement);
                        }
                        parentNode.AppendChild(childNode);
                        parentNode = childNode;
                    }
                    XmlText text1 = XMLDoc.CreateTextNode(Value);
                    parentNode.AppendChild(text1);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return XMLDoc;
        }
    }
}
