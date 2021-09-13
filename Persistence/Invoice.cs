using System;
using System.Collections.Generic;

namespace Persistance
{
    public class Invoice{
        public string InvoiceNo{set; get;}
        public Cashier InvoiceCashier{set; get;}
        public List<Product> ListProduct {set; get;}
        public DateTime Date{set; get;}
        public double Total{set; get;}
        public string PaymentMethod{set; get;}
        public int Status{set; get;}
        public string Note{set; get;}
        private int WAIT_FOR_PAYMENT = 1;
        private int WAIT_FOR_SERVICE = 2;
        private int DONE = 3;
        public Invoice(){
            ListProduct = new List<Product>();
        }
    }
}