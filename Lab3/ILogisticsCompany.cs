namespace Lab3;

public interface ILogisticsCompany
{
    // Додати транспорт до бази
    void RegisterTransport(Transport transport);

    // Знайти транспорт із вантажопідйомністю не менше заданої
    List<Transport> SearchByPayloadCapacity(double minCapacity);
}