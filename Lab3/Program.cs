namespace Lab3;

public class Program
{
    private const int Rows = 10;
    private const int Cols = 15;
    private const string FilePath = "matrix.txt";

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Завдання 1 ===");
        RunTask1();

        Console.WriteLine();
        Console.WriteLine("=== Завдання 2 ===");
        Task2Demo.Run();
        Console.WriteLine();
        Console.WriteLine("=== Завдання 3 ===");
        Task3Demo.Run();
        Console.WriteLine();
        Console.WriteLine("=== Завдання 4 ===");
        Task4Demo.Run();
    }
    private static void RunTask1()
    {
        // 1. Генерація: 1 - місце зайняте, 0 - вільне
        int[,] hall = GenerateHall();

        // 2. Запис (using закриє файл автоматично)
        using (var writer = new MatrixWriter(FilePath))
        {
            writer.Write(hall);
        }

        // 3. Зчитування
        int[,] loaded;
        using (var reader = new MatrixReader(FilePath))
        {
            loaded = reader.Read();
        }

        PrintMatrix(loaded);

                List<int> freeRows = FindFreeRows(loaded);

        if (freeRows.Count > 0)
            Console.WriteLine("Повністю вільні ряди: " + string.Join(", ", freeRows));
        else
            Console.WriteLine("Повністю вільних рядів немає.");
    }

    private static int[,] GenerateHall()
    {
        var random = new Random();
        int[,] hall = new int[Rows, Cols];

        for (int i = 0; i < Rows; i++)
        {
            // З імовірністю 30% ряд лишається повністю порожнім,
            // інакше при чистому випадку вільних рядів майже не буває
            bool emptyRow = random.Next(100) < 30;
            if (emptyRow) continue;

            for (int j = 0; j < Cols; j++)
            {
                hall[i, j] = random.Next(0, 2); // 0 або 1
            }
        }
        return hall;
    }

        // Повертає номери (з 1) рядів, де всі місця вільні
    private static List<int> FindFreeRows(int[,] hall)
    {
        var freeRows = new List<int>();

        for (int i = 0; i < hall.GetLength(0); i++)
        {
            bool isFree = true;
            for (int j = 0; j < hall.GetLength(1); j++)
            {
                if (hall[i, j] == 1)
                {
                    isFree = false;
                    break;
                }
            }
            if (isFree) freeRows.Add(i + 1);
        }
        return freeRows;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    
}