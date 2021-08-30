using System;
using System.Text.RegularExpressions;

namespace BL
{
    public class ValidData{
        public bool IsEmail(string email){
            Regex regex =  new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.([A-Z]{2,4})$", RegexOptions.IgnoreCase);
            if(regex.IsMatch(email)) return true;
            return false;
        }
        public bool IsPhone(string phone){
            Regex regex = new Regex(@"^([0-9]{10})$");
            if(regex.IsMatch(phone)) return true;
            return false;
        }
        public bool IsTime(string time){
            Regex regex = new Regex(@"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$");
            if(regex.IsMatch(time)) return true;
            return false;
        }
        public bool IsNamePerson(string name){
            Regex regex = new Regex(@"^[A-Za-z ]{2,35}$");
            if(regex.IsMatch(name)) return true;
            return false;
        }
        public string ConvertString(string str){
            str = str.Trim();
            if(str.Length == 0) return str;
            int i, leng;
            string result = "";
            while(str.IndexOf("  ") != -1){
                str = str.Replace("  ", " ");
            }
            string[] subName = str.Split(" ");
            leng = subName.Length;
            string firstChar, otherChar;
            for(i=0; i<leng; i++){
                firstChar = subName[i].Substring(0, 1);
                otherChar = subName[i].Substring(1);
                subName[i] = firstChar.ToUpper() + otherChar.ToLower();
                result += subName[i] + " ";
            }
            return result.Trim();
        }
    }
}