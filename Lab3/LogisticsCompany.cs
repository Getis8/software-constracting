namespace Lab3;

// Сервіс: реалізує інтерфейс і ховає в собі колекцію транспорту
public class LogisticsCompany : ILogisticsCompany
{
    // private: ззовні список не видно, працювати можна лише через методи
    private readonly List<Transport> _fleet = new List<Transport>();

    public void RegisterTransport(Transport transport)
    {
        if (transport == null)
            throw new ArgumentNullException(nameof(transport));
        _fleet.Add(transport);
    }

    public List<Transport> SearchByPayloadCapacity(double minCapacity)
    {
        var result = new List<Transport>();
        foreach (Transport t in _fleet)
        {
            if (t.PayloadCapacity >= minCapacity)
                result.Add(t);
        }
        return result;
    }

    // Вивід усієї бази
    public void PrintAll()
    {
        foreach (Transport t in _fleet)
        {
            Console.WriteLine(t.GetInfo());
        }
    }
}