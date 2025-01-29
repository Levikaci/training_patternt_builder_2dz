public interface IBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
}
public class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool HasTripComputer { get; set; }
    public bool HasGPS { get; set; }
}
public class Manual
{
    public string Description { get; set; }
}
public class CarBuilder : IBuilder
{
    private Car _car = new Car();
    public void Reset() => _car = new Car();
    public void SetSeats(int number) => _car.Seats = number;
    public void SetEngine(string engine) => _car.Engine = engine;
    public void SetTripComputer() => _car.HasTripComputer = true;
    public void SetGPS() => _car.HasGPS = true;
    public Car GetResult() => _car;
}
public class ManualBuilder : IBuilder
{
    private Manual _manual = new Manual();
    public void Reset() => _manual = new Manual();
    public void SetSeats(int number) => _manual.Description += $"Имеет 4 сидений.";
    public void SetEngine(string engine) => _manual.Description += $"Двигатель: {engine}.";
    public void SetTripComputer() => _manual.Description += "Оснащен мощным бортовым компьютером.";
    public void SetGPS() => _manual.Description += "Встроенный GPS и Интеллектуальная Навигация";
    public Manual GetResult() => _manual;
}
public class Director
{
    public void MakeSportsCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine("Двигатель с 160 кВТ");
        builder.SetTripComputer();
        builder.SetGPS();
    }
    public void MakeSUV(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(7);
        builder.SetEngine("Дизельный двигатель");
        builder.SetGPS();
    }
}
class Client
{
    static void Main()
    {
        var director = new Director();
        var carBuilder = new CarBuilder();
        director.MakeSportsCar(carBuilder);
        Car car = carBuilder.GetResult();
        Console.WriteLine("Суперспортивный автомобиль");
        Console.WriteLine($"Мест: {car.Seats}");
        Console.WriteLine($"Двигатель: {car.Engine}");
        Console.WriteLine($"Бортовой компьютер: {(car.HasTripComputer ? "Да" : "Нет")}");
        Console.WriteLine($"GPS: {(car.HasGPS ? "Да" : "Нет")}");
        var manualBuilder = new ManualBuilder();
        director.MakeSportsCar(manualBuilder);
        Manual manual = manualBuilder.GetResult();
        Console.WriteLine("Руководство");
        Console.WriteLine(manual.Description);
    }
}
