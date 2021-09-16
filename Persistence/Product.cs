using System;
using System.Collections.Generic;

namespace Persistance
{
    public class Product{
        public int ProductId{set; get;}
        public string ProductName{set; get;}
        public List<Topping> ListTopping{set; get;}
        public Category ProductCategory{set; get;}
        public TypeProduct Types{set; get;}
        public Size ProductSize{set; get;}
        public int Quantity{set; get;}
        public Sugar Sugar{set; get;}
        public Ice Ice{set; get;}
        public string ProductInfo{
            get{
                return string.Format("{0, -45}x{1, -6}+{2,-2}K", ProductName, Quantity, ProductSize.UnitPrice/1000);
            }
        }
        public Product()
        {
            this.ListTopping = new List<Topping>();
            this.Types = new TypeProduct();
            this.Sugar = new Sugar();
            this.Ice = new Ice();
        }
    }
}