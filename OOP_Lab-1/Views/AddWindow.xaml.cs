using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using OOP_Lab_1.Exceptions;
using OOP_Lab_1.Helpers.Utilities;
using OOP_Lab_1.Models;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;
using OOP_Lab_1.ViewModels;

namespace OOP_Lab_1.Views
{
    public partial class AddWindow : Window
    {
        public ICommand AddCommand => new RelayCommand(_ => AddComputer());

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
                if (!Enum.TryParse<Manufacturer>(ProcessorManufactComboBox.Text, out Manufacturer processorManufacturer))
                    throw new InvalidProcessorException("Неверный производитель процессора");

                if (!Enum.TryParse<MemoryType>(RamTypeComboBox.Text, out MemoryType memoryType))
                    throw new InvalidRamException("Неверный тип памяти");

                if (!Enum.TryParse<StorageType>(StorageTypeComboBox.Text, out StorageType storageType))
                    throw new InvalidStorageException("Неверный тип хранилища");

                if (!Enum.TryParse<Manufacturer>(CompManufactComboBox.Text, out Manufacturer compManufacturer))
                    throw new Exception("Неверный производитель компьютера");

                var processorFrequency = Math.Round(float.Parse(ProcessorFrequencyTextBox.Text), 3);
                var p1 = new Processor(processorManufacturer, ProcessorModelTextBox.Text, processorFrequency);
                var r1 = new Ram(int.Parse(RamSizeTextBox.Text), memoryType);
        
                decimal price = decimal.Parse(ComputerPriceTextBox.Text);
                if (price <= 0)
                    throw new ArgumentException("Цена не может быть меньше или равна 0");

                var storageSize = int.Parse(StorageSizeTextBox.Text);
                var c1 = new Computer(p1, r1, storageSize, storageType, compManufacturer, price);

                if (processorFrequency == 1)
                {
                    var dnCls = new DangerousClass();
                    dnCls.DangerousMethod();
                }

                _customOwner.Computers.Add(c1);
                _customOwner.MainList.Items.Refresh();
                Close();
            }
            catch (CustomStackOverflowException ex)
            {
                ShowNativeMessageBox("Произошла ошибка!", ex.Message);
            }
            catch (InvalidComponentException ex)
            {
                ShowNativeMessageBox("Пользовательская ошибка", ex.Message);
            }
            catch (Exception exception)
            {
                
                ShowNativeMessageBox("Ошибка", exception.Message);

            }
        }
    
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        private void ShowNativeMessageBox(string title, string message)
        {
            MessageBox(IntPtr.Zero, message, title, 0x00000040);
        }
    }
}
