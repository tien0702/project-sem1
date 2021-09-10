using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class ProductPL{
        ProductBL productBL = new ProductBL();
        public List<Product> SearchByName(){
            List<Product> products =new List<Product>();
            ConsoleKey key;
            do{
                TextColor(" -- <> Enter product name: ", 10);
                string product_name = Console.ReadLine();
                products = productBL.GetByName(product_name);
                if(products != null){
                    foreach(Product p in products){
                        Console.WriteLine(p.ProductInfo);
                    }
                }else{
                    TextColor(" ▲! No products found!", 9);
                } 
                TextColor("\nPress ESC to exit or press any key to continue... ", 10);
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
            }while(key != ConsoleKey.Escape);
            return products;
        }
        public int SearchById(){
            TextColor(" -- <> Enter ID Product: ", 10);
            int search;
            int.TryParse(Console.ReadLine(), out search);
            Product product = new Product();
            product = productBL.SearchById(search);
            if (product != null)
            {
                Console.WriteLine(product.ProductInfo);
            }else{
                TextColor("No products found!", 9);
            }
            return 0;
        }
        public void TextColor(string text, int color){
            ConsoleColor foreground = (ConsoleColor)(color);
            Console.ForegroundColor = foreground;
            Console.Write(text);
            Console.ResetColor();
        }
        public int Menu(Cashier cashier, List<Product> list_products, string[] menu){
            Product[] products = new Product[12];
            products[0] = list_products[0];
            Console.WriteLine(products[0].ProductCategory.CategoryName);

            int count_products = list_products.Count;
            int number_page = 1;
            int max_number_page = count_products/12 + 1;
            int index = 0;
            int save_index;
            int leng_menu = menu.Length;
            int result = 0;

            ConsoleKey key;

            do{
                Console.Clear();
                save_index = index;
                for(int i =0; i < 12; i++){
                    if(index < count_products){
                        products[i] = list_products[index++];
                    }else{
                        products[i] = null;
                    }
                }
                Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                                          ♥ Relife ♥                                            │");
                Console.WriteLine("│                                    ╞─────────────────────╡                                     │");
                Console.WriteLine("╞────────────────────────────────────────────────────────────────────────────────────────────────╡");
                Console.WriteLine("│ >| Welcome: {0, -42} >| Date: {1: dddd, dd/MM/Y}           │", cashier.FullName, DateTime.Now.ToString());
                Console.WriteLine("╞─────────────────────────────────────────────┬───────────┬──────────┬───────────────────────────╡");
                Console.WriteLine("│ {0, -44}│ {1, -10}│ {2, -8} │     ---   MENU   ---      │", "Product Name", "Quantity", "Price");
                Console.WriteLine("╞─────────────────────────────────────────────┼───────────┼──────────┼───────────────────────────╡");
                ShowPage(products, menu);
                Console.WriteLine("╞─────────────────────────────────────────────┴───────────┴──────────┴───────────────────────────╡");
                Console.WriteLine("╞─                   ~~~~~~                  <<  {0, -2}/ {1,-2} >>                ~~~~~~                ─╡", number_page, max_number_page);
                Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────┘");
                TextColor("Press ESC to exit or select the corresponding function in the Menu: ", 10);
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if(key == ConsoleKey.Escape){
                    break;
                }
                else if((key == ConsoleKey.LeftArrow && number_page == 1) || (key == ConsoleKey.RightArrow && number_page == max_number_page))
                {
                    index = save_index;
                    TextColor("\n ▲! Limit reached! Press any key to continue...", 12);
                    Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    if(key == ConsoleKey.RightArrow){
                        TextColor("Next", 12); Console.WriteLine();
                        number_page++;
                    }
                    else if(key == ConsoleKey.LeftArrow)
                    {
                        TextColor("Back", 12); Console.WriteLine();
                        number_page--;
                        index = save_index-12;
                    }
                    else if(key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if((int)key >= 1 && (int)key <= leng_menu)
                    {
                        result = (int)key;
                        break;
                    }
                    else
                    {
                        index = save_index;
                        TextColor("\n ▲! Invalid! Press any key to continue...", 9);
                        Console.ReadLine();
                        Console.WriteLine();
                    }
                }
            }while(key != ConsoleKey.Escape);
            return result;
        }
        public void ShowPage(Product[] products, string[] menu){
            int length_products = products.Length;
            int count_menu = 0;
            int count = 0;
            int leng_menu = menu.Length;

            string category_name = products[0].ProductCategory.CategoryName;
            Console.Write("│ <> {0, -41}╞{1, -11}┼{2, -8}╡", category_name, "───────────", "──────────");
            Console.WriteLine(" {0, -26}│", count_menu == leng_menu?(""):(menu[count_menu++]));
            foreach(Product p in products){
                if(p == null){
                    Console.Write("│{0, -45}│{1, -11}│{2, -10}│", " ", " ", " ");
                    Console.WriteLine(" {0, -26}│", count_menu == leng_menu?(""):(menu[count_menu++]));
                    continue;
                }
                if(p.ProductCategory.CategoryName != category_name){
                    category_name = p.ProductCategory.CategoryName;
                    Console.Write("│ <> {0, -41}╞{1, -11}┼{2, -8}╡", category_name, "───────────", "──────────");
                    Console.WriteLine(" {0, -26}│", count_menu == leng_menu?(""):(menu[count_menu++]));
                }
                Console.Write("│   {0, -2}. {1, -57}│", ++count, p.ProductInfo);
                Console.WriteLine(" {0, -26}│", count_menu == leng_menu?(""):(menu[count_menu++]));
            }
        }
    }
}