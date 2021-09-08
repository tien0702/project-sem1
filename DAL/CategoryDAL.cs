using System;
using Persistance;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class CategoryDAL{
        private MySqlConnection connection = DbHelper.GetConnection();
        public List<Category> GetListCategories(){
            List<Category> categories = new List<Category>();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Category;";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        do{
                            categories.Add(new Category(){
                                CategoryId = reader.GetInt32("category_id"),
                                CategoryName = reader.GetString("category_name")
                            });
                        }while(reader.Read());
                    }else{
                        categories = null;
                    }
                    reader.Close();
                }catch{
                    categories = null;
                }
                finally{
                    connection.Close();
                }
            }
            return categories;
        }
        public Category GetById(int category_id){
            Category category = new Category();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Category where category_id='"+category_id+"';";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        category.CategoryName = reader.GetString("category_name");
                        category.CategoryId = reader.GetInt32("category_id");
                    }else{
                        category = null;
                    }
                    reader.Close();
                }catch{
                    category = null;
                }
                finally{
                    connection.Close();
                }
            }
            return category;
        }
        public List<Product> GetByCategory(Category category){
            List<Product> products = new List<Product>();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Category where product_category_id = category_id and category_id ='"+category.CategoryId+"';";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        do{
                            products.Add(new Product(){
                                ProductId = reader.GetInt32("product_id"),
                                ProductName = reader.GetString("product_name"),
                                ProductCategory = new Category(){
                                    CategoryId = reader.GetInt32("category_id"),
                                    CategoryName = reader.GetString("category_name")
                                },
                                ProductSize = new Size(){
                                    SizeId = 1,
                                    SizeName = "M",
                                    UnitPrice = reader.GetDouble("unit_price")
                                },
                                Quantity = reader.GetInt32("quantity")
                            });
                        }while(reader.Read());
                    }else
                    {
                        products = null;
                    }
                    reader.Close();
                }catch{
                    products = null;
                }
                finally{
                    connection.Close();
                }
            }
            return products;
        }
    }
}