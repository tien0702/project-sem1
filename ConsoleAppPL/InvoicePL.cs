using System;
using System.Text.RegularExpressions;
using Persistance;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    public class InvoicePL
    {
        private Invoice invoice = new Invoice();
        private InputAndOutputData data = new InputAndOutputData();
        private ProductBL productBL = new ProductBL();
        private ProductPL productPL = new ProductPL();
        private string NAME_STONE = "♥ RELIFE ♥";
        public void ChooseSugar(int product_id)
        {
            string[] options = productPL.GetSugarProduct(product_id);
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            Console.Write("Input: ");
            int choose;
            int.TryParse(Console.ReadLine(), out choose);
        }
        public void ChooseIce(int product_id)
        {
            string[] options = productPL.ShowOptionsIceProduct(product_id);
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            Console.Write("Input: ");
            int choose;
            int.TryParse(Console.ReadLine(), out choose);
        }
        public void ChooseTopping()
        {
            string[] options = productPL.ShowTopping();
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            Console.Write("Input: ");
            int choose;
            int.TryParse(Console.ReadLine(), out choose);
        }
        public TypeProduct ChooseType(int product_id)
        {
            TypeProduct type = new TypeProduct();
            string[] options = productPL.GetTypeProduct(product_id);
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            Console.Write("Input: ");
            int choose;
            int.TryParse(Console.ReadLine(), out choose);
            switch(choose)
            {
                case 1:
                break;
            }
            return type;
        }
        
        public void CreateInvoice(Product product)
        {
            string[] menu = {"1. Choose Type", "2. Choose Size", "3. Choose Sugar", "4. Choose Ice", "5. Choose Topping"};
            int count_product = invoice.ListProduct.Count;
            int length_menu = menu.Length;
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                     {0, -10}                                                     │", NAME_STONE);
            Console.WriteLine("│                                               ╞────────────────────╡                                               │");
            Console.WriteLine("╞─────────────────────────────────────────────────────────────────┬──────────────────────────────────────────────────╡");
            Console.WriteLine("│──────────────────────── LIST PRODUCT ───────────────────────────│───────────────────────ORDER──────────────────────╡");
            Console.WriteLine("╞─────────────────────────────────────────────────────────────────┴──────────────────────────────────────────────────╡");//65 50| 102
            for(int i = 0; i < 15; i++)
            {

            }
            Console.WriteLine("└─────────────────────────────────────────────────────────────────┴──────────────────────────────────────────────────┘");
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