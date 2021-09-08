using System;
using Xunit;
using Persistance;
using DAL;

namespace DALTest
{
    public class CashierTest
    {
        private Cashier cashier = new Cashier();
        private CashierDAL dal = new CashierDAL();
        [Theory]
        [InlineData("Administrator", "AdiminPF13", 1)]
        [InlineData("Tientv", "TienPF13", 2)]
        [InlineData("Phuocmh", "adfdf", 0)]
        [InlineData("Phucabc", "PhucPF13", 0)]
        [InlineData("admin", "adfsdf", 0)]
        public void LoginTest(string userName, string pass, int expected){
            cashier.UserName = userName;
            cashier.Password = pass;
            int result = dal.Login(cashier).Role;
            Assert.True(expected == result);
        }
    }
}