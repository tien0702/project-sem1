using System;

namespace Persistance
{
    public class TypeProduct{
        public int TypeID{set; get;}
        public string TypeValue{set; get;}
        public TypeProduct()
        {
            this.TypeID = 1;
            this.TypeValue = "Lạnh";
        }
    }
}