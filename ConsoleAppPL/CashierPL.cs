using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class CashierPL{
        private CashierBL cashierBL = new CashierBL();

        public Cashier Login(){
            Cashier cashier = new Cashier();
            CashierBL cashierBL = new CashierBL();
            int role;
            ConsoleKey key;

            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                          ♥ Relife ♥                                            │");
            Console.WriteLine("│                                    ╞─────────────────────╡                                     │");
            Console.WriteLine("╞────────────────────────────────────────────────────────────────────────────────────────────────╡");
            Console.WriteLine("│                      ~~~          -------   LOGIN   -------          ~~~                       │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────┘");
            do{
                TextColor(" -- <> User Name: ", 10);
                while(!IsValidUserName(cashier.UserName = Console.ReadLine())) TextColor(" ▲! Invalid User Name! Please re-enter: ", 12);
                TextColor(" -- <> Password: ", 10);
                while(!IsValidPassword(cashier.Password = GetPassword())) TextColor(" ▲! Invalid Password! Please re-enter: ", 12);
                role = cashierBL.Login(cashier).Role;

                if(role <= 0)
                {
                    TextColor(" ▲! Wrong account or password! ", 12);
                }
                else
                {
                    break;
                }
                TextColor("\nPress ESC to exit or press any key to continue... ", 10);
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                Console.WriteLine();
            }while(key != ConsoleKey.Escape);
            return cashier;
        }

        public void ShowMenuSale(Cashier cashier, string[] menu_sale)
        {
            string[] menu = new string[]{"1. Search By Name", "2. Search By ID", "3. Search By Category", "4. Create Invoice"};
            int length_menu_sale = menu_sale.Length;
            ConsoleKey key;
            ProductPL productPL = new ProductPL();
            ProductBL productBL = new ProductBL();

            do{
                Console.Clear();
                Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                                          ♥ Relife ♥                                            │");
                Console.WriteLine("│                                    ╞─────────────────────╡                                     │");
                Console.WriteLine("╞────────────────────────────────────────────────────────────────────────────────────────────────╡");
                Console.WriteLine("│ >| Welcome: {0, -42} >| Date: {1: dddd, dd/MM/Y}           │", cashier.FullName, DateTime.Now.ToString());
                Console.WriteLine("╞────────────────────────────────────────────────────────────────────────────────────────────────╡"); //98
                for(int i = 0; i < 12; i++){
                    Console.WriteLine("│   {0, -93}│", i<length_menu_sale?(menu_sale[i]):"");
                }
                Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────┘");
                TextColor("Enter ESC to exit or select the corresponding function: ", 10);
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if(key == ConsoleKey.D1)
                {
                    productPL.Menu(cashier, productBL.GetListProduct(), menu);
                }
                else if(key == ConsoleKey.D2)
                {
                    TextColor("\nUnfinished function....", 9);
                    TextColor("\n Press any key to continue... ", 10);
                    Console.ReadLine();
                }
                else if(key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    TextColor(" ▲! Invalid! Please re-enter", 9);
                    Console.WriteLine();
                }
            }while(key != ConsoleKey.Escape);
        }

        public void TextColor(string text, int color){
            ConsoleColor foreground = (ConsoleColor)(color);
            Console.ForegroundColor = foreground;
            Console.Write(text);
            Console.ResetColor();
        }

        public bool IsValidUserName(string userName){
            Regex regex = new Regex(@"^[A-Za-z0-9]{3,16}$");
            if(regex.IsMatch(userName)) return true;
            return false;
        }
        public bool IsValidPassword(string password){
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            if(regex.IsMatch(password)) return true;
            return false;
        }
        
        public string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
    }
}