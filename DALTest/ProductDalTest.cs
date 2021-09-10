using Xunit;
using Persistance;
using DAL;

namespace DALTest{
    public class ProductDalTest{
        private Product product = new Product();
        private ProductDAL dal = new ProductDAL();

        [Theory]
        [InlineData(1, 1)]
        public void GetByIDTest(int product_id, int expected){
            product = dal.GetByID(product_id);
            int result = product.ProductId;
            Assert.True(result == expected);
        }
    }
}