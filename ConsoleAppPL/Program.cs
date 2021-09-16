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
        private static InputAndOutputData data = new InputAndOutputData();
        private static string NAME_STONE = "♥ RELIFE ♥";
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            CashierPL cashierPL = new CashierPL();
            Cashier cashier = new Cashier();;
            ConsoleKey key;
            cashier.Role = 2;
            do{
                // cashier = Login();
                if(cashier.UserName == "Escape")
                {
                    data.TextColor(" ► GOODBYE!", ConsoleColor.Blue);
                    break;
                }
                else if(cashier.Password == "Escape")
                {
                    data.TextColor(" ► GOODBYE!", ConsoleColor.Blue);
                    break;
                }
                int role = cashier.Role;
                if(role == 2)
                {
                    cashierPL.MenuCashier(cashier);
                }
                else if(role == 1)
                {

                }
                else
                {
                    data.TextColor(" ▲! Wrong account or password! ", ConsoleColor.Red);
                    data.TextColor("\nPress ESC to exit or press any key to continue... ", ConsoleColor.Green);
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;
                    if(key == ConsoleKey.Escape){
                        data.TextColor(" ► GOODBYE!", ConsoleColor.Blue);
                        break;
                    }
                }
            }while(true);
        }//┌──────────────────────────────────────────────────┐
        // static Cashier Login()
        // {
        //     Console.Clear();
        //     Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
        //     Console.WriteLine("│                                             {0, -10}                                           │", "< RELIFE >");
        //     Console.WriteLine("│                                       ╞────────────────────╡                                     │");
        //     Console.WriteLine("╞───────────────────────────────────────────────────────────────────┬──────────────────────────────╡");
        //     Console.WriteLine("│                         ~~~          -------   LOGIN   -------          ~~~                      │");
        //     Console.WriteLine("╞──────────────────────────────────────────────────────────────────────────────────────────────────╡");
        //     Console.WriteLine("│                                                                                                  │");
        //     Console.WriteLine("│                       ┌──────────────────────────────────────────────────┐                       │");
        //     Console.WriteLine("│                       │  <> User Name:                                   │                       │");//40, 8
        //     Console.WriteLine("│                       └──────────────────────────────────────────────────┘                       │");
        //     Console.WriteLine("│                                                                                                  │");
        //     Console.WriteLine("│                       ┌──────────────────────────────────────────────────┐                       │");
        //     Console.WriteLine("│                       │  <> Password:                                    │                       │");
        //     Console.WriteLine("│                       └──────────────────────────────────────────────────┘                       │");
        //     Console.WriteLine("│                                                                                                  │");
        //     Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────┘");

        // }
        static Cashier Login(){
            Console.Clear();
            Cashier cashier = new Cashier();
            CashierBL cashierBL = new CashierBL();
            int role;
            ConsoleKey key;
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                   {0, -10}                                   │", NAME_STONE);
            Console.WriteLine("│                             ╞────────────────────╡                             │");
            Console.WriteLine("╞────────────────────────────────────────────────────────────────────────────────╡");
            Console.WriteLine("│               ~~~          -------   LOGIN   -------          ~~~              │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────┘");
            do{
                data.TextColor(" -- <> User Name: ", ConsoleColor.Green);
                do{
                    cashier.UserName = data.ReadString();
                    if(!IsValidUserName(cashier.UserName)){
                        data.TextColor(" ▲! Invalid User Name! Please re-enter: ", ConsoleColor.Red);
                    }
                }while(!IsValidUserName(cashier.UserName));
                if(cashier.UserName == "Escape")
                {
                    break;
                }
                data.TextColor(" -- <> Password: ", ConsoleColor.Green);
                while(!IsValidPassword(cashier.Password = GetPassword())) data.TextColor(" ▲! Invalid Password! Please re-enter: ", ConsoleColor.Red);
                if(cashier.Password == "Escape")
                {
                    break;
                }
                role = cashierBL.Login(cashier).Role;
                if(role <= 0)
                {
                    data.TextColor(" ▲! Wrong account or password! ", ConsoleColor.Red);
                }
                else
                {
                    break;
                }
                data.TextColor("\nPress ESC to exit or press any key to continue... ", ConsoleColor.Green);
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if(key == ConsoleKey.Escape){
                    break;
                }
                Console.WriteLine();
            }while(key != ConsoleKey.Escape);
            return cashier;
        }

        static bool IsValidUserName(string userName){
            Regex regex = new Regex(@"^[A-Za-z0-9]{3,16}$");
            if(regex.IsMatch(userName)) return true;
            return false;
        }
        static bool IsValidPassword(string password){
            if(password == "Escape")
            {
                return true;
            }
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
            if(regex.IsMatch(password)) return true;
            return false;
        }
        static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if(key == ConsoleKey.Escape)
                {
                    return key.ToString();
                }

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