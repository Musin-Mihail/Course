
namespace Course
{
    public class ConvertInt
    {
        public void StartGame()
        {
            string result = Convert(60050);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public string Convert(int number)
        {
            string numberString = number.ToString();
            string newString = "";

            if (numberString.Length == 1)
            {
                newString += number1(numberString[0]);
            }

            else if (numberString.Length == 2)
            {
                newString += OneOrNot(numberString, 0);
            }

            else if (numberString.Length == 3)
            {
                newString += number3(numberString[0]);
                newString += OneOrNot(numberString, 1);
            }

            else if (numberString.Length == 4)
            {
                newString += number4(numberString[0]);
                newString += number3(numberString[1]);
                newString += OneOrNot(numberString, 2);
            }

            else if (numberString.Length == 5)
            {
                newString += OneOrNot(numberString, 0);
                newString += number3(numberString[2]);
                newString += OneOrNot(numberString, 3);
            }
            return newString;

        }
        string OneOrNot(string numberString, int index)
        {
            string newString = "";
            if (numberString[index] == '1')
            {
                newString += number2One(numberString[index + 1]);
                if (numberString.Length == 5 && index == 0)
                {
                    newString += " тысяч ";
                }
            }
            else
            {
                newString += number2(numberString[index]);
                if (numberString.Length == 5 && index == 0)
                {
                    newString += number1Thousand(numberString[index + 1]);
                }
                else
                {
                    newString += number1(numberString[index + 1]);
                }
            }
            return newString;
        }

        string number1(char number)
        {
            string newString = "";
            if (number == '1')
            {
                newString = "один";
            }
            else if (number == '2')
            {
                newString = "два";
            }
            else if (number == '3')
            {
                newString = "три";
            }
            else if (number == '4')
            {
                newString = "четыре";
            }
            else if (number == '5')
            {
                newString = "пять";
            }
            else if (number == '6')
            {
                newString = "шесть";
            }
            else if (number == '7')
            {
                newString = "семь";
            }
            else if (number == '8')
            {
                newString = "восемь";
            }
            else if (number == '9')
            {
                newString = "девять";
            }
            return newString;
        }
        string number1Thousand(char number)
        {
            string newString = "";
            if (number == '0')
            {
                newString = " тысяч ";
            }
            if (number == '1')
            {
                newString = "одна тысяча ";
            }
            else if (number == '2')
            {
                newString = "две тысячи ";
            }
            else if (number == '3')
            {
                newString = "три тысячи ";
            }
            else if (number == '4')
            {
                newString = "четыре тысячи ";
            }
            else if (number == '5')
            {
                newString = "пять тысяч ";
            }
            else if (number == '6')
            {
                newString = "шесть тысяч ";
            }
            else if (number == '7')
            {
                newString = "семь тысяч ";
            }
            else if (number == '8')
            {
                newString = "восемь тысяч ";
            }
            else if (number == '9')
            {
                newString = "девять тысяч ";
            }
            return newString;
        }
        string number2One(char number)
        {
            string newString = "";
            if (number == '0')
            {
                newString = "десять";
            }
            else if (number == '1')
            {
                newString = "одинадцать";
            }
            else if (number == '2')
            {
                newString = "двенадцать";
            }
            else if (number == '3')
            {
                newString = "тренадцать";
            }
            else if (number == '4')
            {
                newString = "четырнадцать";
            }
            else if (number == '5')
            {
                newString = "пятнадцать";
            }
            else if (number == '6')
            {
                newString = "шестьдесят";
            }
            else if (number == '7')
            {
                newString = "семьнадцать";
            }
            else if (number == '8')
            {
                newString = "восемьнадцать";
            }
            else if (number == '9')
            {
                newString = "девятнадцать";
            }

            return newString;
        }
        string number2(char number)
        {
            string newString = "";

            if (number == '1')
            {
                newString = "одинадцать";
            }
            else if (number == '2')
            {
                newString = "двадцать";
            }
            else if (number == '3')
            {
                newString = "тридцать";
            }
            else if (number == '4')
            {
                newString = "сорок";
            }
            else if (number == '5')
            {
                newString = "пятьдесят";
            }
            else if (number == '6')
            {
                newString = "шестьдесят";
            }
            else if (number == '7')
            {
                newString = "семдесять";
            }
            else if (number == '8')
            {
                newString = "восемдесят";
            }
            else if (number == '9')
            {
                newString = "девяносто";
            }

            return newString;
        }
        string number3(char number)
        {
            string newString = "";
            if (number == '1')
            {
                newString = "сто";
            }
            else if (number == '2')
            {
                newString = "двести";
            }
            else if (number == '3')
            {
                newString = "триста";
            }
            else if (number == '4')
            {
                newString = "четыреста";
            }
            else if (number == '5')
            {
                newString = "пятьсот";
            }
            else if (number == '6')
            {
                newString = "шестьсот";
            }
            else if (number == '7')
            {
                newString = "семьсот";
            }
            else if (number == '8')
            {
                newString = "восемьсот";
            }
            else if (number == '9')
            {
                newString = "девятсот";
            }

            return newString;
        }
        string number4(char number)
        {
            string newString = "";
            if (number == '1')
            {
                newString = "одна тысяча ";
            }
            else if (number == '2')
            {
                newString = "две тысячи ";
            }
            else if (number == '3')
            {
                newString = "три тысячи ";
            }
            else if (number == '4')
            {
                newString = "четыре тысячи ";
            }
            else if (number == '5')
            {
                newString = "пять тысяч ";
            }
            else if (number == '6')
            {
                newString = "шесть тысяч ";
            }
            else if (number == '7')
            {
                newString = "семь тысяч ";
            }
            else if (number == '8')
            {
                newString = "восемь тысяч ";
            }
            else if (number == '9')
            {
                newString = "девять тысяч ";
            }

            return newString;
        }
    }
}
