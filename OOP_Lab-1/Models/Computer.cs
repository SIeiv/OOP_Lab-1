using OOP_Lab_1.Exceptions;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Models;


public class Computer
{
    public static int InstanceCount { get; private set; }

    private Processor _processor;
    private Ram _ram;
    private int _storage;

    public Processor CPU
    {
        get => _processor;
        set => _processor = value ?? throw new InvalidProcessorException("Processor cannot be null");
    }

    public Ram Memory
    {
        get => _ram;
        set => _ram = value;
    }

    public int StorageGB
    {
        get => _storage;
        set => _storage = value switch {
            >= 128 and <= 4096 => value,
            _ => throw new InvalidStorageException("Storage must be between 128GB and 4TB")
        };
    }

    public StorageType StorageType { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public decimal Price { get; set; }

    public Computer()
    {
        InstanceCount++;
        _ram = new Ram(); 
    }

    public override string ToString() => 
        $"{Manufacturer} | {CPU} | {Memory} | {StorageGB}GB {StorageType}";
}