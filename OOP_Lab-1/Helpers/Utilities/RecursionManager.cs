using OOP_Lab_1.Exceptions;

namespace OOP_Lab_1.Helpers.Utilities;

public static class RecursionManager
{
    private static int _currentDepth = 0;

    public static int GetCurrentDepth()
    {
        return _currentDepth;
    }

    public static void IncrementDepth()
    {
        _currentDepth++;
    }

    public static void DecrementDepth()
    {
        _currentDepth--;
    }
}