using OOP_Lab_1.Exceptions;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Models;


public class Computer
{
    public static int InstanceCount { get; private set; }

    public Processor CPU { get; set; }
    public Ram Memory { get; set; }
    
    private int _storageGB;
    public int StorageGB
    {
        get => _storageGB;
        set => _storageGB = value switch
        {
            >= 128 and <= 4096 => value,
            _ => throw new InvalidStorageException("Хранилище должно быть от 128GB до 4096GB (4TB)")
        };
    }
    
    public StorageType StorageType { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }

    public Computer()
    {
        InstanceCount++;
        CreationDate = DateTime.Now;
    }

    public Computer(Manufacturer manufacturer) : this()
    {
        Manufacturer = manufacturer;
    }

    public Computer(Manufacturer manufacturer, decimal price) : this(manufacturer)
    {
        Price = price;
    }

    public Computer(Processor cpu, Ram memory, int storageGB, StorageType storageType, Manufacturer manufacturer, decimal price)
        : this(manufacturer, price)
    {
        CPU = cpu;
        Memory = memory;
        StorageGB = storageGB;
        StorageType = storageType;
        CreationDate = DateTime.Now;
    }

    public string GetStorageInHex() => $"0x{StorageGB:X}";

    public void DisplayPrice()
    {
        Console.WriteLine($"Цена: {Price}");
    }

    public override string ToString() =>
        $"Производитель: {Manufacturer} | Процессор: {CPU} | ОЗУ: {Memory} | Хранилище: {StorageGB}GB {StorageType} | Цена: {Price:C}";
}

