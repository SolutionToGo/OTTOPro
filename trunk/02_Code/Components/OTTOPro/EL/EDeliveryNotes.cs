using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EDeliveryNotes
    {
        private int _ProjectID = -1;
        private DataTable _dtPositions;
        private DataTable _dtDelivery;
        private int _DeliveryNumberID = -1;
        private string _DeliveryNumber;
        private bool _ISActiveDelivery;
        private DataTable _dtNonActivedelivery;
        private int _BlattNumber = 0;
        private string _BlattName;
        private DataTable _dtDeliveryNumbers;
        
        public int ProjectID
        {
            get { return _ProjectID; }
            set { _ProjectID = value; }
        }
        
        public DataTable dtPositions
        {
            get { return _dtPositions; }
            set { _dtPositions = value; }
        }

        public DataTable dtDelivery
        {
            get { return _dtDelivery; }
            set { _dtDelivery = value; }
        }

        public int DeliveryNumberID
        {
            get { return _DeliveryNumberID; }
            set { _DeliveryNumberID = value; }
        }

        public string DeliveryNumber
        {
            get { return _DeliveryNumber; }
            set { _DeliveryNumber = value; }
        }

        public bool ISActiveDelivery
        {
            get { return _ISActiveDelivery; }
            set { _ISActiveDelivery = value; }
        }

        public DataTable dtNonActivedelivery
        {
            get { return _dtNonActivedelivery; }
            set { _dtNonActivedelivery = value; }
        }

        public int BlattNumber
        {
            get { return _BlattNumber; }
            set { _BlattNumber = value; }
        }

        public string BlattName
        {
            get { return _BlattName; }
            set { _BlattName = value; }
        }

        public DataTable dtDeliveryNumbers
        {
            get { return _dtDeliveryNumbers; }
            set { _dtDeliveryNumbers = value; }
        }
    }
}
