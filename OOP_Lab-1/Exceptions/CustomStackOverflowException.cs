namespace OOP_Lab_1.Exceptions;

public class CustomStackOverflowException(string message, string extraData) : Exception(message)
{
    public string ExtraData { get; } = extraData;

    public override string ToString()
    {
        return base.ToString() + $"\nДополнительная информация: {ExtraData}";
    }
    
}