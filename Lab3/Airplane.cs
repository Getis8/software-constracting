namespace Lab3;

public class Airplane : Vehicle
{
    // Власні поля літака
    public double Height { get; set; }      // висота польоту, м
    public int Passengers { get; set; }     // кількість пасажирських місць
    public int Engines { get; set; }        // кількість двигунів

    // Конструктор за замовчуванням
    public Airplane() : base()
    {
        Height = 0;
        Passengers = 0;
        Engines = 1;
    }

    // Конструктор для ініціалізації (усі поля)
    public Airplane(string kind, double speed, int year,
                    double height, int passengers, int engines)
        : base(kind, speed, year)
    {
        Height = height;
        Passengers = passengers;
        Engines = engines;
    }

    // Конструктор перезавантаження (лише основні поля + висота)
    public Airplane(string kind, double speed, int year, double height)
        : this(kind, speed, year, height, 0, 2)
    {
    }

    // Вартість літака = швидкість * рік
    public override double Cost()
    {
        return Speed * Year;
    }

    // Оновлення літака: рік випуску зменшується на 3
    public override void Update()
    {
        Year -= 3;
    }

    public override string Info()
    {
        return base.Info() + $", висота: {Height} м, пасажирів: {Passengers}, двигунів: {Engines}";
    }
}