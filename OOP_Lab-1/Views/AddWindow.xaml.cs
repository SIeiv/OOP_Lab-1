using System.Runtime.InteropServices;
using System.Windows.Input;
using OOP_Lab_1.Models;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;
using OOP_Lab_1.ViewModels;
using static System.Enum;

namespace OOP_Lab_1.Views;

public partial class AddWindow
{
    public ICommand AddCommand => new RelayCommand(_ => AddComputer() );

    
    
    private readonly MainWindow _customOwner;
    public AddWindow(MainWindow owner)
    {
        _customOwner = owner;
        DataContext = this;
        InitializeComponent();
    }

    private void AddComputer()
    {
        try
        {
            TryParse(ProcessorManufactComboBox.Text, out Manufacturer processorManufacturer);

            TryParse(RamTypeComboBox.Text, out MemoryType memoryType);

            TryParse(StorageTypeComboBox.Text, out StorageType storageType);

            TryParse(CompManufactComboBox.Text, out Manufacturer compManufacturer);
            
            var p1 = new Processor(processorManufacturer, ProcessorModelTextBox.Text,
                int.Parse(ProcessorFrequencyTextBox.Text));
            var r1 = new Ram(int.Parse(RamSizeTextBox.Text), memoryType);
        
            var c1 = new Computer
            {
                CPU = p1,
                Memory = r1,
                StorageGB = short.Parse(StorageSizeTextBox.Text),
                StorageType = storageType,
                Manufacturer = compManufacturer,
                Price = short.Parse(ComputerPriceTextBox.Text)
            };

            _customOwner.Computers.Add(c1);
            _customOwner.MainList.Items.Refresh();
            Close();
        }
        catch (Exception exception)
        {
            ShowNativeMessageBox("Большой секс", exception.Message);
        }
    }
    
    
    
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    private void ShowNativeMessageBox(string title, string message)
    {
        MessageBox(IntPtr.Zero, message, title, 0x00000040);
    }
    
    
}