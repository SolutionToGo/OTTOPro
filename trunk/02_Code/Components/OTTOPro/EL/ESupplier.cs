﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class ESupplier
    {
        //To hold the Supplier Details
        private int _SupplierID = -1;
        private string _SupplierFullName;
        private string _SupplierShortName;
        private string _PaymentCondition;
        private string _CreatedBy;
        private DateTime _CreatedDate;
        private string _LastUpdatedBy;
        private DateTime _LastUpdatedDate;
        private bool _IsActive;
        private string _Commentary;
        private DataSet _dsSupplier;
        private DataTable _dtSupplier;


        // To hold the Supplier Contacts
        private int _ContactPersonID = -1;
        private int _Cont_supplierID;
        private string _ContactName;
        private string _Salutation;
        private string _Designation;
        private string _ContEmailID;
        private string _ContTelephone;
        private string _ContFax;
        private bool _DefaultContact;
        private DataTable _dtContact;

        // To hold the Supplier Address
        private int _AddressID = -1;
        private int _Addr_supplierID;
        private string _AddressShortName;
        private string _StreetNo;
        private string _AddrPostalCode;
        private string _AddrCity;
        private string _AddrCountry;
        private bool _DefaultAddress;
        private DataTable _dtAddress;

        //To hold the article data
        private int _WGWAID = -1;
        private string _WG;
        private string _WA;
        private string _WGDescription;
        private DataTable _dtArticle;

        // Article Properties and entities
        public int WGWAID
        {
            get { return _WGWAID; }
            set { _WGWAID = value; }
        }
        public string WG
        {
            get { return _WG; }
            set { _WG = value; }
        }
        public string WA
        {
            get { return _WA; }
            set { _WA = value; }
        }
        public string WGDescription
        {
            get { return _WGDescription; }
            set { _WGDescription = value; }
        }
        public DataTable dtArticle
        {
            get { return _dtArticle; }
            set { _dtArticle = value; }
        }
        
        // Supplier Properties
        public DataSet dsSupplier
        {
            get { return _dsSupplier; }
            set { _dsSupplier = value; }
        }
        public int SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
        public string SupplierFullName
        {
            get { return _SupplierFullName; }
            set { _SupplierFullName = value; }
        }
        public string SupplierShortName
        {
            get { return _SupplierShortName; }
            set { _SupplierShortName = value; }
        }
        public string PaymentCondition
        {
            get { return _PaymentCondition; }
            set { _PaymentCondition = value; }
        }
        public string Commentary
        {
            get { return _Commentary; }
            set { _Commentary = value; }
        }
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        public string LastUpdatedBy
        {
            get { return _LastUpdatedBy; }
            set { _LastUpdatedBy = value; }
        }
        public DateTime LastUpdatedDate
        {
            get { return _LastUpdatedDate; }
            set { _LastUpdatedDate = value; }
        }
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public DataTable dtSupplier
        {
            get { return _dtSupplier; }
            set { _dtSupplier = value; }
        }

        // Supplier Contact Properties
        public int ContactPersonID
        {
            get { return _ContactPersonID; }
            set { _ContactPersonID = value; }
        }
        public int Cont_supplierID
        {
            get { return _Cont_supplierID; }
            set { _Cont_supplierID = value; }
        }
        public string Salutation
        {
            get { return _Salutation; }
            set { _Salutation = value; }
        }
        public string ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }
        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }
        public string ContEmailID
        {
            get { return _ContEmailID; }
            set { _ContEmailID = value; }
        }
        public string ContTelephone
        {
            get { return _ContTelephone; }
            set { _ContTelephone = value; }
        }
        public string ContFax
        {
            get { return _ContFax; }
            set { _ContFax = value; }
        }
        public bool DefaultContact
        {
            get { return _DefaultContact; }
            set { _DefaultContact = value; }
        }
        public DataTable dtContact
        {
            get { return _dtContact; }
            set { _dtContact = value; }
        }

        // Supplier Address Properties
        public int AddressID
        {
            get { return _AddressID; }
            set { _AddressID = value; }
        }
        public int Addr_supplierID
        {
            get { return _Addr_supplierID; }
            set { _Addr_supplierID = value; }
        }
        public string AddressShortName
        {
            get { return _AddressShortName; }
            set { _AddressShortName = value; }
        }
        public string StreetNo
        {
            get { return _StreetNo; }
            set { _StreetNo = value; }
        }
        public string AddrPostalCode
        {
            get { return _AddrPostalCode; }
            set { _AddrPostalCode = value; }
        }
        public string AddrCity
        {
            get { return _AddrCity; }
            set { _AddrCity = value; }
        }
        public string AddrCountry
        {
            get { return _AddrCountry; }
            set { _AddrCountry = value; }
        }
        public bool DefaultAddress
        {
            get { return _DefaultAddress; }
            set { _DefaultAddress = value; }
        }
        public DataTable dtAddress
        {
            get { return _dtAddress; }
            set { _dtAddress = value; }
        }

    }
}