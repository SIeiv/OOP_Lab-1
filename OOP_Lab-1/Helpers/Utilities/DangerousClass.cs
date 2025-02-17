namespace OOP_Lab_1.Helpers.Utilities;

public class DangerousClass : DangerousBase
{
    [DangerousMethod(10)] 
    public void DangerousMethod()
    {

        Invoke(nameof(DangerousMethod));
    }
}