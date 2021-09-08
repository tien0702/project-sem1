using Xunit;
using Persistance;
using DAL;

namespace DALTest{
    public class ProductDalTest{
        private Product product = new Product();
        private ProductDAL dal = new ProductDAL();

        [Theory]
        [InlineData()]
        public void GetProductTypesTest(string product_id){
            
        }
    }
}