namespace OOP_Lab_1.Exceptions;

public class InvalidProcessorException : InvalidComponentException
{
    public InvalidProcessorException(string message) 
        : base("Processor", message) { }
}


