namespace Lab3;

public class Car : Transport
{
    // Власні поля
    public int Doors { get; set; }
    public double FuelConsumption { get; set; } // л на 100 км

    public Car(string name, int year, double payloadCapacity, double speed,
               int doors, double fuelConsumption)
        : base(name, year, payloadCapacity, speed)
    {
        Doors = doors;
        FuelConsumption = fuelConsumption;
    }

    // Реалізація абстрактних методів
    public override string GetTransportType()
    {
        return "Автомобіль";
    }

    // 15 грн за кілометр
    public override double CalculateDeliveryCost(double distanceKm)
    {
        return distanceKm * 15;
    }

    // Власні методи, які є тільки в Car

    // Скільки літрів пального піде на дорогу
    public double CalculateFuelNeeded(double distanceKm)
    {
        return distanceKm * FuelConsumption / 100;
    }

    // Легкий фургон (до 3.5 т) може їздити по місту
    public bool IsSuitableForCity()
    {
        return PayloadCapacity <= 3.5;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", дверей: {Doors}, витрата: {FuelConsumption} л/100км";
    }
}