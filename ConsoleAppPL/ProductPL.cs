using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class ProductPL{
        private ProductBL productBL = new ProductBL();
        private InputAndOutputData data = new InputAndOutputData();
        private string NAME_STONE = "♥ RELIFE ♥";
        public void Menu(Cashier cashier){
            var products = new List<Product>();
            products = productBL.GetListProduct();
            string choice;
            do
            {
                if(products == null)
                {
                    break;
                }
                choice = ShowListProduct(products);
                switch(choice.ToUpper())
                {
                    case "ALL":
                        products = productBL.GetListProduct();
                        break;
                    case "ESCAPE":
                        break;
                    case "A":
                        break;
                    case "B":
                        products = SearchByName();
                        break;
                    case "C":
                        products = SearchByCategory();
                        break;
                    default:
                        int temp;
                        int.TryParse(choice, out temp);
                        if(temp < 1 || temp > 15)
                        {
                            Console.WriteLine("Invalid");
                        }
                        else
                        {
                            Console.WriteLine("waiting...");
                        }
                        break;
                }
            }while(choice != "Escape");
        }
        public List<Product> SearchByCategory()
        {
            List<Product> products;
            string category;
            do{
                data.TextColor("\n    <> Enter Category Name: ", ConsoleColor.Green);
                category = data.ReadString();
                products = productBL.SearchByCategory(category);
                if(category.ToUpper() == "ALL")
                {
                    Console.WriteLine();
                    products = productBL.GetListProduct();
                    break;
                }
                if(category == "Escape")
                {
                    products = null;
                    break;
                }
                else if(products != null)
                {
                    break;
                }
                else
                {
                    data.TextColor(" ▲! No products found!", ConsoleColor.Red);
                    data.TextColor("\nPress ESC to exit or or enter the product name to continue... ", ConsoleColor.Blue);
                    Console.WriteLine();
                }
            }while(category != "Escape");
            return products;
        }
        public string[] GetTypeProduct(int product_id)
        {
            TypeProduct[] types;
            types = productBL.GetProductType(product_id);
            string[] options;
            if(types == null)
            {
                options = null;
            }
            else
            {
                int length = types.Length;
                options = new string[length];
                for(int i = 0; i < length; i++)
                {
                    options[i] = types[i].TypeValue;
                }
            }
            return options;
        }
        public string[] GetSugarProduct(int product_id)
        {
            Sugar[] sugars;
            sugars = productBL.GetPruoductSugar(product_id);
            string[] options;
            if(sugars == null)
            {
                options = null;
            }
            else
            {
                int length = sugars.Length;
                options = new string[length];
                for(int i = 0; i < length; i++)
                {
                    options[i] = sugars[i].Percent;
                }
            }
            return options;
        }
        public string[] ShowOptionsIceProduct(int product_id)
        {
            Ice[] ices;
            ices = productBL.GetProductIce(product_id);
            string[] options;
            if(ices == null)
            {
                options = null;
            }
            else
            {
                int length = ices.Length;
                options = new string[length];
                for(int i = 0; i < length; i++)
                {
                    options[i] = ices[i].Perscent;
                }
            }
            return options;
        }
        public string[] ShowTopping()
        {
            Topping[] toppings;
            toppings = productBL.GetToppings();
            string[] options;
            if(toppings == null)
            {
                options = null;
            }
            else
            {
                int length = toppings.Length;
                options = new string[length];
                for(int i = 0; i < length; i++)
                {
                    options[i] = string.Format("{0, -30} +{1, -2}K", toppings[i].ToppingName, toppings[i].UnitPrice/1000);
                }
            }
            return options;
        }
        public void ShowPage(string[] menuA, string[] menuB, string name_menuA, string name_menuB, string name_menu)
        {
            int length_menuA = menuA.Length;
            int length_menuB = menuB.Length;
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                             {0, -10}                                             │", NAME_STONE);
            Console.WriteLine("│                                       ╞────────────────────╡                                       │");
            Console.WriteLine("╞───────────────────────────────────────────────────────────────────┬────────────────────────────────╡");
            Console.WriteLine("╞{0, -68}│{1, -31}╡", name_menuA, name_menuB); //68 + 31 | 102
            Console.WriteLine("╞───────────────────────────────────────────────────────────────────┴────────────────────────────────╡");
            for(int i = 0; i < 15; i++)
            {
                Console.Write("│{0, -68}│", (i < length_menuA)?(string.Format(" {0, -2}. {1, -63}", length_menuA+1, menuA[length_menuA])):(""));
                Console.WriteLine("{0, -31}│", (i < length_menuB)?(string.Format(" {0, -2}. {1, -26}", length_menuB+1, menuB[length_menuB])):(""));
            }
            Console.WriteLine("╞─────         ~~~~~            {0, -2}/ {1, -2} ↔         ~~~~~         ─────╬────────────────────────────────╡");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────┴────────────────────────────────┘");
        }
        public Product MenuProduct(int product_id)
        {
            string[] menu = new string[]{"Choose Type", "Choose Size", "Choose Sugar", "Choose Ice", "Choose Topping"};
            Product product = productBL.SearchById(product_id);
            int index;
            
            string choice = "Enter";
            do
            {
                Console.Clear();
                Form("OPTIONS", "DETAIL PRODUCT");
                DetailProduct(product);
                switch(choice)
                {
                    case "Enter":
                        choice = Options(menu, "Options");
                        break;
                    case "1":
                        choice = Options(GetTypeProduct(product.ProductId), "Type Product");
                        int.TryParse(choice,  out index);
                        product.Types.TypeValue = GetTypeProduct(product.ProductId)[index];
                        choice = "Enter";
                        break;
                    case "2":
                        break;
                    case "3":
                        choice = Options(GetSugarProduct(product.ProductId), "Sugar");
                        int.TryParse(choice,  out index);
                        product.Sugar.Percent = GetSugarProduct(product.ProductId)[index-1];
                        choice = "Enter";
                        break;
                    case "4":
                        break;
                    case "5":
                        choice = Options(ShowTopping(), "Topping");
                        int.TryParse(choice, out index);
                        choice = "Enter";
                        break;
                }
                if(choice == "Escape")
                {
                    break;
                }
            }while(choice != "Escape");
            return product;
        }
        public void Form(string name_menuA, string name_menuB)
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                             {0, -10}                                           │", NAME_STONE);
            Console.WriteLine("│                                      ╞────────────────────╡                                      │");
            Console.WriteLine("╞─────────────────────────────────────────────────┬────────────────────────────────────────────────╡");
            Console.WriteLine("│               {0, -20}              │               {1, -20}             │", name_menuA, name_menuB);
            Console.WriteLine("╞─────────────────────────────────────────────────╬────────────────────────────────────────────────╡");//100
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("│                                                 │                                                │");
            Console.WriteLine("└─────────────────────────────────────────────────┴────────────────────────────────────────────────┘");
        }
        public string Options(string[] menu, string name_menu)
        {
            string choice;
            int length_menu = menu.Length;
            string[] keys = new string[length_menu+2];
            int x = 2;
            int y = 6;
            data.WriteAt(string.Format("<> " + name_menu), x, y++);
            for(int i = 0; i < length_menu; i++)
            {
                data.WriteAt(string.Format("{0, -2}. {1, -44}", i+1, menu[i]), x, y+i);
                keys[i] = (i+1).ToString();
            }
            keys[length_menu] = "Escape";
            
            keys[length_menu+1] = "Enter";
            Console.SetCursorPosition(1, 23);
            choice = data.Choice(keys);
            return choice;
        }

        public void DetailProduct(Product product)
        {
            int x = 51;
            int y = 6;
            data.WriteAt(string.Format(" <> {0}", product.ProductName), x, y++);
            data.WriteAt(string.Format("   - Type:  " + product.Types.TypeValue), x, y++);
            data.WriteAt(string.Format("   - Size:  " + product.ProductSize.SizeName), x, y++);
            data.WriteAt(string.Format("   - Sugar: " + product.Sugar.Percent), x, y++);
            data.WriteAt(string.Format("   - Ice:   " + product.Ice.Perscent), x, y++);
            data.WriteAt(string.Format("   - Toppings  "), x, y++);
            for(int i = 0; i < product.ListTopping.Count; i++)
            {
                data.WriteAt(string.Format("    + {0}. {1}", i+1, product.ListTopping[i].ToppingName), x, y++);
            }
        }
        public string ShowListProduct(List<Product> products){
            string[] menu = new string[]{"A: Search By ID", "B: Search By Name", "C: Search By Category", "ESC: Back To Main Menu", "ALL: Show All Products"};
            string[] options = new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "A",
                                             "B", "C", "LeftArrow", "RightArrow", "Escape", "all"};
            Product[] list_product = new Product[15];
            int length_menu = menu.Length;
            int count_products = products.Count;
            int max_page = (count_products%15 == 0)?(count_products/15):(count_products/15+1);
            int[] page = new int[max_page];
            page[0] = 0;
            string choice;
            for(int i = 1; i < max_page; i++) page[i] = i*15-1;
            int page_number = 1;
            int index;
            do{
                index = page[page_number-1];
                for(int i = 0; i < 15; i++) list_product[i] = (index<count_products)?(products[index++]):(null);
                ShowPage(list_product, menu, page_number, max_page);
                choice = data.Choice(options);
                if(choice == "LeftArrow" && page_number == 1 || (choice == "RightArrow" && page_number == max_page))
                {
                    data.TextColor("\n ▲! Limit reached! Press any key to continue...", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else
                {
                    switch(choice)
                    {
                        case "Escape":
                            Console.Clear();
                            data.TextColor("\n   ► Back", ConsoleColor.Blue);
                            Console.WriteLine();
                            break;
                        case "LeftArrow":
                            page_number--;
                            break;
                        case "RightArrow":
                            page_number++;
                            break;
                        default:
                            return choice;
                    }
                }
            }while(choice != "Escape");
            return choice;
        }
        public void ShowPage(Product[] products, string[] menu, int page_number, int max_page)
        {
            Console.Clear();
            int count_menu = 0;
            int length_menu = menu.Length;
            string category_name = products[0].ProductCategory.CategoryName;
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                             {0, -10}                                             │", NAME_STONE);
            Console.WriteLine("│                                       ╞────────────────────╡                                       │");
            Console.WriteLine("╞───────────────────────────────────────────────────────────────────┬────────────────────────────────╡");
            Console.WriteLine("╞─     ──────────────        LIST PRODUCTS     ──────────────      ─╬─      ─────  MENU  ──────     ─╡"); //102
            Console.Write("│ <> {0, -63}│", category_name);
            Console.WriteLine((count_menu<length_menu)?(string.Format(" {0, -31}│", menu[count_menu++])):(string.Format("{0, -32}│", "")));
            for(int i = 0; i < 15; i++)
            {
                if(products[i] != null){
                    if(products[i].ProductCategory.CategoryName != category_name)
                    {
                        category_name = products[i].ProductCategory.CategoryName;
                        Console.Write("│ <> {0, -63}│", category_name);
                        Console.WriteLine((count_menu<length_menu)?(string.Format(" {0, -31}│", menu[count_menu++])):(string.Format("{0, -32}│", "")));
                    }
                }
                Console.Write((products[i]!= null)?(string.Format("│    {0, -2}. {1, -59}│", i+1, products[i].ProductInfo)):(string.Format("│{0, -67}│", "")));
                Console.WriteLine((count_menu<length_menu)?(string.Format(" {0, -31}│", menu[count_menu++])):(string.Format("{0, -32}│", "")));
            }
            Console.WriteLine("╞─────         ~~~~~         << {0, -2}/ {1, -2}>>         ~~~~~         ─────╬────────────────────────────────╡", page_number, max_page);
            Console.WriteLine("└───────────────────────────────────────────────────────────────────┴────────────────────────────────┘");
        }
        public List<Product> SearchByName(){
            List<Product> products;
            string product_name;
            do{
                data.TextColor("    <> Enter product name: ", ConsoleColor.Green);
                product_name = data.ReadString();
                if(product_name.ToUpper() == "ALL")
                {
                    products = productBL.GetListProduct();
                    break;
                }
                products = productBL.GetByName(product_name);
                if(product_name == "Escape")
                {
                    Console.WriteLine();
                    products = null;
                    break;
                }
                else if(products != null)
                {
                    break;
                }
                else
                {
                    data.TextColor(" ▲! No products found!", ConsoleColor.Red);
                    data.TextColor("\nPress ESC to exit or or enter the product name to continue... ", ConsoleColor.Blue);
                    Console.WriteLine();
                } 
            }while(product_name != "Escape");
            return products;
        }
        public int SearchById(){
            data.TextColor("    <> Enter ID Product: ", ConsoleColor.Green);
            int search;
            int.TryParse(Console.ReadLine(), out search);
            Product product = new Product();
            product = productBL.SearchById(search);
            if (product != null)
            {
                Console.WriteLine(product.ProductInfo);
            }else{
                data.TextColor("No products found!", ConsoleColor.Red);
            }
            return 0;
        }
    }
}