using System;
using System.Collections.Generic;

namespace Persistance
{
    public class Invoice{
        public string Invoice_No{set; get;}
        public Cashier Invoice_Cashier{set; get;}
        public DateTime date{set; get;}
        public double Total{set; get;}
        public string Payment_Method{set; get;}
        public int Status{set; get;}
        public string Note{set; get;}
        private int WAIT_FOR_PAYMENT = 1;
        private int WAIT_FOR_SERVICE = 2;
        private int DONE = 3;
    }
}