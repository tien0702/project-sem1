using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class CashierPL{
        private InputAndOutputData data = new InputAndOutputData();
        private string NAME_STONE = "♥ RELIFE ♥";
        public void MenuCashier(Cashier cashier){
            string[] menu = new string[]{"1. Search Product", "2. Create Invoice", "3. Log Out"};
            string[] keys = new string[]{"1", "2", "3"};
            int length_menu = menu.Length;
            ProductPL productPL = new ProductPL();
            InvoicePL invoicePL = new InvoicePL();
            string choice;
            do{
                Console.Clear();
                Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                                   {0, -10}                                   │", NAME_STONE);
                Console.WriteLine("│                             ╞────────────────────╡                             │");
                Console.WriteLine("╞────────────────────────────────────────────────────────────────────────────────╡");
                Console.WriteLine("│ >| Welcome: {0, -25} >| Date: {1: dddd, dd/MM/Y}            │", cashier.FullName, DateTime.Now.ToString());
                Console.WriteLine("╞────────────────────────────────────────────────────────────────────────────────╡");
                for(int i = 0; i < 12; i++){
                    Console.WriteLine("│ {0, -79}│", (i<length_menu)?(menu[i]):(""));
                }
                Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────┘");
                choice = data.Choice(keys);
                switch(choice){
                    case "1":
                        productPL.Menu(cashier);
                        break;
                    case "2":
                        productPL.MenuProduct(4);
                        break;
                }
            }while(choice != "3");
        }
    }
}