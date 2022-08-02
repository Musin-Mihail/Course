namespace Course
{
    public class ReplaceCharClass
    {
        public string Start(string text)
        {
            text = text.Replace('а', 'a');
            text = text.Replace('у', 'y');
            text = text.Replace('е', 'e');
            text = text.Replace('х', 'x');
            text = text.Replace('а', 'a');
            text = text.Replace('р', 'p');
            text = text.Replace('о', 'o');
            text = text.Replace('с', 'c');
            return text;
        }
    }
}