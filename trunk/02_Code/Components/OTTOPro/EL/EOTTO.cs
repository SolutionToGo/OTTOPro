﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EOTTO
    {
        //To hold the OTTO Details
        private int _OTTOID = -1;
        private string _ShortName;
        private string _FullName;
        private bool _IsBranch;
        private string _Street;
        private string _PostalCode;
        private string _City;
        private string _Country;
        private string _ILN;
        private string _BankName;
        private string _BankPostalCode;
        private string _BankAccNo;
        private string _DVNr;
        private string _TenderNo;
        private string _DebtorNo;
        private string _CountryType;
        private string _Industry;
        private string _ArtBevBew;
        private string _ArtNU;
        private string _BGBez;
        private string _BGDatum;
        private string _BGNr;
        private DataSet _dtOTTO;


        // To hold the OTTO Contacts
        private int _ContactID = -1;
        private int _Cont_OttoID;
        private string _ContactPerson;
        private string _Cont_Telephone;
        private string _Fax;
        private string _EmailID;
        private string _TaxNo;
        private bool _DefaultContact;


        // OTTO Properties
        public DataSet dsOTTO
        {
            get { return _dtOTTO; }
            set { _dtOTTO = value; }
        }
        public int OTTOID
        {
            get { return _OTTOID; }
            set { _OTTOID = value; }
        }
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        public bool IsBranch
        {
            get { return _IsBranch; }
            set { _IsBranch = value; }
        }
        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        public string ILN
        {
            get { return _ILN; }
            set { _ILN = value; }
        }
        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }
        public string BankPostalCode
        {
            get { return _BankPostalCode; }
            set { _BankPostalCode = value; }
        }
        public string BankAccNo
        {
            get { return _BankAccNo; }
            set { _BankAccNo = value; }
        }
        public string DVNr
        {
            get { return _DVNr; }
            set { _DVNr = value; }
        }
        public string TenderNo
        {
            get { return _TenderNo; }
            set { _TenderNo = value; }
        }
        public string DebtorNo
        {
            get { return _DebtorNo; }
            set { _DebtorNo = value; }
        }
        public string CountryType
        {
            get { return _CountryType; }
            set { _CountryType = value; }
        }
        public string Industry
        {
            get { return _Industry; }
            set { _Industry = value; }
        }
        public string ArtBevBew
        {
            get { return _ArtBevBew; }
            set { _ArtBevBew = value; }
        }
        public string ArtNU
        {
            get { return _ArtNU; }
            set { _ArtNU = value; }
        }
        public string BGBez
        {
            get { return _BGBez; }
            set { _BGBez = value; }
        }
        public string BGDatum
        {
            get { return _BGDatum; }
            set { _BGDatum = value; }
        }
        public string BGNr
        {
            get { return _BGNr; }
            set { _BGNr = value; }
        }


        // OTTO Contact Properties
        public int ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        public int Cont_OttoID
        {
            get { return _Cont_OttoID; }
            set { _Cont_OttoID = value; }
        }
        public string ContactPerson
        {
            get { return _ContactPerson; }
            set { _ContactPerson = value; }
        }
        public string Cont_Telephone
        {
            get { return _Cont_Telephone; }
            set { _Cont_Telephone = value; }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }
        public string TaxNo
        {
            get { return _TaxNo; }
            set { _TaxNo = value; }
        }
        public bool DefaultContact
        {
            get { return _DefaultContact; }
            set { _DefaultContact = value; }
        }

        //************
    }
}