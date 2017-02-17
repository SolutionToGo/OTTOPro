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
            return xmlDocument;
        }
    }
}
