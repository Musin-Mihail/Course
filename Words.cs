namespace Course
{
    public class Words
    {
        bool stopGame = false;
        int errorCount = 3;
        string CurrentWord = "";
        public void StartGame()
        {
            string[] array = File.ReadAllLines("dict.txt");
            List<string> dictionary = array.ToList();
            List<string> usedWords = new List<string>();
            bool startGame = false;
            Char endCurrentchar = ' ';
            FirstMove(usedWords, dictionary, ref startGame, ref endCurrentchar);
            Game(ref usedWords, ref dictionary, startGame, ref endCurrentchar);
            Console.WriteLine("Конец игры");
        }
        void FirstMove(List<string> usedWords, List<string> dictionary, ref bool startGame, ref Char endCurrentchar)
        {
            Console.Clear();
            Console.WriteLine("Введите первое слов и нажмите Enter");
            string word = Console.ReadLine();

            if (WordCheck(ref usedWords, dictionary, word, startGame, ref endCurrentchar) == true)
            {
                startGame = true;
            }
            else
            {
                FirstMove(usedWords, dictionary, ref startGame, ref endCurrentchar);
            }
        }
        void Game(ref List<string> usedWords, ref List<string> dictionary, bool startGame, ref Char endCurrentchar)
        {
            while (stopGame == false)
            {
                ComputerMove(ref usedWords, ref dictionary, ref endCurrentchar);
                PlayerTurn(ref usedWords, dictionary, startGame, ref endCurrentchar);
            }
        }
        void ComputerMove(ref List<string> usedWords, ref List<string> dictionary, ref Char endCurrentchar)
        {
            ListShuffling(ref dictionary);
            SearchWord(ref usedWords, dictionary, ref endCurrentchar);
        }
        void ListShuffling(ref List<string> dictionary)
        {
            Random rnd = new Random();
            for (int i = 0; i < dictionary.Count; i++)
            {
                string temp = dictionary[i];
                int randomIndex = rnd.Next(0, dictionary.Count - 1);
                dictionary[i] = dictionary[randomIndex];
                dictionary[randomIndex] = temp;
            }
        }
        void SearchWord(ref List<string> usedWords, List<string> dictionary, ref Char endCurrentchar)
        {
            foreach (string word in dictionary)
            {
                if (usedWords.Contains(word) == false)
                {
                    if (word[0] == endCurrentchar)
                    {
                        SetCurrentWord(ref usedWords, word, ref endCurrentchar);
                        return;
                    }
                }
            }
        }
        void PlayerTurn(ref List<string> usedWords, List<string> dictionary, bool startGame, ref Char endCurrentchar)
        {
            Console.WriteLine("Компьютер выбрал слово - \"" + CurrentWord + "\"");
            Console.WriteLine("Ход игрока. Введите слово начинающиеся на букву \"" + endCurrentchar + "\" и нажмите Enter");
            string word = Console.ReadLine();
            if (WordCheck(ref usedWords, dictionary, word, startGame, ref endCurrentchar) == false && stopGame == false)
            {
                PlayerTurn(ref usedWords, dictionary, startGame, ref endCurrentchar);
            }
        }
        public bool WordCheck(ref List<string> usedWords, List<string> dictionary, string word, bool startGame, ref Char endCurrentchar)
        {
            //Console.Clear();
            if (!Console.IsOutputRedirected) Console.Clear();
            if (word.Length > 1)
            {
                string SaveWord = word;
                word = word.ToUpper();
                word = word.Replace('Ё', 'Е');
                if (dictionary.Contains(word) == true)
                {
                    if (startGame == true)
                    {
                        if (word[0] == endCurrentchar)
                        {
                            if (usedWords.Contains(word) == true)
                            {
                                Console.WriteLine("Это слово уже было");
                                Error();
                                return false;
                            }
                            SetCurrentWord(ref usedWords, word, ref endCurrentchar);
                            Console.WriteLine("Ваше слово - \"" + SaveWord + "\"");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Первая буква вашего слова отличается от последней буквы предыдущего слова");
                            Error();
                            return false;
                    }
                }
                    else
                    {
                        Console.WriteLine("Ваше слово - \"" + SaveWord + "\"");
                        SetCurrentWord(ref usedWords, word, ref endCurrentchar);
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Слово - \"" + SaveWord + "\" нет в словаре");
                    if (startGame == true)
                    {
                        Error();
                    }
                    return false;
                }
            }
            Console.WriteLine("Введите слово состоящие минимум из двух букв.");
            return false;
        }
        void SetCurrentWord(ref List<string> usedWords, string word, ref Char endCurrentchar)
        {
            word = word.ToUpper();
            CurrentWord = word;
            Char endChar = word[word.Length - 1];
            if (endChar == 'Ь' || endChar == 'Ъ' || endChar == 'Ы')
            {
                endCurrentchar = word[word.Length - 2];
            }
            else
            {
                endCurrentchar = word[word.Length - 1];
            }
            usedWords.Add(word);
        }
        void Error()
        {
            errorCount--;
            if (errorCount < 0)
            {
                stopGame = true;
                return;
            }
            if (errorCount == 2)
            {
                Console.WriteLine("Осталось 2 попытки.");
            }
            else if (errorCount == 1)
            {
                Console.WriteLine("Осталась 1 попытка.");
            }
            else if (errorCount == 0)
            {
                Console.WriteLine("Осталось 0 попыток.");
            }
        }
    }
}