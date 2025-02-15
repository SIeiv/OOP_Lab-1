namespace OOP_Lab_1.Core.Models;


public class Computer
{
    public static int InstanceCount { get; private set; }

    public string ProcessorType { get; set; }
    public int RamGB { get; set; }
    public double Price { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int StorageGB { get; set; }
    public int Cores { get; set; }

    public Computer()
    {
        InstanceCount++;
    }

    public Computer(string processor) : this() => ProcessorType = processor;
    
    public Computer(string processor, int ram) : this(processor) => RamGB = ram;
    
    public Computer(string processor, int ram, double price, string manufacturer, 
        string model, int storage, int cores) : this(processor, ram)
    {
        Price = price;
        Manufacturer = manufacturer;
        Model = model;
        StorageGB = storage;
        Cores = cores;
    }

    public override string ToString() => 
        $"{Manufacturer} {Model} | {ProcessorType} | {RamGB}GB RAM | {StorageGB}GB SSD";

    public string GetRamInHex() => $"0x{RamGB:X}";
    
    public string GetFieldValue(string fieldName) => 
        GetType().GetProperty(fieldName)?.GetValue(this)?.ToString() ?? "N/A";
    
    
}