using System.Globalization;

namespace Lab3;

public static class Input
{
    public static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? text = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(text))
                return text.Trim();
            Console.WriteLine("Поле не може бути порожнім.");
        }
    }

    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string text = (Console.ReadLine() ?? "").Replace(',', '.');
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture,
                                out double value) && value >= 0)
                return value;
            Console.WriteLine("Введіть число, не менше 0.");
        }
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= 0)
                return value;
            Console.WriteLine("Введіть ціле число, не менше 0.");
        }
    }
}