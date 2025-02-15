namespace OOP_Lab_1.Core.Exceptions;

public class InvalidComputerSpecsException: Exception
{
    public string InvalidField { get; }
    
    public InvalidComputerSpecsException(string field, string message) : base(message)
    {
        InvalidField = field;
    }
    
}