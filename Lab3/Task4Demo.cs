namespace Lab3;

public static class Task4Demo
{
    public static void Run()
    {
        // Змінна типу інтерфейсу: через неї викликаємо методи контракту
        ILogisticsCompany company = new LogisticsCompany();

        // База з об'єктів різних похідних класів
        company.RegisterTransport(new Car("Mercedes Sprinter", 2018, 1.5, 120, 4, 11.5));
        company.RegisterTransport(new Car("Ford Transit", 2020, 1.2, 110, 4, 9.8));
        company.RegisterTransport(new Car("MAN TGL", 2016, 7.5, 90, 2, 18.0));
        company.RegisterTransport(new Train("Вантажний потяг №1", 2010, 80, 20, 60, "Київ - Львів"));
        company.RegisterTransport(new Train("Вантажний потяг №2", 2015, 70, 10, 55, "Одеса - Харків"));

        // Вивід усієї бази (PrintAll є в класі, а не в інтерфейсі)
        Console.WriteLine("--- Уся база ---");
        ((LogisticsCompany)company).PrintAll();

        // Пошук за вантажопідйомністю: мінімум вводимо з клавіатури
        Console.WriteLine();
        double min = Input.ReadDouble("Мінімальна вантажопідйомність (т): ");

        List<Transport> found = company.SearchByPayloadCapacity(min);

        Console.WriteLine();
        Console.WriteLine($"--- Результат пошуку (від {min} т) ---");
        if (found.Count == 0)
        {
            Console.WriteLine("Нічого не знайдено.");
        }
        else
        {
            foreach (Transport t in found)
            {
                Console.WriteLine(t.GetInfo());
                Console.WriteLine($"   Доставка на 500 км: {t.CalculateDeliveryCost(500):F2} грн");
            }
        }

        // Демонстрація власних методів нащадків
        Console.WriteLine();
        Console.WriteLine("--- Власні методи нащадків ---");
        var car = new Car("Renault Kangoo", 2021, 0.8, 100, 5, 7.2);
        Console.WriteLine($"{car.Name}: пального на 300 км: {car.CalculateFuelNeeded(300):F1} л, " +
                          $"для міста: {(car.IsSuitableForCity() ? "так" : "ні")}");

        var train = new Train("Тестовий потяг", 2012, 60, 10, 50, "Тест");
        train.AddWagons(5);
        Console.WriteLine($"{train.Name}: після додавання вагонів вантажопідйомність {train.PayloadCapacity} т, " +
                          $"час у дорозі на 600 км: {train.CalculateTravelTime(600):F1} год");
    }
}