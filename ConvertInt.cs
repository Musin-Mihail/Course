
namespace Course
{
    public class ConvertInt
    {
        List<int> listInt = new List<int>();
        List<int> listIntKopeck = new List<int>();
        public string number = "";
        bool error = false;
        string result = "";
        public void StartGame()
        {
            Console.Clear();
            if (result.Length > 0)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("Введите сумму. Пример: \"34\", \"22,87\", \"1567.45\"");
            number = Console.ReadLine();
            Console.Clear();
            result = Convert();
            Console.WriteLine(result);
            if (error == true)
            {
                error = false;
                StartGame();
            }
            else
            {
                Console.ReadLine();
            }
        }
        public string Convert()
        {
            foreach (char char2 in number)
            {
                if (Char.IsNumber(char2) == false)
                {
                    if (char2 != ',' && char2 != '.')
                    {
                        Console.Clear();
                        error = true;
                        return "Неверный формат ввода";
                    }
                }
            }
            IntToList(number);
            string kopecks = "";
            kopecks = IntToString(1, " копеек") + kopecks;
            string rub = "";
            rub = IntToString(1, " рублей ") + rub;
            rub = IntToString(4, " тысяч ") + rub;
            rub = IntToString(7, " миллионов ") + rub;
            rub = IntToString(10, " миллиардов ") + rub;
            rub = IntToString(13, " триллионов ") + rub;
            if (rub.Length == 0)
            {
                rub = "ноль рублей ";
            }

            return rub + kopecks;
        }
        void IntToList(string number)
        {
            var number2 = number.Split('.', ',');
            for (int i = 0; i < 20; i++)
            {
                if (i < number2[0].Length)
                {
                    listInt.Insert(0, number2[0][i] - '0');
                }
                else
                {
                    listInt.Add(0);
                }
            }
            if (number2.Length > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i < number2[1].Length)
                    {
                        listIntKopeck.Insert(0, number2[1][i] - '0');
                    }
                    else
                    {
                        listIntKopeck.Add(0);
                    }
                }
            }
            else
            {
                listIntKopeck.Add(0);
                listIntKopeck.Add(0);
            }
        }
        string IntToString(int index, string name)
        {
            string newString = "";
            if (name == " копеек")
            {
                if (listIntKopeck[index] == 1)
                {
                    newString = div12(listIntKopeck[index - 1]) + name + newString;
                }
                else
                {
                    if (listIntKopeck.Count > 0)
                    {
                        if (listIntKopeck[0] == 0 && listIntKopeck[1] == 0)
                        {
                            newString = "ноль копеек" + newString;
                        }
                        else if (listIntKopeck[1] == 0)
                        {
                            newString = div1Kopeck(listIntKopeck[index - 1]) + newString;
                        }
                        else if (listIntKopeck[0] == 0)
                        {
                            newString = div10(listIntKopeck[index]) + name + newString;
                        }
                        else
                        {
                            newString = div1Kopeck(listIntKopeck[index - 1]) + newString;
                            newString = div10(listIntKopeck[index]) + " " + newString;
                        }
                    }
                    else
                    {
                        newString = "ноль копеек" + newString;
                    }
                }
            }
            else
            {
                if (listInt[index] == 1)
                {
                    newString = div12(listInt[index - 1]) + name + newString;
                }
                else
                {
                    if (name == " рублей ")
                    {
                        newString = div1(listInt[index - 1]) + newString;
                    }
                    else if (name == " тысяч ")
                    {
                        newString = div1Thousand(listInt[index - 1]) + newString;
                    }
                    else if (name == " миллионов ")
                    {
                        newString = div1Million(listInt[index - 1]) + newString;
                    }
                    else if (name == " миллиардов ")
                    {
                        newString = div1Billion(listInt[index - 1]) + newString;
                    }
                    else if (name == " триллионов ")
                    {
                        newString = div1Trillion(listInt[index - 1]) + newString;
                    }
                    if (listInt[index] != 0 && listInt[index - 1] == 0)
                    {
                        newString = name + newString;
                    }
                    if (listInt[index] != 0 && listInt[index - 1] != 0)
                    {
                        newString = " " + newString;
                    }
                    newString = div10(listInt[index]) + newString;
                }
                newString = numberOne(index + 2, name) + newString;
            }
            return newString;
        }
        string numberOne(int index, string name)
        {
            string newString = "";
            if (listInt[index - 1] != 0 && listInt[index - 2] == 0 && listInt[index - 3] == 0)
            {
                newString = name + newString;
            }
            if (listInt[index - 1] != 0)
            {
                if (listInt[index - 2] != 0 || listInt[index - 3] != 0)
                {
                    newString = " " + newString;
                }
            }
            newString = div100(listInt[index - 1]) + newString;
            return newString;
        }
        string div10(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "десять";
            }
            else if (number == 2)
            {
                newString = "двадцать";
            }
            else if (number == 3)
            {
                newString = "тридцать";
            }
            else if (number == 4)
            {
                newString = "сорок";
            }
            else if (number == 5)
            {
                newString = "пятьдесят";
            }
            else if (number == 6)
            {
                newString = "шестьдесят";
            }
            else if (number == 7)
            {
                newString = "семдесят";
            }
            else if (number == 8)
            {
                newString = "восемдесят";
            }
            else if (number == 9)
            {
                newString = "девяносто";
            }
            return newString;
        }
        string div12(int number)
        {
            string newString = "";
            if (number == 0)
            {
                newString = "десять";
            }
            else if (number == 1)
            {
                newString = "одинадцать";
            }
            else if (number == 2)
            {
                newString = "двенадцать";
            }
            else if (number == 3)
            {
                newString = "тренадцать";
            }
            else if (number == 4)
            {
                newString = "четырнадцать";
            }
            else if (number == 5)
            {
                newString = "пятнадцать";
            }
            else if (number == 6)
            {
                newString = "шестнадцать";
            }
            else if (number == 7)
            {
                newString = "семнадцать";
            }
            else if (number == 8)
            {
                newString = "восемнадцать";
            }
            else if (number == 9)
            {
                newString = "девятнадцать";
            }
            return newString;
        }
        string div100(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "сто";
            }
            else if (number == 2)
            {
                newString = "двести";
            }
            else if (number == 3)
            {
                newString = "триста";
            }
            else if (number == 4)
            {
                newString = "четыреста";
            }
            else if (number == 5)
            {
                newString = "пятьсот";
            }
            else if (number == 6)
            {
                newString = "шестьсот";
            }
            else if (number == 7)
            {
                newString = "семьсот";
            }
            else if (number == 8)
            {
                newString = "восемьсот";
            }
            else if (number == 9)
            {
                newString = "девятсот";
            }
            return newString;
        }
        string div1Kopeck(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "одна копейка";
            }
            else if (number == 2)
            {
                newString = "две копейки";
            }
            else if (number == 3)
            {
                newString = "три копейки";
            }
            else if (number == 4)
            {
                newString = "четыре копейки";
            }
            else if (number == 5)
            {
                newString = "пять копеек";
            }
            else if (number == 6)
            {
                newString = "шесть копеек";
            }
            else if (number == 7)
            {
                newString = "семь копеек";
            }
            else if (number == 8)
            {
                newString = "восемь копеек";
            }
            else if (number == 9)
            {
                newString = "девять копеек";
            }
            return newString;
        }
        string div1(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "один рубль ";
            }
            else if (number == 2)
            {
                newString = "два рубля ";
            }
            else if (number == 3)
            {
                newString = "три рубля ";
            }
            else if (number == 4)
            {
                newString = "четыре рубля ";
            }
            else if (number == 5)
            {
                newString = "пять рубля ";
            }
            else if (number == 6)
            {
                newString = "шесть рублей ";
            }
            else if (number == 7)
            {
                newString = "семь рублей ";
            }
            else if (number == 8)
            {
                newString = "восемь рублей ";
            }
            else if (number == 9)
            {
                newString = "девять рублей ";
            }
            return newString;
        }
        string div1Thousand(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "одна тысяча";
            }
            else if (number == 2)
            {
                newString = "две тысячи";
            }
            else if (number == 3)
            {
                newString = "три тысячи";
            }
            else if (number == 4)
            {
                newString = "четыре тысячи";
            }
            else if (number == 5)
            {
                newString = "пять тысяч";
            }
            else if (number == 6)
            {
                newString = "шесть тысяч";
            }
            else if (number == 7)
            {
                newString = "семь тысяч";
            }
            else if (number == 8)
            {
                newString = "восемь тысяч";
            }
            else if (number == 9)
            {
                newString = "девять тысяч";
            }
            if (listInt[3] != 0)
            {
                newString += " ";
            }
            return newString;
        }
        string div1Million(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "один миллион";
            }
            else if (number == 2)
            {
                newString = "две миллиона";
            }
            else if (number == 3)
            {
                newString = "три миллиона";
            }
            else if (number == 4)
            {
                newString = "четыре миллиона";
            }
            else if (number == 5)
            {
                newString = "пять миллионов";
            }
            else if (number == 6)
            {
                newString = "шесть миллионов";
            }
            else if (number == 7)
            {
                newString = "семь миллионов";
            }
            else if (number == 8)
            {
                newString = "восемь миллионов";
            }
            else if (number == 9)
            {
                newString = "девять миллионов";
            }
            if (listInt[6] != 0)
            {
                newString += " ";
            }
            return newString;
        }
        string div1Billion(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "один миллиард ";
            }
            else if (number == 2)
            {
                newString = "две миллиарда";
            }
            else if (number == 3)
            {
                newString = "три миллиарда";
            }
            else if (number == 4)
            {
                newString = "четыре миллиарда";
            }
            else if (number == 5)
            {
                newString = "пять миллиардов";
            }
            else if (number == 6)
            {
                newString = "шесть миллиардов";
            }
            else if (number == 7)
            {
                newString = "семь миллиардов";
            }
            else if (number == 8)
            {
                newString = "восемь миллиардов";
            }
            else if (number == 9)
            {
                newString = "девять миллиардов";
            }
            if (listInt[9] != 0)
            {
                newString += " ";
            }
            return newString;
        }
        string div1Trillion(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "один триллион ";
            }
            else if (number == 2)
            {
                newString = "две триллиона";
            }
            else if (number == 3)
            {
                newString = "три триллиона";
            }
            else if (number == 4)
            {
                newString = "четыре триллиона";
            }
            else if (number == 5)
            {
                newString = "пять триллионов";
            }
            else if (number == 6)
            {
                newString = "шесть триллионов";
            }
            else if (number == 7)
            {
                newString = "семь триллионов";
            }
            else if (number == 8)
            {
                newString = "восемь триллионов";
            }
            else if (number == 9)
            {
                newString = "девять триллионов";
            }
            if (listInt[12] != 0)
            {
                newString += " ";
            }
            return newString;
        }
    }
}