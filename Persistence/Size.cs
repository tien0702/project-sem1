using System;

namespace Persistance
{
    public class Size{
        public int SizeId{set; get;}
        public string SizeName{set; get;}
        public double UnitPrice{set; get;}
        public Size()
        {
            this.SizeId = 1;
            this.SizeName = "M";
        }
    }
}