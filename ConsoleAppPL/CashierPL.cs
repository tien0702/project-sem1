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
            string choice;
            do{
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
                        break;
                    case "3":
                        Console.Clear();
                        data.TextColor("  ► LOG OUT", ConsoleColor.Blue);
                        Console.WriteLine();
                        break;
                }
            }while(choice != "3");
        }
    }
}