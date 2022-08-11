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
        public string CreateAndCovert(int length)
        {
            string path = "text.txt";
            List<string> stringList = new List<string>(StaticClass.StringToList(path).Split(' '));
            for (int y = 0; y < 10; y++)
            {
                if (length == 0)
                {
                    break;
                }
                int templength = length;
                StaticClass.ListStringShuffling(stringList);
                string newPasword = "";
                List<string> selectedWords = new List<string>();
                Random random = new Random();
                for (int i = 0; i < 100; i++)
                {
                    char firstChar = rusSmallLetterList[random.Next(0, rusSmallLetterList.Count)];
                    foreach (var item in stringList)
                    {
                        if (item.Length > 0 && item[0] == firstChar && item.Length <= templength && selectedWords.Contains(item) == false)
                        {
                            if (templength == 0)
                            {
                                break;
                            }
                            else if (templength == 1 && item.Length > 0)
                            {
                                templength -= item.Length;
                                newPasword += item;
                                selectedWords.Add(item);
                                Console.Write(item + " ");
                            }
                            else if (item.Length > 1)
                            {
                                templength -= item.Length;
                                newPasword += item;
                                selectedWords.Add(item);
                                Console.Write(item + " ");
                            }
                        }
                    }
                }
                Console.Write("- ");
                if (templength != 0)
                {
                    Console.WriteLine(newPasword + " - " + newPasword.Length + " - Не получилось подобрать пароль");
                }
                else
                {
                    Console.Write(newPasword + " - ");
                    Console.Write(convert(newPasword) + "\n");
                }
            }
            Console.ReadLine();
            return "";
        }
        string convert(string password)
        {
            List<NewChar> listChar = new List<NewChar>();
            string newPassword = "";
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                bool match = false;
                foreach (NewChar item in listChar)
                {
                    if (item.char1 == password[i])
                    {
                        newPassword += item.number;
                        Console.Write("(" +item.char1 + item.number+")");
                        match = true;
                        break;
                    }
                }
                if (match == false)
                {
                    NewChar newChar = new NewChar();
                    newChar.char1 = password[i];
                    newChar.number = count;
                    newPassword += count.ToString();
                    listChar.Add(newChar);
                    count++;
                    Console.Write("(" + newChar.char1 + newChar.number + ")");
                    if (count > 9)
                    {
                        count = 0;
                    }
                }
            }
            Console.Write(" - ");
            return newPassword;
        }
        class NewChar
        {
            public char char1 = ' ';
            public int number = 0;
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
