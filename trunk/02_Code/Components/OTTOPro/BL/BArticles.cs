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

namespace BL
{
    public class BArticles
    {
        DArticles ObjDArticles = null;

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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEArticle.ValidityDate.ToString(CultureInfo.CreateSpecificCulture("en-US")));
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1", ObjEArticle.Multi1.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2", ObjEArticle.Multi2.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3", ObjEArticle.Multi3.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4", ObjEArticle.Multi4.ToString());
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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ListPrice", ObjEArticle.ListPrice.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "GMulti", ObjEArticle.GMulti.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Minuten", ObjEArticle.Minuten.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEArticle.ValidityDate.ToString());
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
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi1", ObjEArticle.Multi1.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi2", ObjEArticle.Multi2.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi3", ObjEArticle.Multi3.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Multi4", ObjEArticle.Multi4.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "ValidityDate", ObjEArticle.ValidityDate.ToString(CultureInfo.CreateSpecificCulture("en-US")));
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
                ObjEArticle = ObjDArticles.SaveDimensionCopy(ObjEArticle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEArticle;
        }
    }
}
