using System;
using Xunit;
using Persistance;
using DAL;

namespace DALTest
{
    public class DALTest
    {
            private Cashier cashier = new Cashier();
            private CashierDAL dal = new CashierDAL();
        [Fact]
        public void LoginTest1()
        {
            cashier.UserName = "Administrator";
            cashier.Password = "tienvtca";
            int expected = 1;
            int result = dal.Login(cashier);
            Assert.True(expected == result);
        }

        [Theory]
        [InlineData("admin", "adfsdf", 0)]
        [InlineData("Administrator", "tienvtca", 1)]
        public void LoginTest2(string userName, string pass, int expected){
            cashier.UserName = userName;
            cashier.Password = pass;
            int result = dal.Login(cashier);
            Assert.True(expected == result);
        }
    }
}