namespace Course
{
    internal class CountWords
    {
        public void StartGame()
        {
            string path = "text.txt";
            List<string> stringList = new List<string>(GetText(path).Split(' '));
            List<word> words = SaveWords(stringList);

            int totalWords = 0;
            foreach (var item in words)
            {
                totalWords += item.count;
            }
            Console.WriteLine("\nВсего слов - " + totalWords + "\n");

            foreach (var item in words)
            {
                Console.WriteLine(item.name + " - " + (float)item.count / totalWords);
            }
            Console.ReadKey();
        }
        string GetText(string path)
        {
            Console.Clear();
            string text = File.ReadAllText(path);

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
            }
            Console.WriteLine("");

            text = text.Replace('\n', ' ');
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    if (Char.IsLetter(text[i]) == false)
                    {
                        text = text.Remove(i, 1);
                        i--;
                    }
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
            }
            return text;
        }
        List<word> SaveWords(List<string> stringList)
        {
            List<word> words = new List<word>();
            foreach (string str in stringList)
            {
                if (str.Length > 1)
                {
                    bool math = false;
                    foreach (var item in words)
                    {
                        if (item.match(str) == true)
                        {
                            math = true;
                            break;
                        }
                    }
                    if (math == false)
                    {
                        word word = new word();
                        word.name = str;
                        words.Add(word);
                    }
                }
            }
            return words;
        }
    }
    class word
    {
        public string name = "";
        public int count = 1;
        public bool match(string name)
        {
            if (this.name == name)
            {
                count++;
                return true;
            }
            return false;
        }
    }
}
