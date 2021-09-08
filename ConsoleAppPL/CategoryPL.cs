using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class CategoryPL{
        private CategoryBL categoryBL = new CategoryBL();
        public int SearchByCategory(){
            int count = 1;
            int choose;
            List<Product> products;
            ConsoleKey key;
            CategoryBL categoryBL = new CategoryBL();
            List<Category> categories = categoryBL.GetListCategories();

            foreach(Category c in categories){
                Console.WriteLine("{0}. {1}", count++, c.CategoryName);
            }
            do{
                count = 1;
                Console.Write("Input: ");
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                choose = (int)key - 48;
                Console.WriteLine(choose);
                if(choose <= 0 || choose > categories.Count){
                    Console.WriteLine("Invalid!");
                }else{
                    products = categoryBL.SearchByCategory(categories[choose - 1]);
                    if(products.Count == 0){
                        Console.WriteLine("Not Found!");
                    }else{
                        count=1;
                        foreach(Product p in products){
                            Console.WriteLine("{0}. {1}", count++, p.ProductName);
                        }
                    }
                }
            }while(choose <= 0 || choose > categories.Count);
            Console.WriteLine("-----------------------------------------");
            return count;
        }
    }
}