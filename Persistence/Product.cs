using System;
using System.Collections.Generic;

namespace Persistance
{
    public class Product{
        public int ProductId{set; get;}
        public string ProductName{set; get;}
        public Topping ListTopping{set; get;}
        public Category ProductCategory{set; get;}
        public Type[] Types{set; get;}
        public Size ProductSize{set; get;}
        public int Quantity{set; get;}
        public Sugar[] Sugar{set; get;}
        public Ice[] Ice{set; get;}
        public Product(){}
    }
}