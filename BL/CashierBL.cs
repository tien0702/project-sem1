using System;
using DAL;
using Persistance;

namespace BL
{
    public class CashierBL
    {
        private CashierDAL dal = new CashierDAL();
        public int Login(Cashier cashier){
            return dal.Login(cashier);
        }
    }
}
