namespace Lab3;

public class Program
{
    private const int Rows = 10;
    private const int Cols = 15;
    private const string FilePath = "matrix.txt";

    public static void Main(string[] args)
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