
using System;
using System.Text;

namespace ConsoleAppPL
{
    public class InputAndOutputData
    {
        private string CHOICE_INVALID = "▲! Invalid! Please re-enter";
        private string CHOICE = " -- <> Your choice: ";
        public int Select(int limitF, int limitR)
        {
            return 1;
        }
        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public ConsoleKey ChoiceKey(ConsoleKey[] keys)
        {
            ConsoleKey key;
            do{
                Console.WriteLine();
                TextColor(CHOICE, ConsoleColor.Green);
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if(KeyExists(key, keys))
                {
                    return key;
                }
                else
                {
                    Console.WriteLine();
                    TextColor(CHOICE_INVALID, ConsoleColor.Red);
                }
            }while(true);
        }
        
        public string Choice(string[] keys){
            string result;
            do
            {
                TextColor(string.Format("\n " + CHOICE), ConsoleColor.Green);
                result = ReadString();
                if(StringExists(result, keys))
                {
                    break;
                }
                else
                {
                    TextColor(string.Format("\n " + CHOICE_INVALID), ConsoleColor.Red);
                }
            }while(true);
            return result;
        }
        public bool KeyExists(ConsoleKey key, ConsoleKey[] keys)
        {
            var result = false;;
            foreach(var k in keys)
            {
                if(k == key)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public bool StringExists(string key, string[] keys){
            bool result = false;;
            int count = keys.Length;
            for(int i = 0; i < count; i++){
                if(keys[i].ToUpper() == key.ToUpper()){
                    result = true;
                    break;
                }
            }
            return result;
        }
        public string ReadString(){
            var result = string.Empty;
            ConsoleKey key;
            do{
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if(key == ConsoleKey.Enter){
                    break;
                }
                else if (key == ConsoleKey.Backspace && result.Length > 0)
                {
                    Console.Write("\b \b");
                    result = result[0..^1];
                }
                else if((key == ConsoleKey.Escape) || (key == ConsoleKey.RightArrow) || (key == ConsoleKey.LeftArrow)){
                    return key.ToString();
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write(keyInfo.KeyChar);
                    result += keyInfo.KeyChar;
                }
            }while(key != ConsoleKey.Enter);
            Console.WriteLine();
            return result;
        }
        public void TextColor(string text, ConsoleColor color){
            ConsoleColor foreground = (color);
            Console.ForegroundColor = foreground;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}