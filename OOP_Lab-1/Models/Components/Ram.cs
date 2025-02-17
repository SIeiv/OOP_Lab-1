using OOP_Lab_1.Exceptions;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Models.Components;



public record Ram
{
    private int _size;
    private MemoryType _type;

    public Ram() {}

    public Ram(int size, MemoryType type)
    {
        SizeGB = size;
        Type = type;
    }
    
    public int SizeGB
    {
        get => _size;
        set => _size = value is >= 1 and <= 256
            ? value 
            : throw new InvalidRamException("Объём ОЗУ должен быть от 1GB до 256GB");
    }

    public MemoryType Type
    {
        get => _type;
        set => _type = Enum.IsDefined(typeof(MemoryType), value)
            ? value 
            : throw new InvalidRamException("Неверный тип памяти");
    }

    public string ToHex() => $"0x{_size:X}";

    public override string ToString() => $"{SizeGB}GB {Type}";
}