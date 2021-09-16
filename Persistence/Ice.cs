using System;

namespace Persistance
{
    public class Ice{
        public int IceID{set; get;}
        public string Perscent{set; get;}
        public Ice()
        {
            this.IceID = 1;
            this.Perscent = "Không Đá Mát";
        }
    }
}