namespace Course
{
    internal class Words
    {
        string[] array = File.ReadAllLines("dict.txt");
        List<string> listWordsString = new List<string>();
        List<string> usedWords = new List<string>();
        bool startGame = false;
        bool stopGame = false;
        int errorCount = 3;
        string CurrentWord = "";
        Char endCurrentchar = ' ';

        public void StartGame()
        {
            listWordsString = array.ToList();
            FirstMove();
            Game();
            Console.WriteLine("Конец игры");
        }
        void FirstMove()
        {
            Console.Clear();
            Console.WriteLine("Введите первое слов и нажмите Enter");
            string word = Console.ReadLine();
            if (WordCheck(word) == true)
            {
                startGame = true;
            }
            else
            {
                FirstMove();
            }
        }
        void Game()
        {
            while (stopGame == false)
            {
                ComputerMove();
                PlayerTurn();
            }
        }
        void ComputerMove()
        {
            ListShuffling();
            SearchWord();
        }
        void ListShuffling()
        {
            Random rnd = new Random();
            for (int i = 0; i < listWordsString.Count; i++)
            {
                string temp = listWordsString[i];
                int randomIndex = rnd.Next(0, listWordsString.Count - 1);
                listWordsString[i] = listWordsString[randomIndex];
                listWordsString[randomIndex] = temp;
            }
        }
        void SearchWord()
        {
            foreach (string word in listWordsString)
            {
                if (usedWords.Contains(word) == false)
                {
                    if (word[0] == endCurrentchar)
                    {
                        SetCurrentWord(word);
                        return;
                    }
                }
            }
        }
        void PlayerTurn()
        {
            Console.WriteLine("Компьютер выбрал слово - \"" + CurrentWord + "\"");
            Console.WriteLine("Ход игрока. Введите слово начинающиеся на букву \"" + endCurrentchar + "\" и нажмите Enter");
            string word = Console.ReadLine();
            if (WordCheck(word) == false && stopGame == false)
            {
                PlayerTurn();
            }
        }
        bool WordCheck(string word)
        {
            Console.Clear();
            if (word.Length > 1)
            {
                string SaveWord = word;
                word = word.ToUpper();
                word = word.Replace('Ё', 'Е');
                if (listWordsString.Contains(word) == true)
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
                            SetCurrentWord(word);
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
                        SetCurrentWord(word);
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
        void SetCurrentWord(string word)
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
