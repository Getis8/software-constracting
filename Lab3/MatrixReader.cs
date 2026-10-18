namespace Lab3;

// Зчитує файл порядково й відновлює матрицю
public class MatrixReader : IDisposable
{
    private readonly StreamReader _reader;
    private bool _disposed;

    public MatrixReader(string path)
    {
        _reader = new StreamReader(path);
    }

    public int[,] Read()
    {
        var rows = new List<int[]>();
        string? line;

        while ((line = _reader.ReadLine()) != null)
        {
            if (line.Length == 0) continue;

            string[] parts = line.Split(' ');
            int[] row = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                row[i] = int.Parse(parts[i]);
            }
            rows.Add(row);
        }

        if (rows.Count == 0) return new int[0, 0];

        int[,] matrix = new int[rows.Count, rows[0].Length];
        for (int i = 0; i < rows.Count; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                matrix[i, j] = rows[i][j];
            }
        }
        return matrix;
    }

    public void Dispose()
    {
        if (_disposed) return;
        _reader.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}