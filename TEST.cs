namespace Course
{
    internal class TEST
    {
        List<Person> listPerson = new List<Person>();
        public void StartGame()
        {
            Add();
            Write();
            Console.ReadKey();  
        }
        public void Add()
        {
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.name = "Имя";
                listPerson.Add(person);
            }
        }
        public void Write()
        {
            foreach (var item in listPerson)
            {
                Console.WriteLine(item.name);
            }
        }
        class Person
        {
            public string name = "";
        }
    }
}