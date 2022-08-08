using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.Json;

namespace Course
{
    public class Password
    {
        List<char> numberList = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public List<char> rusCapitalLetterList = new List<char>() { 'Й', 'Ц', 'У', 'К', 'Е', 'Н', 'Г', 'Ш', 'Щ', 'З', 'Х', 'Ъ', 'Ф', 'Ы', 'В', 'А', 'П', 'Р', 'О', 'Л', 'Д', 'Ж', 'Э', 'Я', 'Ч', 'С', 'М', 'И', 'Т', 'Ь', 'Б', 'Ю' };
        public List<char> rusSmallLetterList = new List<char>() { 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю' };
        public List<char> engCapitalLetterList = new List<char>() { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
        public List<char> engSmallLetterList = new List<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
        public List<char> symbolsList = new List<char>() { '!', '\"', '#', '$', '%', '&', '\'', '(', ')', '*', ',', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
        static List<string> passwords = new List<string>();
        public string Create(int length, Options options)
        {
            List<char> newCharlist = SymbolMixing(options);
            string newpassword = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                newpassword += newCharlist[random.Next(0, newCharlist.Count)];
            }
            passwords.Add(newpassword);
            return newpassword;
        }
        List<char> SymbolMixing(Options options)
        {
            List<char> newCharlist = new List<char>();
            newCharlist.AddRange(numberList);
            if (options.rusCapitalLetter == true)
            {
                newCharlist.AddRange(rusCapitalLetterList);
            }
            if (options.rusSmallLetter == true)
            {
                newCharlist.AddRange(rusSmallLetterList);
            }
            if (options.engCapitalLetter == true)
            {
                newCharlist.AddRange(engCapitalLetterList);
            }
            if (options.engSmallLetter == true)
            {
                newCharlist.AddRange(engSmallLetterList);
            }
            if (options.symbols == true)
            {
                newCharlist.AddRange(symbolsList);
            }
            return newCharlist;
        }
        public string GetAllPassword()
        {
            //var json = JsonSerializer.Serialize(passwords);
            //return json;
            string allPasswords = "";
            {
                foreach (var item in passwords)
                {
                    allPasswords += item + "\n";
                }
            }
            return allPasswords;
        }
    }
    public class Options
    {
        public bool rusCapitalLetter { get; set; } = false;
        public bool rusSmallLetter { get; set; } = false;
        public bool engCapitalLetter { get; set; } = false;
        public bool engSmallLetter { get; set; } = false;
        public bool symbols { get; set; } = false;
    }
}
