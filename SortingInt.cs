namespace Course
{
    public class SortingInt
    {
        public List<int> Sorting(List<int> listInt)
        {
            //listInt.Sort();
            //listInt = listInt.OrderBy(x => x).ToList();
            for (int i = 0; i < listInt.Count - 1; i++)
            {
                for (int y = 0; y < listInt.Count - 1; y++)
                {
                    if (listInt[i] < listInt[y])
                    {
                        int tempInt = listInt[i];
                        listInt[i] = listInt[y];
                        listInt[y] = tempInt;
                    }
                }
            }
            return listInt;
        }
    }
}
