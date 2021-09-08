using System;
using Persistance;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ProductDAL{
        private MySqlConnection connection = DbHelper.GetConnection();
        // public Product GetById(int id_product){
        //     Product resultProduct = new Product();
        //     try{
        //         MySqlConnection connection = DbHelper.GetConnection();
        //         connection.Open();
        //         string query = "select *from Product where product_id= '" + id_product + "';";
        //         MySqlDataReader reader = DbHelper.ExecQuery(query);
        //         if (reader.Read()){
        //             resultProduct.ProductId = reader.GetInt32("product_id");
        //             resultProduct.ProductName = reader.GetString("product_name");
        //         }else{
        //             resultProduct = null;
        //         }
        //         reader.Close();
        //         connection.Close();
        //     }catch{
        //         resultProduct = null;
        //     }
        //     return resultProduct;
        // }
        // public List<Product> GetByName(string product_name){
        //     List<Product> list_product = new List<Product>();
        //     try{
        //         MySqlConnection connection = DbHelper.GetConnection();
        //         connection.Open();
        //         string query = "select *from Product where product_name like '%"+ product_name +"%' order by product_name;";
        //         MySqlDataReader reader = DbHelper.ExecQuery(query);
        //         if(reader.Read()){
        //             do{
        //                 list_product.Add(new Product(){
        //                     ProductId = reader.GetInt32("product_id"),
        //                     ProductName = reader.GetString("product_name"),
        //                     ProductCategory = new Category(){
        //                         CategoryId = reader.GetInt32("category_id"),
        //                         CategoryName = reader.GetString("category_name")
        //                     },
        //                     ProductSize = new Size(){
        //                         SizeId = 1,
        //                         SizeName = "S",
        //                         UnitPrice = reader.GetDouble("unit_price")
        //                     },
        //                     Quantity = reader.GetInt32("quantity")
        //                 });
        //             }while(reader.Read());
        //         }
        //         reader.Close();
        //         connection.Close();
        //     }catch{}
        //     return list_product;
        // }
        
        // public List<Product> GetListProduct(){
        //     List<Product> list_product = new List<Product>();
        //     try{
        //         MySqlConnection connection = DbHelper.GetConnection();
        //         connection.Open();
        //         string query = "select *from Product, Category where product_category_id = category_id order by product_category_id;";
        //         MySqlDataReader reader = DbHelper.ExecQuery(query);
        //         if(reader.Read()){
        //             do{
        //                 list_product.Add(new Product(){
        //                     ProductId = reader.GetInt32("product_id"),
        //                     ProductName = reader.GetString("product_name"),
        //                     ProductCategory = new Category(){
        //                         CategoryId = reader.GetInt32("category_id"),
        //                         CategoryName = reader.GetString("category_name")
        //                     },
        //                     ProductSize = new Size(){
        //                         SizeId = 1,
        //                         SizeName = "S",
        //                         UnitPrice = reader.GetDouble("unit_price")
        //                     },
        //                     Quantity = reader.GetInt32("quantity")
        //                 });
        //             }while(reader.Read());
        //         }
        //         reader.Close();
        //         connection.Close();
        //     }catch{}
        //     return list_product;
        // }
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
                            types[i++].TypeValue = reader.GetInt32("type_value");
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
                            sugars[i++].Percent = reader.GetFloat("percent");
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
                            ices[i++].Perscent = reader.GetFloat("percent");
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