namespace Course
{
    public class Sinus
    {
        public int Length = 4;
        public List<double> doublesList = new List<double>();
        public void Start()
        {
            Console.WriteLine($"Длинна - {Length}");
            Сalculation();
            foreach (var item in doublesList)
            {
                Console.WriteLine(item);
            }
        }
        public void Сalculation()
        {
            if (Length < 5)
            {
                throw new MustBeLessThanFive("Нельзя меньше пяти");
            }
            if (Length % 2 == 0)
            {
                throw new NoEvenNumbers("Нельзя чётные");
            }
            float segment = (float)1 / (Length / 2);
            doublesList.Add(0);
            for (int i = 1; i < Length / 2; i++)
            {
                float value1 = segment * i;
                double value2 = Math.PI * value1;
                doublesList.Add(Math.Sin(value2));
            }
            doublesList.Add(0);
            for (int i = Length / 2 - 1; i > 0; i--)
            {
                float value1 = segment * i;
                double value2 = Math.PI * value1;
                doublesList.Add(-Math.Sin(value2));
            }
            doublesList.Add(0);
        }
    }
    public class NoEvenNumbers : Exception
    {
        public NoEvenNumbers(string text)
        {
        }
    }
    public class MustBeLessThanFive : Exception
    {
        public MustBeLessThanFive(string text)
        {
        }
    }
    
}
