namespace OOP_Lab_1.Exceptions;

public abstract class InvalidComponentException(string component, string message) : Exception(message)
{
    public DateTime ErrorTime { get; } = DateTime.Now;
    public string ComponentName { get; } = component;
}