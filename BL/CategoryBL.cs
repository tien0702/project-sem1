using System;
using DAL;
using Persistance;
using System.Collections.Generic;

namespace BL
{
    public class CategoryBL{
        private CategoryDAL dal = new CategoryDAL();
        public List<Category> GetListCategories(){
            return dal.GetListCategories();
        }
        public List<Product> SearchByCategory(Category category){
            return dal.GetByCategory(category);
        }
        public Category SearchById(int category_id){
            return dal.GetById(category_id);
        }
    }
}