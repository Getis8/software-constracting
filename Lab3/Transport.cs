namespace Lab3;

public abstract class Transport
{
    // Поля, спільні для всього транспорту
    public string Name { get; set; }
    public int Year { get; set; }
    public double PayloadCapacity { get; set; } // вантажопідйомність, т
    public double Speed { get; set; }           // швидкість, км/год

    protected Transport(string name, int year, double payloadCapacity, double speed)
    {
        Name = name;
        Year = year;
        PayloadCapacity = payloadCapacity;
        Speed = speed;
    }

    // --- 2 абстрактні методи (тіла немає, реалізують нащадки) ---

    // Тип транспорту словами
    public abstract string GetTransportType();

    // Вартість доставки на задану відстань
    public abstract double CalculateDeliveryCost(double distanceKm);

    // --- 2 звичайні методи (мають реалізацію) ---

    // Вік транспорту
    public int GetAge(int currentYear)
    {
        return currentYear - Year;
    }

    // Загальна інформація (virtual, щоб нащадки могли додати свої дані)
    public virtual string GetInfo()
    {
        return $"{GetTransportType()}: {Name}, {Year} р., " +
               $"вантажопідйомність: {PayloadCapacity} т, швидкість: {Speed} км/год";
    }
}