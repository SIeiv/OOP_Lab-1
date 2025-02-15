namespace OOP_Lab_1.Core.Exceptions;
using System;


public class StackOverflowException : Exception
{
    public DateTime ErrorTime { get; }
    public string AdditionalInfo { get; }

    public StackOverflowException(string message, string info) : base(message)
    {
        ErrorTime = DateTime.Now;
        AdditionalInfo = info;
    }
    
}