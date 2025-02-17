namespace OOP_Lab_1.Helpers;

[AttributeUsage(AttributeTargets.Method)]
public class DangerousMethodAttribute(int maxRecursionDepth) : Attribute
{
    public int MaxRecursionDepth { get; } = maxRecursionDepth;
}

