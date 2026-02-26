using System;
using System.Collections.Generic;

abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Habitat { get; set; }
    public string Diet { get; set; }

    public Animal(string name, int age, string habitat, string diet)
    {
        Name = name;
        Age = age;
        Habitat = habitat;
        Diet = diet;
    }

    public virtual string GetInfo()
    {
        return $"Кличка: {Name}, Возраст: {Age}, Среда: {Habitat}, Питание: {Diet}";
    }
}

class Mammal : Animal
{
    public bool HasFur { get; set; }
    public Mammal(string name, int age, string habitat, string diet, bool hasFur) : base(name, age, habitat, diet)
    {
        HasFur = hasFur;
    }
    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Тип: Млекопитающее, Шерсть: {(HasFur ? "есть" : "нет")}";
    }
}

class Bird : Animal
{
    public double WingSpan { get; set; }
    public Bird(string name, int age, string habitat, string diet, double wingSpan) : base(name, age, habitat, diet)
    {
        WingSpan = wingSpan;
    }
    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Тип: Птица, Размах крыльев: {WingSpan} м";
    }
}

class Fish : Animal
{
    public string WaterType { get; set; }
    public Fish(string name, int age, string habitat, string diet, string waterType) : base(name, age, habitat, diet)
    {
        WaterType = waterType;
    }
    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Тип: Рыба, Вода: {WaterType}";
    }
}

class Reptile : Animal
{
    public bool IsVenomous { get; set; }
    public Reptile(string name, int age, string habitat, string diet, bool isVenomous) : base(name, age, habitat, diet)
    {
        IsVenomous = isVenomous;
    }
    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Тип: Пресмыкающееся, Ядовитый: {(IsVenomous ? "да" : "нет")}";
    }
}

class Amphibian : Animal
{
    public string SkinMoisture { get; set; }
    public Amphibian(string name, int age, string habitat, string diet, string skinMoisture) : base(name, age, habitat, diet)
    {
        SkinMoisture = skinMoisture;
    }
    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Тип: Земноводное, Кожа: {SkinMoisture}";
    }
}

class AnimalManager
{
    private static AnimalManager _instance;
    private List<Animal> _animals = new List<Animal>();

    private AnimalManager() { }

    public static AnimalManager Instance
    {
        get
        {
            if (_instance == null) _instance = new AnimalManager();
            return _instance;
        }
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void ShowAll()
    {
        Console.WriteLine("\n=== Все животные ===");
        foreach (var animal in _animals)
        {
            Console.WriteLine(animal.GetInfo());
        }
        Console.WriteLine("==================\n");
    }
}

class Program
{
    static void Main()
    {
        var manager = AnimalManager.Instance;

        // Создаём и добавляем животных
        manager.AddAnimal(new Mammal("Барсик", 5, "Лес", "Хищник", true));
        manager.AddAnimal(new Bird("Кеша", 3, "Дом", "Всеядное", 0.5));
        manager.AddAnimal(new Fish("Немо", 1, "Океан", "Хищник", "Морская"));
        manager.AddAnimal(new Reptile("Каа", 10, "Джунгли", "Хищник", false));
        manager.AddAnimal(new Amphibian("Квака", 2, "Болото", "Насекомые", "Влажная"));

        manager.ShowAll();

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}