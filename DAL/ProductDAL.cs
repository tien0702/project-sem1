using System;
using Persistance;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ProductDAL{
        private MySqlConnection connection = DbHelper.GetConnection();
        public Product GetByID(int product_id){
            Product product = new Product();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Category where product_id='"+product_id+"' and product_category_id = category_id;";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        product.ProductId = reader.GetInt32("product_id");
                        product.ProductName = reader.GetString("product_name");
                        product.ProductCategory = new Category(){
                            CategoryId = reader.GetInt32("category_id"),
                            CategoryName = reader.GetString("category_name")
                        };
                        product.ProductSize = new Size(){
                            SizeId = 1,
                            SizeName = "M",
                            UnitPrice = reader.GetDouble("unit_price")
                        };
                        product.Quantity = reader.GetInt32("quantity");
                    }else{
                        product = null;
                    }
                    reader.Close();
                }catch{
                    product = null;
                }finally{
                    connection.Close();
                }
            }
            return product;
        }
        public List<Product> GetByName(string product_name){
            List<Product> products = new List<Product>();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Category where product_name like '%"+ product_name +"%' and product_category_id = category_id";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read())
                    {
                        do
                        {
                            products.Add(new Product(){
                                ProductId = reader.GetInt32("product_id"),
                                ProductName = reader.GetString("product_name"),
                                ProductCategory = new Category()
                                {
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
                    }
                    reader.Close();
                }
                catch
                {
                    products = null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public List<Product> GetListProduct(){
            List<Product> products = new List<Product>();
            lock(connection){
                try
                {
                    connection.Open();
                    string query = "select *from Product, Category where product_category_id = category_id order by product_category_id;";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read())
                    {
                        do
                        {
                            products.Add(new Product()
                            {
                                ProductId = reader.GetInt32("product_id"),
                                ProductName = reader.GetString("product_name"),
                                ProductCategory = new Category()
                                {
                                    CategoryId = reader.GetInt32("category_id"),
                                    CategoryName = reader.GetString("category_name")
                                },
                                ProductSize = new Size()
                                {
                                    SizeId = 1,
                                    SizeName = "M",
                                    UnitPrice = reader.GetDouble("unit_price")
                                },
                                Quantity = reader.GetInt32("quantity")
                            });
                        }while(reader.Read());
                    }
                    reader.Close();
                }
                catch
                {
                    products = null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }
        public TypeProduct[] GetProductTypes(int product_id){
            TypeProduct[] types = new TypeProduct[2];
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Type, ProductType where '"+product_id+"' = ProductType.product_id and Type.ice_id = ProductType.ice_id;";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        int i = 0;
                        do{
                            types[i].TypeID = reader.GetInt32("type_id");
                            types[i++].TypeValue = reader.GetString("type_value");
                        }while(reader.Read());
                    }else{
                        types = null;
                    }
                }catch{
                    types = null;
                }finally{
                    connection.Close();
                }
            }
            return types;
        }
        public Sugar[] GetProductSugar(int product_id){
            Sugar[] sugars = new Sugar[5];
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Ice, ProductIce where '"+product_id+"' = ProductIce.product_id and Ice.ice_id = ProductIce.ice_id;";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        int i = 0;
                        do{
                            sugars[i].SugarID = reader.GetInt32("sugar_id");
                            sugars[i++].Percent = reader.GetString("percent");
                        }while(reader.Read());
                    }else{
                        sugars = null;
                    }
                }catch{
                    sugars = null;
                }finally{
                    connection.Close();
                }
            }
            return sugars;
        }
        public Ice[] GetProductIce(int product_id){
            Ice[] ices = new Ice[6];
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Ice, ProductIce where '"+product_id+"' = ProductIce.product_id and Ice.ice_id = ProductIce.ice_id;";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        int i = 0;
                        do{
                            ices[i].IceID = reader.GetInt32("ice_id");
                            ices[i++].Perscent = reader.GetString("percent");
                        }while(reader.Read());
                    }else{
                        ices = null;
                    }
                }catch{
                    ices = null;
                }finally{
                    connection.Close();
                }
            }
            return ices;
        }
    }
}