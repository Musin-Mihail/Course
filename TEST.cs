namespace Course
{
    // Помощь ученика
    internal class TEST
    {
        public void StartGame()
        {
            Console.Clear();
            string text = "привет пока привет привет пока ";
            string[] words = GetStringList(text);
            if (words.Length > 0)
            {
                Console.WriteLine("Общее количество слов :" + words.Length);
            }
            CountWords(words);
            Console.ReadLine();
        }

        public string[] GetStringList(string text2)
        {
            string[] words = text2.Split(new char[] { '-', '.', '?', '!', ')', '(', ',', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        public int CountWords(string[] words)
        {
            var result = words.GroupBy(x => x).Select(x => new { Word = x.Key, Repeating = x.Count() });
            List<TestClass> newList = new List<TestClass>();
            foreach (var item in result)
            {
                TestClass testClass = new TestClass();
                testClass.str = item.Word;
                testClass.i = item.Repeating;
                newList.Add(testClass);
                Console.WriteLine("Слово: {0}\tКоличество повторов: {1}", item.Word, item.Repeating);
            }
            return newList.Count;
        }

        public class TestClass
        {
            public string str;
            public int i;
        }
    }
}