using System;
using DAL;
using Persistance;
using System.Collections.Generic;

namespace BL
{
    public class ProductBL{
        private ProductDAL dal = new ProductDAL();
        public Product SearchById(int id_product){
            return dal.GetByID(id_product);
        }
        public List<Product> GetByName(string search_name){
            return dal.GetByName(search_name);
        }

        public List<Product> GetListProduct(){
            return dal.GetListProduct();
        }
        public List<Product> SearchByCategory(string category_name){
            return dal.GetByCategory(category_name);
        }
        public TypeProduct[] GetProductType(int product_id){
            return dal.GetProductTypes(product_id);
        }
        public Sugar[] GetPruoductSugar(int product_id){
            return dal.GetProductSugar(product_id);
        }
        public Topping[] GetToppings()
        {
            return dal.GetToppings();
        }
        public Ice[] GetProductIce(int product_id){
            return dal.GetProductIce(product_id);
        }
    }
}