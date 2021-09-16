using Xunit;
using Persistance;
using System.Collections.Generic;
using DAL;

namespace DALTest{
    public class ProductDalTest{
        private Product product = new Product();
        private ProductDAL dal = new ProductDAL();

        [Theory]
        [InlineData(1, "Matcha Đậu Đỏ", 1, true)]
        [InlineData(2, "Matcha Đậu Đỏ", 1, false)]
        [InlineData(1, "abc", 1, false)]
        [InlineData(1000, "Matcha Đậu Đỏ", 1, false)]
        [InlineData(1, "Matcha Đậu Đỏ", 123456, false)]
        public void GetByIDTest(int product_id, string product_name, int product_category_id, bool expected)
        {
            bool result = true;
            product = dal.GetByID(product_id);
            if(product != null){
                if(product.ProductName != product_name || product.ProductCategory.CategoryId != product_category_id)
                {
                    result = false;
                }
            }else{
                result = false;
            }
            Assert.True(result == expected);
        }
        [Theory]
        [InlineData("tra sua", 14, true)]
        [InlineData("Trà Sữa", 14, true)]
        [InlineData("Trà Sữa", 15, false)]
        [InlineData("kimono", 10, false)]
        [InlineData("kimono", 4, false)]
        public void GetByNameTest(string product_name, int quantity, bool expected)
        {
            bool result = true;
            List<Product> products = dal.GetByName(product_name);
            if(products != null)
            {
                int count = products.Count;
                if (count != quantity)
                {
                    result = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (products[i].ProductName.ToUpper().IndexOf(product_name.ToUpper()) < 0)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }else{
                result = false;
            }
            Assert.True(result == expected);
        }
    }
}