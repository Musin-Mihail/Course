using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    internal class Ruble
    {
        public void Start()
        {
            Console.Clear();
            RubleClass ruble1 = new RubleClass(9, 18);
            RubleClass ruble2 = new RubleClass(9, 18);
            Console.WriteLine("9 рублей 18 копеек и 9 рублей 18 копеек");
            Console.WriteLine("Сложение  - " + (ruble1 + ruble2));
            Console.WriteLine("Вычетание - " + (ruble1 - ruble2));
            Console.WriteLine("Умножение - " + (ruble1 * ruble2));
            Console.WriteLine("Деление   - " + (ruble1 / ruble2));
            Console.WriteLine("Равны?    - " + (ruble1 == ruble2));
            Console.WriteLine("Не равны? - " + (ruble1 != ruble2));
            ruble1 = new RubleClass(9, 18);
            ruble2 = new RubleClass(-19, 18);
            Console.WriteLine("------------------------");
            Console.WriteLine("9 рублей 18 копеек и -19 рублей 18 копеек");
            Console.WriteLine("Сложение  - " + (ruble1 + ruble2));
            Console.WriteLine("Вычетание - " + (ruble1 - ruble2));
            Console.WriteLine("Умножение - " + (ruble1 * ruble2));
            Console.WriteLine("Деление   - " + (ruble1 / ruble2));
            Console.WriteLine("Равны?    - " + (ruble1 == ruble2));
            Console.WriteLine("Не равны? - " + (ruble1 != ruble2));
            ruble1 = new RubleClass(9, 18);
            ruble2 = new RubleClass(0, 0);
            Console.WriteLine("------------------------");
            Console.WriteLine("9 рублей 18 копеек и 0 рублей 0 копеек");
            Console.WriteLine("Сложение  - " + (ruble1 + ruble2));
            Console.WriteLine("Вычетание - " + (ruble1 - ruble2));
            Console.WriteLine("Умножение - " + (ruble1 * ruble2));
            Console.WriteLine("Деление   - " + (ruble1 / ruble2));
            Console.WriteLine("Равны?    - " + (ruble1 == ruble2));
            Console.WriteLine("Не равны? - " + (ruble1 != ruble2));
            Console.ReadLine();
        }
    }
    class RubleClass
    {
        public static string operator +(RubleClass a, RubleClass b)
        {
            float number = summ(a.numberRubles, a.numberKopecks) + summ(b.numberRubles, b.numberKopecks);
            ConvertInt convertInt = new ConvertInt();
            convertInt.number = number.ToString();
            return number + " : " + convertInt.Convert();
        }
        public static string operator -(RubleClass a, RubleClass b)
        {
            float number = summ(a.numberRubles, a.numberKopecks) - summ(b.numberRubles, b.numberKopecks);
            ConvertInt convertInt = new ConvertInt();
            convertInt.number = number.ToString();
            return number + " : " + convertInt.Convert();
        }
        public static string operator *(RubleClass a, RubleClass b)
        {
            float number = summ(a.numberRubles, a.numberKopecks) * summ(b.numberRubles, b.numberKopecks);
            ConvertInt convertInt = new ConvertInt();
            convertInt.number = number.ToString();
            return number + " : " + convertInt.Convert();
        }
        public static string operator /(RubleClass a, RubleClass b)
        {
            float num1 = summ(a.numberRubles, a.numberKopecks);
            float num2 = summ(b.numberRubles, b.numberKopecks);
            if (num2 == 0)
            {
                return "Делить на 0 нельзя";
            }
            else
            {
                float number = num1 / num2;
                ConvertInt convertInt = new ConvertInt();
                convertInt.number = number.ToString();
                return number + " : " + convertInt.Convert();
            }
        }
        public static bool operator ==(RubleClass a, RubleClass b)
        {
            if (a.numberRubles == b.numberRubles && a.numberKopecks == b.numberKopecks)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(RubleClass a, RubleClass b)
        {
            if (a.numberRubles != b.numberRubles || a.numberKopecks != b.numberKopecks)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static float summ(float num1, float num2)
        {
            if (num1 < 0)
            {
                return num1 - num2 / 100;
            }
            else
            {

                return num1 + num2 / 100;
            }
        }
        public float numberRubles { get; set; }
        public float numberKopecks { get; set; }
        public RubleClass(float numberRubles, float numberKopecks)
        {
            this.numberRubles = numberRubles;
            this.numberKopecks = numberKopecks;
        }
    }
}