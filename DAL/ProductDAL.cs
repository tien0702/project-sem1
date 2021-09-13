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
                    else
                    {
                        products = null;
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

        public List<Product> GetByCategory(string category_name){
            List<Product> products = new List<Product>();
            lock(connection){
                try{
                  connection.Open();
                    string query = "select *from Product, Category where product_category_id = category_id and category_name like '%"+category_name+"%';";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        do{
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
                    else
                    {
                        products = null;
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
            List<TypeProduct> types = new List<TypeProduct>();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Type, ProductTypes where (ProductTypes.product_id = '"+product_id+
                    "') and (ProductTypes.type_id = Type.type_id) and (Product.product_id = ProductTypes.product_id);";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        do{
                            types.Add(new TypeProduct(){
                                TypeID = reader.GetInt32("type_id"),
                                TypeValue = reader.GetString("type_value")
                            });
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
            return types.ToArray();
        }
        public Sugar[] GetProductSugar(int product_id){
            List<Sugar> sugars = new List<Sugar>();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Sugar, ProductSugar where (ProductSugar.product_id = '"+product_id+
                    "') and (ProductSugar.sugar_id = Sugar.sugar_id) and (Product.product_id = ProductSugar.product_id);";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        do{
                            sugars.Add(new Sugar(){
                                SugarID = reader.GetInt32("sugar_id"),
                                Percent = reader.GetString("percent")
                            });
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
            return sugars.ToArray();
        }
        public Ice[] GetProductIce(int product_id){
            List<Ice> ices = new List<Ice>();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Ice, ProductIce where (ProductIce.product_id = '"+product_id+
                    "') and (ProductIce.ice_id = Ice.ice_id) and (Product.product_id = ProductIce.product_id);";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        do{
                            ices.Add(new Ice(){
                                IceID = reader.GetInt32("ice_id"),
                                Perscent = reader.GetString("percent")
                            });
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
            return ices.ToArray();
        }
        public Topping[] GetToppings(int product_id){
            List<Topping> toppings = new List<Topping>();
            lock(connection){
                try{
                    connection.Open();
                    string query = "select *from Product, Topping, ProductToppings where (ProductToppings.product_id = '"+product_id+
                    "') and (ProductToppings.topping_id = Topping.topping_id) and (Product.product_id = ProductToppings.product_id);";
                    MySqlDataReader reader = DbHelper.ExecQuery(query);
                    if(reader.Read()){
                        do{
                            toppings.Add(new Topping(){
                                ToppingId = reader.GetInt32("topping_id"),
                                ToppingName = reader.GetString("topping_name"),
                                UnitPrice = reader.GetDouble("unit_price")
                            });
                        }while(reader.Read());
                    }
                    else
                    {
                        toppings = null;
                    }
                    reader.Close();
                }
                catch
                {
                    toppings = null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return toppings.ToArray();
        }
    }
}