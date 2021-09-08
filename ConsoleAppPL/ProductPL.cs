using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class ProductPL{
        ProductBL productBL = new ProductBL();
        // public int SearchByName(){
        //     int count = 0;
        //     Console.Write("Input Name Search: ");
        //     string search_name = Console.ReadLine();
        //     List<Product> list_product = productBL.GetByName(search_name);
        //     if(list_product.Count > 0){
        //         foreach(Product p in list_product){
        //             Console.WriteLine( "{0}. {1}",++count , p.ProductName);
        //         }
        //     }else{
        //         Console.WriteLine("Not Found!");
        //     }

        //     return 0;
        // }
        // public int SearchById(){
        //     Console.Write("Input ID Product: ");
        //     int search;
        //     int.TryParse(Console.ReadLine(), out search);
        //     Product product = new Product();
        //     product = productBL.SearchById(search);
        //     if (product != null)
        //     {
        //         Console.WriteLine(product.ProductName);
        //     }else{
        //         Console.WriteLine("Not Found!");
        //     }
        //     return 0;
        // }
    }
}