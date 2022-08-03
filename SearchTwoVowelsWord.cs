using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class SearchTwoVowelsWord
    {
        List<char> chars = new List<char>() { 'ц', 'к', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ф', 'в', 'п', 'р', 'л', 'д', 'ж', 'ч', 'с', 'м', 'т', 'б' };
        List<WordClass> words = new List<WordClass>();
        Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();

        public Dictionary<string, List<int>> Start(string text)
        {
            result.Clear();
            ParseText(text);
            SearchTwoVowels();
            foreach (var item in result)
            {
                Console.Write(item.Key + " - ");
                foreach (var item2 in item.Value)
                {
                    Console.Write(item2 + ", ");
                }
                Console.Write("\n");
            }
            return result;
        }
        public void ParseText(string text)
        {
            string word = "";
            int startPlace = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] != ' ')
                {
                    word = word + text[i];
                }
                else if (word.Length > 1)
                {
                    WordClass wordClass = new WordClass();
                    wordClass.word = word;
                    wordClass.place = startPlace;
                    words.Add(wordClass);
                    word = "";
                    startPlace = i + 1;
                }
                else
                {
                    word = "";
                    startPlace = i + 1;
                }
            }
            if (text[text.Length - 1] != ' ')
            {
                WordClass wordClass = new WordClass();
                wordClass.word = word;
                wordClass.place = startPlace;
                words.Add(wordClass);
            }
        }
        void SearchTwoVowels()
        {
            foreach (WordClass word in words)
            {
                bool vowels = false;
                foreach (char char1 in word.word)
                {
                    if (vowels == false && SearchVowels(char1) == true)
                    {
                        vowels = true;
                    }
                    else if (vowels == true && SearchVowels(char1) == true)
                    {
                        MatchDictionary(word);
                        break;
                    }
                    else
                    {
                        vowels = false;
                    }
                }
            }
        }
        bool SearchVowels(char char1)
        {
            foreach (char char2 in chars)
            {
                if (char1 == char2)
                {
                    return true;
                }
            }
            return false;
        }
        void MatchDictionary(WordClass word)
        {
            if (result.ContainsKey(word.word) == true)
            {
                result[word.word].Add(word.place);
            }
            else
            {
                result.Add(word.word, new List<int>() { word.place });
            }
        }
        class WordClass
        {
            public string word { get; set; }
            public int place { get; set; }
        }
    }
}
