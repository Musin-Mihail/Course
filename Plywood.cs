namespace Course
{
    internal class Plywood
    {
        int width = 0;
        int height = 0;
        List<Cell> cells = new List<Cell>();
        List<Part> parts = new List<Part>();
        bool error = false;
        int color = 1;
        public void StartGame()
        {
            try
            {
                if (error == false)
                {
                    Console.Clear();
                }
                Console.WriteLine("Введите высоту");
                string text = Console.ReadLine();
                width = int.Parse(text);
                Console.WriteLine("Введите ширину");
                text = Console.ReadLine();
                height = int.Parse(text);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Водите только цифры");
                error = true;
                StartGame();
            }
            Console.Clear();
            Console.WriteLine("Ширина - {0}. Высота - {1}", height, width);

            CreateCells();
            CreateAllPart();
            InstallationParts();
            WriteCells();
            Console.ReadLine();
        }
        void SortingParts()
        {
            parts = parts.OrderBy(sel => sel.count).ToList();
        }
        void CreateCells()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell cell = new Cell();
                    cell.x = x;
                    cell.y = y;

                    cells.Add(cell);
                }
            }
        }
        void InstallationParts()
        {
            foreach (Cell cell in cells)
            {
                if (cell.busy == false)
                {
                    foreach (Part part in parts)
                    {
                        int partWidth = part.width;
                        int partHeight = part.height;
                        for (int i = 0; i < 2; i++)
                        {
                            if (width - cell.x >= partWidth)
                            {
                                if (height - cell.y >= partHeight)
                                {
                                    if (SearchFreeSpace(cell.x, cell.y, partWidth, partHeight) == true)
                                    {
                                        InsertPart(cell.x, cell.y, partWidth, partHeight);
                                        part.count++;
                                        SortingParts();
                                        break;
                                    }
                                }
                            }
                            partWidth = part.height;
                            partHeight = part.width;
                        }
                    }
                }
            }
        }
        bool SearchFreeSpace(int X, int Y, int partWidth, int partHeight)
        {
            for (int x = X; x < partWidth + X; x++)
            {
                for (int y = Y; y < partHeight + Y; y++)
                {
                    foreach (Cell cell in cells)
                    {
                        if (cell.x == x && cell.y == y && cell.busy == true)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool SearchFreeSpaceRotary(int X, int Y, int partWidth, int partHeight)
        {
            for (int x = X; x < partHeight + X; x++)
            {
                for (int y = Y; y < partWidth + Y; y++)
                {
                    foreach (Cell cell in cells)
                    {
                        if (cell.x == x && cell.y == y && cell.busy == true)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        void InsertPart(int X, int Y, int partWidth, int partHeight)
        {
            color++;
            if (color > 14)
            {
                color = 1;
            }
            for (int x = X; x < partWidth + X; x++)
            {
                for (int y = Y; y < partHeight + Y; y++)
                {
                    foreach (Cell cell in cells)
                    {
                        if (cell.x == x && cell.y == y)
                        {
                            cell.color = color;
                            cell.busy = true;
                        }
                    }
                }
            }
        }
        void CreateAllPart()
        {
            Part part = new Part();
            part.width = 7;
            part.height = 3;
            parts.Add(part);
            part = new Part();
            part.width = 11;
            part.height = 11;
            parts.Add(part);
            part = new Part();
            part.width = 5;
            part.height = 13;
            parts.Add(part);
        }
        void WriteCells()
        {
            int count = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    foreach (Cell cell in cells)
                    {
                        if (cell.x == x && cell.y == y)
                        {
                            if (cell.busy == false)
                            {
                                count++;
                            }
                            Console.BackgroundColor = (System.ConsoleColor)cell.color;
                            Console.Write("  ");
                        }
                    }
                }
                Console.Write("\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Всего ячеек - {0}", cells.Count);
            foreach (Part part in parts)
            {
                Console.WriteLine("Ширина - {0}, Высота - {1}, Количество - {2}", part.width, part.height, part.count);
            }
            Console.WriteLine("Свободно ячеек - {0}", count);
        }
    }
    class Cell
    {
        public bool busy = false;
        public int x = 0;
        public int y = 0;
        public int color = 15;
    }
    class Part
    {
        public int width = 0;
        public int height = 0;
        public int count = 0;
    }
}