namespace Lab3;

public class Vehicle
{
    // 3 поля: вид, швидкість (км/год), рік випуску
    public string Kind { get; set; }
    public double Speed { get; set; }
    public int Year { get; set; }

    // 1. Конструктор за замовчуванням
    public Vehicle()
    {
        Kind = "Невідомо";
        Speed = 0;
        Year = 2000;
    }

    // 2. Конструктор для ініціалізації об'єкта
    public Vehicle(string kind, double speed, int year)
    {
        Kind = kind;
        Speed = speed;
        Year = year;
    }

    // 3. Конструктор перезавантаження (копіювання іншого об'єкта)
    public Vehicle(Vehicle other) : this(other.Kind, other.Speed, other.Year)
    {
    }

    // Деструктор (у C# це "фіналізатор")
    ~Vehicle()
    {
        Console.WriteLine("Лабораторна робота виконана студентом 2 курсу Прізвище Ім'я По-батькові");
    }

    // Вартість = (швидкість * рік) / 100
    public virtual double Cost()
    {
        return Speed * Year / 100;
    }

    // Оновлення засобу: рік випуску зменшується на 5
    public virtual void Update()
    {
        Year -= 5;
    }

    // Інформація: вид, рік випуску і вартість
    public virtual string Info()
    {
        return $"Вид: {Kind}, рік випуску: {Year}, вартість: {Cost():F2}";
    }
}