namespace OOP_Lab_1;

public class Computer
{
    private string _processorType;
    public string _processorName;
    private float _processorFrequency;
    
    private string _ramType;
    private string _ramName;
    private int _ramVolume;
    
    private float _price;

    public Computer()
    {
        _processorType = "";
        _processorName = "";
        _processorFrequency = 0;
        _ramType = "";
        _ramName = "";
        _ramVolume = 0;
        _price = 0;
    }

    public Computer(float price)
    {
        SetPrice(price);
    }

    public Computer(float price, float processorFrequency)
    {
        SetPrice(price);
        SetProcessorFrequency(processorFrequency);
    }
    
    public Computer(float price, float processorFrequency, 
        string processorType, string processorName, string ramType, string ramName, int ramVolume)
    {
        SetPrice(price);
        SetProcessorFrequency(processorFrequency);
        _processorType = processorType;
        _processorName = processorName;
        _ramType = ramType;
        _ramName = ramName;
        SetRamVolume(ramVolume);
    }

    public void SetProcessorFrequency(float newFrequency)
    {
        if (newFrequency < 0)
        {
            _processorFrequency = 0;
            throw new Exception("Invalid frequency");
        }
        _processorFrequency = newFrequency;
    }

    public void SetRamVolume(int newVolume)
    {
        if (newVolume < 0)
        {
            _ramVolume = 0;
            throw new Exception("Invalid RAM volume");
        }
        _ramVolume = newVolume;
    }

    public void SetPrice(float newPrice)
    {
        if (newPrice < 0)
        {
            _price = 0;
            throw new Exception("Invalid price");
        }
        _price = newPrice;
    }
    public float GetPrice() { return _price; }

    public override string ToString()
    {
        return "Тип процессора: " + _processorType + "; Название процессора: " + _processorName 
               + "; Частота процессора: " + _processorFrequency 
               + "\n" + "Тип озу: " + _ramType + "; Название озу: " + _ramName + "; Объём озу: " + _ramVolume + "GB"
               + "\n" + "Цена: " + _price + " чешских крон";
    }
}