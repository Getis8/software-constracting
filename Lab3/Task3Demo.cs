using System.Runtime.CompilerServices;

namespace Lab3;

public static class Task3Demo
{
    public static void Run()
    {
        CreateAndShow();

        // Примусово запускаємо збирач сміття, щоб спрацювали деструктори
        Console.WriteLine();
        Console.WriteLine("--- Знищення об'єктів ---");
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    // NoInlining потрібен, щоб об'єкти точно вважались непотрібними після виходу з методу
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void CreateAndShow()
    {
        // Демонстрація конструктора за замовчуванням
        Vehicle empty = new Vehicle();
        Console.WriteLine("Об'єкт за замовчуванням: " + empty.Info());
        Console.WriteLine();

        // Введення даних і створення об'єктів
        Console.WriteLine("--- Транспортний засіб ---");
        Vehicle vehicle = new Vehicle(
            Input.ReadText("Вид: "),
            Input.ReadDouble("Швидкість (км/год): "),
            Input.ReadInt("Рік випуску: "));

        Console.WriteLine();
        Console.WriteLine("--- Літак ---");
        Airplane airplane = new Airplane(
            Input.ReadText("Вид: "),
            Input.ReadDouble("Швидкість (км/год): "),
            Input.ReadInt("Рік випуску: "),
            Input.ReadDouble("Висота (м): "),
            Input.ReadInt("Кількість пасажирів: "),
            Input.ReadInt("Кількість двигунів: "));

        Console.WriteLine();
        Console.WriteLine("--- Корабель ---");
        Ship ship = new Ship(
            Input.ReadText("Вид: "),
            Input.ReadDouble("Швидкість (км/год): "),
            Input.ReadInt("Рік випуску: "),
            Input.ReadText("Порт приписки: "),
            Input.ReadDouble("Водотоннажність (т): "),
            Input.ReadInt("Розмір екіпажу: "));

        // Масив типу Vehicle, у якому лежать об'єкти різних класів
        Vehicle[] all = { vehicle, airplane, ship };

        Console.WriteLine();
        Console.WriteLine("=== До оновлення ===");
        foreach (Vehicle v in all)
        {
            Console.WriteLine(v.Info());
        }

        // Оновлення: для кожного об'єкта викличеться ЙОГО версія Update()
        foreach (Vehicle v in all)
        {
            v.Update();
        }

        Console.WriteLine();
        Console.WriteLine("=== Після оновлення ===");
        foreach (Vehicle v in all)
        {
            Console.WriteLine(v.Info());
        }
    }
}