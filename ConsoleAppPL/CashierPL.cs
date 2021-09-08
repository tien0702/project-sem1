using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    class CashierPL{
        private CashierBL cashierBL = new CashierBL();
        // public int Login(){
        //     string userName, pass;
        //     int login = 0;
        //     do{
        //         Console.Write("User Name: ");
        //         while(!IsValidUserName(userName = Console.ReadLine())) Console.Write("User Name Invalid! Please re-enter: ");
        //         Console.Write("Password: ");
        //         while(!IsValidPassword(pass = GetPassword())) Console.Write("Password Invalid! Please re-enter: ");

        //         Cashier cashier = new Cashier(){UserName = userName, Password = pass};
        //         CashierBL BL = new CashierBL();
        //         login = BL.Login(cashier);
        //         if(login <= 0){
        //             Console.WriteLine("Wrong account or password!");
        //         }else if(login == 1){
        //             Console.WriteLine("Menu Manager");
        //         }else if(login == 2){
        //             Console.WriteLine("Menu Saleman");
        //         }
        //     }while(login <= 0);
        //     return 0;
        // }
        
        static string GetPassword()
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

        static bool IsValidUserName(string userName){
            Regex regex = new Regex(@"^[A-Za-z ]{5,16}$");
            if(regex.IsMatch(userName)) return true;
            return false;
        }
        static bool IsValidPassword(string password){
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
            if(regex.IsMatch(password)) return true;
            return false;
        }
    }
}