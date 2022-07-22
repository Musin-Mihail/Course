
namespace Course
{
    public class ConvertInt
    {
        List<int> listInt = new List<int>();
        public long number = 12345678912;
        public void StartGame()
        {
            string result = Convert();
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public string Convert()
        {
            IntToList(number);
            string newString = "";
            newString = number1_2(1) + newString;
            newString = number3(3) + newString;
            newString = numberTwo(4, " тысяч ") + newString;
            newString = numberOne(6, " тысяч ") + newString;
            newString = numberTwo(7, " миллионов ") + newString;
            newString = numberOne(9, " миллионов ") + newString;
            newString = numberTwo(10, " триллионов ") + newString;
            newString = numberOne(12, " триллионов ") + newString;
            return newString;
        }
        void IntToList(long number)
        {
            string numberString = number.ToString();

            for (int i = 0; i < 20; i++)
            {
                if (i < numberString.Length)
                {
                    listInt.Insert(0, numberString[i] - '0');
                }
                else
                {
                    listInt.Add(0);
                }
            }
        }
        string number1_2(int index)
        {
            string newString = "";
            if (listInt[index] == 1)
            {
                newString = div12(listInt[index - 1]) + newString;
            }
            else
            {
                newString = div1(listInt[index - 1]) + newString;
                if (listInt[index] != 0 && listInt[index - 1] != 0)
                {
                    newString = " " + newString;
                }
                newString = div10(listInt[index]) + newString;
            }
            return newString;
        }
        string number3(int index)
        {
            string newString = "";
            newString += div100(listInt[index - 1]);
            if (listInt[index - 1] != 0)
            {
                newString += " ";
            }
            return newString;
        }
        string numberTwo(int index, string name)
        {
            string newString = "";
            if (listInt[index] == 1)
            {
                newString = div12(listInt[index - 1]) + name + newString;
            }
            else
            {
                if (name == " тысяч ")
                {
                    newString = div1Thousand(listInt[index - 1]) + newString;
                }
                else if (name == " миллионов ")
                {
                    newString = div1Million(listInt[index - 1]) + newString;
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
            return newString;
        }
        string numberOne(int index, string name)
        {
            string newString = "";
            if (listInt[index - 1] != 0 && listInt[index - 2] == 0 && listInt[index - 3] == 0)
            {
                newString = name + newString;
            }
            if (listInt[index - 1] != 0 && listInt[index - 2] != 0)
            {
                newString = " " + newString;
            }
            newString = div100(listInt[index - 1]) + newString;
            return newString;
        }
        string div1(int number)
        {
            string newString = "";
            if (number == 1)
            {
                newString = "один";
            }
            else if (number == 2)
            {
                newString = "два";
            }
            else if (number == 3)
            {
                newString = "три";
            }
            else if (number == 4)
            {
                newString = "четыре";
            }
            else if (number == 5)
            {
                newString = "пять";
            }
            else if (number == 6)
            {
                newString = "шесть";
            }
            else if (number == 7)
            {
                newString = "семь";
            }
            else if (number == 8)
            {
                newString = "восемь";
            }
            else if (number == 9)
            {
                newString = "девять";
            }

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
                newString = "семдесять";
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
                newString = "одна миллион";
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
    }
}
