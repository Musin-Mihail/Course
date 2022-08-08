using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Calculator
    {
        public float Plus(float x, float y)
        {
            return x + y;
        }
        public float Minus(float x, float y)
        {
            return x - y;
        }
        public float Multiply(float x, float y)
        {
            return x * y;
        }
        public float Divide(float x, float y)
        {
            return x / y;
        }
        public List<float> MultiplyArray(List<int> listInt)
        {
            List<float> newListFloat = new List<float>();
            foreach (int number in listInt)
            {
                if (number % 2 == 0)
                {
                    newListFloat.Add(Multiply(number, 2));
                }
                else
                {
                    newListFloat.Add(Multiply(number, 3));
                }
            }
            foreach (var item in newListFloat)
            {
                Console.WriteLine(item);
            }
            return newListFloat;
        }
    }
}
