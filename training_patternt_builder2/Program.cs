using System;
using System.Collections.Generic;

public enum MaterialType
{
    Stone,
    Brick
}

public enum Feature
{
    Pool,
    Garage,
    Garden,
    Path
}

public class House
{
    public MaterialType Material { get; set; }
    public List<Feature> Features { get; } = new List<Feature>();

    public override string ToString()
    {
        string features = Features.Count > 0
            ? string.Join(", ", Features)
            : "нет дополнительных построек";
        return $"Дом из материала: {Material}, Особенности: {features}";
    }
}

public class HouseBuilder
{
    private House _house = new House();

    public HouseBuilder SetMaterial(MaterialType material)
    {
        _house.Material = material;
        return this;
    }

    public HouseBuilder AddFeature(Feature feature)
    {
        _house.Features.Add(feature);
        return this;
    }
    public House Build()
    {
        House result = _house;
        _house = new House(); 
        return result;
    }
}
public class Catalog
{
    private List<House> _houses = new List<House>();

    public void AddHouse(House house)
    {
        _houses.Add(house);
    }

    public void DisplayCatalog()
    {
        Console.WriteLine("Каталог домов:");
        foreach (var house in _houses)
        {
            Console.WriteLine(house);
        }
    }
}
public class Program
{
    public static void Main()
    {
        HouseBuilder builder = new HouseBuilder();

        Catalog catalog = new Catalog();

        catalog.AddHouse(
            builder.SetMaterial(MaterialType.Stone)
                   .AddFeature(Feature.Pool)
                   .AddFeature(Feature.Garage)
                   .Build()
        );

        catalog.AddHouse(
            builder.SetMaterial(MaterialType.Brick)
                   .AddFeature(Feature.Garden)
                   .AddFeature(Feature.Path)
                   .Build()
        );

        catalog.DisplayCatalog();
    }
}