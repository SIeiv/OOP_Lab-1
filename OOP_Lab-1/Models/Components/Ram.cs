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
        set => _size = value is >= 1 and <= 256 ? value : 
            throw new InvalidRamException("Invalid RAM size");
    }

    public MemoryType Type
    {
        get => _type;
        set => _type = Enum.IsDefined(typeof(MemoryType), value) ? value : 
            throw new InvalidRamException("Invalid memory type");
    }

    public string ToHex() => $"0x{_size:X}";
    public override string ToString() => $"{SizeGB}GB {Type}";
}
