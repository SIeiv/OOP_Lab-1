using System.Reflection;
using OOP_Lab_1.Exceptions;
using OOP_Lab_1.Helpers.Utilities;

namespace OOP_Lab_1.Helpers;

public class DangerousBase
{
    public void Invoke(string methodName, params object[] args)
    {
        var method = this.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (method == null)
        {
            throw new ArgumentException($"Метод {methodName} не найден.");
        }

        var attribute = method.GetCustomAttributes(typeof(DangerousMethodAttribute), false)
            .OfType<DangerousMethodAttribute>()
            .FirstOrDefault();

        Action action = () =>
        {
            try
            {
                method.Invoke(this, args);
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw;
            }
        };

        if (attribute != null)
        {
            RecursionManager.IncrementDepth();
            try
            {
                if (RecursionManager.GetCurrentDepth() > attribute.MaxRecursionDepth)
                {
                    throw new CustomStackOverflowException(
                        $"Stack overflow: {RecursionManager.GetCurrentDepth()}",
                        DateTime.Now.ToLongDateString());
                }
                action();
            }
            finally
            {
                RecursionManager.DecrementDepth();
            }
        }
        else
        {
            action();
        }
    }
}