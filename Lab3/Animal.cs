namespace Lab3;

public class Animal
{
    // 7 закритих полів
    private string _name = "Невідомо";
    private string _species = "Невідомо";
    private int _age;
    private double _weight = 1;
    private string _color = "Невідомо";
    private string _habitat = "Невідомо";
    private bool _isPredator;

    // Властивості: доступ до полів + перевірка значень
    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ім'я не може бути порожнім.");
            _name = value;
        }
    }

    public string Species
    {
        get { return _species; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Вид не може бути порожнім.");
            _species = value;
        }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Вік не може бути від'ємним.");
            _age = value;
        }
    }

    public double Weight
    {
        get { return _weight; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Вага має бути більшою за нуль.");
            _weight = value;
        }
    }

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public string Habitat
    {
        get { return _habitat; }
        set { _habitat = value; }
    }

    public bool IsPredator
    {
        get { return _isPredator; }
        set { _isPredator = value; }
    }

    // Конструктор без параметрів (поля вже мають значення за замовчуванням)
    public Animal()
    {
    }

    // Конструктор з усіма параметрами
    public Animal(string name, string species, int age, double weight,
                  string color, string habitat, bool isPredator)
    {
        // Присвоюємо через властивості, щоб спрацювали перевірки
        Name = name;
        Species = species;
        Age = age;
        Weight = weight;
        Color = color;
        Habitat = habitat;
        IsPredator = isPredator;
    }
        // Метод 1: скільки їжі потрібно на день (спрощена формула від ваги)
    public double CalculateDailyFood()
    {
        // Хижак ~5% від ваги, травоїдна ~10% від ваги
        double percent = _isPredator ? 0.05 : 0.10;
        return _weight * percent;
    }

    // Метод 2: вікова категорія залежно від віку
    public string GetAgeCategory()
    {
        if (_age < 2) return "дитинча";
        if (_age < 8) return "доросла тварина";
        return "стара тварина";
    }

    // Метод 3: нагодувати тварину (вага трохи збільшується)
    public void Feed(double foodKg)
    {
        if (foodKg <= 0)
            throw new ArgumentException("Кількість їжі має бути більшою за нуль.");
        _weight += foodKg * 0.1;
    }

    // Метод 4: текстовий опис тварини
    public string GetInfo()
    {
        string diet = _isPredator ? "хижак" : "травоїдна/всеїдна";
        return $"{_name} ({_species}), {_age} р., {_weight:F1} кг, " +
               $"колір: {_color}, середовище: {_habitat}, {diet}";
    }
}