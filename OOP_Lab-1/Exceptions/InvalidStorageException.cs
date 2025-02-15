namespace OOP_Lab_1.Exceptions;

public class InvalidStorageException : InvalidComponentException
{
    public InvalidStorageException(string message) 
        : base("Processor", message) { }
}