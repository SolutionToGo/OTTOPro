using DataAccess;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{     
    public class BUserInfo
    {
        DUserInfo ObjDUserInfo = new DUserInfo();

        public int SaveUserDetails(EUserInfo ObjEUserInfo)
        {
            try
            {
                int UserID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/UserInfo";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "UserID", ObjEUserInfo.UserID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "RoleID", ObjEUserInfo.RoleID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "UserName", ObjEUserInfo.UserName.ToString().ToLower());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "FirstName", ObjEUserInfo.FirstName.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "LastName", ObjEUserInfo.LastName);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "Password", ObjEUserInfo.Password);
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "MobileNo", ObjEUserInfo.MobileNo.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "EmailID", ObjEUserInfo.EmailID.ToString());

                UserID = ObjDUserInfo.SaveUserDetails(Xdoc, ObjEUserInfo);
                return UserID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EUserInfo GetUser(EUserInfo ObjEUserInfo)
        {
            try
            {
                if (ObjEUserInfo != null)
                {
                    ObjEUserInfo.dsUserInfo = ObjDUserInfo.GetUser();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUserInfo;
        }

        public int SaveUserRoles(EUserInfo ObjEUserInfo)
        {
            try
            {
                int RoleID = -1;
                XmlDocument Xdoc = new XmlDocument();
                string XPath = "/Nouns/UserRole";
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "RoleID", ObjEUserInfo.RoleID.ToString());
                Xdoc = XMLBuilder.XmlConstruct(Xdoc, XPath, "RoleName", ObjEUserInfo.RoleName.ToString());


                RoleID = ObjDUserInfo.SaveUserRoles(Xdoc, ObjEUserInfo);
                return RoleID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EUserInfo GetUserRoles(EUserInfo ObjEUserInfo)
        {
            try
            {
                if (ObjEUserInfo != null)
                {
                    ObjEUserInfo.dsUserRole = ObjDUserInfo.GetUserRoles();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUserInfo;
        }

        public EUserInfo GetFeatureData(EUserInfo ObjEUserInfo)
        {
            try
            {
                if (ObjEUserInfo != null)
                {
                    ObjEUserInfo = ObjDUserInfo.GetFeatureDetails(ObjEUserInfo);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUserInfo;
        }

        public EUserInfo GetAceesLevels(EUserInfo ObjEUserInfo)
        {
            try
            {
                if (ObjEUserInfo != null)
                {
                    ObjEUserInfo = ObjDUserInfo.GetAceesLevels(ObjEUserInfo);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUserInfo;
        }

        public EUserInfo SaveFeatureMap(EUserInfo ObjEUserInfo,DataTable dt)
        {
            try
            {
                if (ObjEUserInfo != null)
                {
                    ObjEUserInfo = ObjDUserInfo.SaveFeatureMap(ObjEUserInfo, dt);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUserInfo;
        }

        public EUserInfo CheckUserCredentials(EUserInfo ObjEUserInfo)
        {
            try
            {
                ObjEUserInfo = ObjDUserInfo.CheckUserCredentials(ObjEUserInfo);
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjEUserInfo;
        }
    }
}
