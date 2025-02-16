using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OOP_Lab_1.Models;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Views;

public partial class AddWindow : Window
{
    public MainWindow CustomOwner;
    public AddWindow()
    {
        InitializeComponent();
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Manufacturer ProcessorManufact;
            Manufacturer.TryParse(ProcessorManufactComboBox.Text, out ProcessorManufact);

            MemoryType memoryType;
            MemoryType.TryParse(RamTypeComboBox.Text, out memoryType);
            
            StorageType storageType;
            StorageType.TryParse(StorageTypeComboBox.Text, out storageType);
            
            Manufacturer CompManufact;
            Manufacturer.TryParse(CompManufactComboBox.Text, out CompManufact);
            
            Processor p1 = new Processor(ProcessorManufact, ProcessorModelTextBox.Text,
                Int16.Parse(ProcessorFrequencyTextBox.Text));
            Ram r1 = new Ram(Int16.Parse(RamSizeTextBox.Text), memoryType);
        
            Computer c1 = new Computer();
            c1.CPU = p1;
            c1.Memory = r1;
        
            c1.StorageGB = Int16.Parse(StorageSizeTextBox.Text);
            c1.StorageType = storageType;
            c1.Manufacturer = CompManufact;
            c1.Price = Int32.Parse(ComputerPriceTextBox.Text);
            
            CustomOwner.Computers.Add(c1);
            CustomOwner.MainList.Items.Refresh();;
            Close();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}