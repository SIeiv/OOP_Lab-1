namespace OOP_Lab_1.Exceptions;

public abstract class InvalidComponentException : Exception
{
    public DateTime ErrorTime { get; } = DateTime.Now;
    public string ComponentName { get; }

    protected InvalidComponentException(string component, string message) 
        : base(message) => ComponentName = component;
}