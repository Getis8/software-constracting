using System.Globalization;

namespace Lab3;

public static class Task2Demo
{
    public static void Run()
    {
        // Створюємо об'єкт порожнім конструктором, потім заповнюємо через властивості
        Animal animal = new Animal();

        Console.WriteLine("Введіть дані тварини:");

        animal.Name = ReadText("Ім'я: ");
        animal.Species = ReadText("Вид (наприклад, лев): ");
        animal.Age = ReadInt("Вік (повних років): ");
        animal.Weight = ReadDouble("Вага (кг): ");
        animal.Color = ReadText("Колір: ");
        animal.Habitat = ReadText("Середовище проживання: ");
        animal.IsPredator = ReadBool("Це хижак? (так/ні): ");

        Console.WriteLine();
        Console.WriteLine("--- Демонстрація методів ---");

        Console.WriteLine("Інформація: " + animal.GetInfo());
        Console.WriteLine("Вікова категорія: " + animal.GetAgeCategory());
        Console.WriteLine($"Потрібно їжі на день: {animal.CalculateDailyFood():F2} кг");

        double food = animal.CalculateDailyFood();
        animal.Feed(food);
        Console.WriteLine($"Після годування ({food:F2} кг їжі) вага: {animal.Weight:F2} кг");
    }

    // Допоміжні методи введення: повторюють запит, поки не введено коректно

    private static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();
            Console.WriteLine("Поле не може бути порожнім, спробуйте ще раз.");
        }
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= 0)
                return value;
            Console.WriteLine("Введіть ціле число, не менше 0.");
        }
    }

    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string text = (Console.ReadLine() ?? "").Replace(',', '.');
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture,
                                out double value) && value > 0)
                return value;
            Console.WriteLine("Введіть число більше 0 (можна з крапкою або комою).");
        }
    }

    private static bool ReadBool(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string answer = (Console.ReadLine() ?? "").Trim().ToLower();
            if (answer == "так" || answer == "т") return true;
            if (answer == "ні" || answer == "н") return false;
            Console.WriteLine("Введіть \"так\" або \"ні\".");
        }
    }
}