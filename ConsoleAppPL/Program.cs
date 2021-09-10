using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            CashierPL cashierPL = new CashierPL();
            Cashier cashier = cashierPL.Login();
            ProductPL productPL = new ProductPL();
            string[] menu;

            int role = cashier.Role;
            if(role == 2){
                menu = new string[]{"1. Show Products", "2. Show Invoices Waiting"};
                cashierPL.ShowMenuSale(cashier, menu);
            }
            // ProductBL productBL = new ProductBL();
            // TypeProduct[] types = productBL.GetProductType(3);
            // Console.WriteLine("------------------------------------");
            // foreach(TypeProduct t in types){
            //     Console.WriteLine("Type: " + t.TypeValue);
            // }
            // Console.WriteLine("------------------------------------");
            // Sugar[] sugars = productBL.GetPruoductSugar(3);
            // foreach(Sugar s in sugars){
            //     Console.WriteLine("Sugar: " + s.Percent);
            // }
            // Console.WriteLine("------------------------------------");
            // Ice[] ices = productBL.GetProductIce(3);
            // foreach(Ice i in ices){
            //     Console.WriteLine("Ice: " + i.Perscent);
            // }
        }

    }
}