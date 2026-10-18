namespace Lab3;

// Відповідає ТІЛЬКИ за запис матриці у файл
public class MatrixWriter : IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed;

    public MatrixWriter(string path)
    {
        _writer = new StreamWriter(path);
    }

    public void Write(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            string[] line = new string[cols];
            for (int j = 0; j < cols; j++)
            {
                line[j] = matrix[i, j].ToString();
            }
            _writer.WriteLine(string.Join(" ", line));
        }
    }

    public void Dispose()
    {
        if (_disposed) return;
        _writer.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}