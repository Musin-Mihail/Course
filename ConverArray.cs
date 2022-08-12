using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class ConverArray
    {
        public List<int> listInt = new List<int>();
        public int countMinus = 0;
        public int countPlus = 0;
        public void start()
        {
            Console.Clear();
            CreateRandomArray();
            ChangeArray();
            TransitionCounting();
            Console.ReadLine();
        }
        public void CreateRandomArray()
        {
            Random random = new Random();
            while (listInt.Count < 100)
            {
                int number = random.Next(-101, 101);
                if (number == 0)
                {
                    continue;
                }
                else
                {
                    listInt.Add(number);
                }
            }
            foreach (var item in listInt)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
            
        }
        public void ChangeArray()
        {
            List<int> newListInt = new List<int>();
            foreach (var item in listInt)
            {
                if(item<0)
                {
                    newListInt.Add(-1);
                }
                else
                {
                    newListInt.Add(1);
                }
            }
            listInt = new List<int>(newListInt);
            foreach (var item in listInt)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }
        public void TransitionCounting()
        {
            for (int i = 0; i < listInt.Count-1; i++)
            {
                if (listInt[i] == -1 && listInt[i+1] == 1)
                {
                    countMinus++;
                }
                else if(listInt[i] == 1 && listInt[i + 1] == -1)
                {
                    countPlus++;
                }
            }
            Console.WriteLine(countMinus + " - " + countPlus);
        }
    }
}
