namespace Course
{
    public class MainCourse
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Какую программу запустить? Введите цифру");
            Console.WriteLine("1. Игра в слова");
            Console.WriteLine("2. Разделение на части");
            Console.WriteLine("3. Посчитать слова");
            Console.WriteLine("");
            Console.WriteLine("9. Тестовая область");

            string word = Console.ReadLine();
            if (word.Length == 1)
            {
                Char firstChar = word[0];
                if (firstChar == '1')
                {
                    StartGameWords();
                }
                else if (firstChar == '2')
                {
                    CuttingPlywood();
                }
                else if (firstChar == '3')
                {
                    CountWords();
                }
                else if (firstChar == '9')
                {
                    Testing();
                }
            }
            Main();
        }
        static void StartGameWords()
        {
            Words wordsGame = new Words();
            wordsGame.StartGame();
        }
        static void CuttingPlywood()
        {
            Plywood plywood = new Plywood();
            plywood.StartGame();
        }
        static void CountWords()
        {
            CountWords countWords = new CountWords();
            countWords.StartGame();
        }
        static void Testing()
        {
            TEST test = new TEST();
            test.StartGame();
        }
    }
}