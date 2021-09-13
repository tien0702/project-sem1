using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    public class InvoicePL
    {
        private InputAndOutputData data = new InputAndOutputData();
        private ProductBL productBL = new ProductBL();
        private string NAME_STONE = "♥ RELIFE ♥";
        public void Menu()
        {

        }
        public void DetailProduct(int product_id)
        {
            string[] menu = new string[]{"Choose Type", "Choose Size", "Choose Sugar", "Choose Ice", "Choose Topping"};
            string[] keys = new string[]{"1", "2", "3", "4", "5", "Escape"};
            string choose;
            Product product = productBL.SearchById(product_id);
            do{
                choose = data.Choice(keys);
                switch(choose)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                }
            }while(true);
        }
    }
}