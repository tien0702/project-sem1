using System;

namespace Persistance
{
    public class Sugar{
        public int SugarID{set; get;}
        public string Percent{set; get;}
        public Sugar()
        {
            this.SugarID = 1;
            this.Percent = "70% Đường";
        }
    }
}