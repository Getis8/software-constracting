namespace Lab3;

public class Train : Transport
{
    // Власні поля
    public int WagonsCount { get; private set; }
    public double CapacityPerWagon { get; private set; } // т на один вагон
    public string Route { get; set; }

    // Вантажопідйомність потяга = кількість вагонів * вантажопідйомність вагона
    public Train(string name, int year, double speed,
                 int wagonsCount, double capacityPerWagon, string route)
        : base(name, year, wagonsCount * capacityPerWagon, speed)
    {
        WagonsCount = wagonsCount;
        CapacityPerWagon = capacityPerWagon;
        Route = route;
    }

    // Реалізація абстрактних методів
    public override string GetTransportType()
    {
        return "Потяг";
    }

    // 8 грн за кілометр + 100 грн за кожен вагон
    public override double CalculateDeliveryCost(double distanceKm)
    {
        return distanceKm * 8 + WagonsCount * 100;
    }

    // Власні методи, які є тільки в Train

    // Додати вагони (вантажопідйомність зростає)
    public void AddWagons(int count)
    {
        if (count <= 0)
            throw new ArgumentException("Кількість вагонів має бути більшою за нуль.");
        WagonsCount += count;
        PayloadCapacity = WagonsCount * CapacityPerWagon;
    }

    // Час у дорозі в годинах
    public double CalculateTravelTime(double distanceKm)
    {
        return distanceKm / Speed;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", вагонів: {WagonsCount}, маршрут: {Route}";
    }
}