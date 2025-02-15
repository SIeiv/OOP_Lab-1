namespace OOP_Lab_1.Exceptions;

public class InvalidRamException : InvalidComponentException
{
    public InvalidRamException(string message) 
        : base("Ram", message) { }
}