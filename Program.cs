namespace Course
{
    internal class MainCourse
    {
        static void Main()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Какую программу запустить? Введите цифру");
            Console.WriteLine("1. Игра в слова");
            Console.WriteLine("2. Разделение на части");
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
    }
}