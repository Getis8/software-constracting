namespace Lab3;

public class Ship : Vehicle
{
    // Власні поля корабля
    public string HomePort { get; set; }    // порт приписки
    public double Displacement { get; set; } // водотоннажність, т
    public int CrewSize { get; set; }       // розмір екіпажу

    // Конструктор за замовчуванням
    public Ship() : base()
    {
        HomePort = "Невідомо";
        Displacement = 0;
        CrewSize = 0;
    }

    // Конструктор для ініціалізації (усі поля)
    public Ship(string kind, double speed, int year,
                string homePort, double displacement, int crewSize)
        : base(kind, speed, year)
    {
        HomePort = homePort;
        Displacement = displacement;
        CrewSize = crewSize;
    }

    // Конструктор перезавантаження (основні поля + порт)
    public Ship(string kind, double speed, int year, string homePort)
        : this(kind, speed, year, homePort, 0, 0)
    {
    }

    // Вартість корабля = (швидкість * рік) / 10
    public override double Cost()
    {
        return Speed * Year / 10;
    }

    // Update() не перевизначаємо: за варіантом у корабля він лишається
    // базовим (рік зменшується на 5)

    public override string Info()
    {
        return base.Info() + $", порт приписки: {HomePort}, водотоннажність: {Displacement} т, екіпаж: {CrewSize}";
    }
}