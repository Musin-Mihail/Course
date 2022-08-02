namespace Course
{
    public class CountingEvenNumbers
    {
        public List<int> GetListInt(string text)
        {
            List<int> listInt = new List<int>();
            List<string> numbers = new List<string>(text.Split(';'));
            
            foreach (var item in numbers)
            {
                int number = Int32.Parse(item);
                if (number != 0 && number % 2 == 0)
                {
                    listInt.Add(number);
                }
            }
            return listInt;
        }
        public int GetSumm(List<int> listInt)
        {
            int summ = 0;
            foreach (var item in listInt)
            {
                summ += item;
            }
            return summ;
        }
    }
}