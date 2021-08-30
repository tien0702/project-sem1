using System;
using System.Collections.Generic;

namespace Persistance
{
    public class Product{
        public int Product_Id{set; get;}
        public string Product_Name{set; get;}
        public Topping List_Topping{set; get;}
        public Category Product_Category{set; get;}
        public Size Product_Size{set; get;}
        public int Quantity{set; get;}
        public float Sugar{set; get;}
        public float Ice{set; get;}
        public bool Is_Active{set; get;}
    }
}