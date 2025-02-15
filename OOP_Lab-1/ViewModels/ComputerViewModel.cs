using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Input;
using OOP_Lab_1.Exceptions;
using OOP_Lab_1.Models;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.ViewModels;

public class ComputerViewModel : INotifyPropertyChanged
{
    
   private Computer _computer = new Computer();
        private string _status;
        private Processor _selectedProcessor;
        private int _ramSize;
        private MemoryType _selectedMemoryType;
        private int _storageSize;
        private StorageType _selectedStorageType;
        private decimal _price;

        public ComputerViewModel()
        {
            ShowWelcomeMessage();
            InitializeDefaults();
        }

        public int InstanceCount => Computer.InstanceCount;
        public string Status { get => _status; set => SetField(ref _status, value); }

        
        public IEnumerable<Manufacturer> ProcessorBrands => 
            Enum.GetValues(typeof(Manufacturer)).Cast<Manufacturer>()
                .Where(b => b != Manufacturer.Nvidia);

        public IEnumerable<MemoryType> MemoryTypes =>
            Enum.GetValues(typeof(MemoryType)).Cast<MemoryType>();
        
        public IEnumerable<StorageType> StorageTypes =>
            Enum.GetValues(typeof(StorageType)).Cast<StorageType>();
        

        public Processor SelectedProcessor
        {
            get => _selectedProcessor;
            set => SetField(ref _selectedProcessor, value);
        }

        public int RamSize
        {
            get => _ramSize;
            set => SetField(ref _ramSize, value);
        }

        public MemoryType SelectedMemoryType
        {
            get => _selectedMemoryType;
            set => SetField(ref _selectedMemoryType, value); 
        }

        public int StorageSize
        {
            get => _storageSize;
            set => SetField(ref _storageSize, value);
        }

        public StorageType SelectedStorageType
        {
            get => _selectedStorageType;
            set
            {
                if (SetField(ref _selectedStorageType, value))
                {
                    _computer.StorageType = value;
                }
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (SetField(ref _price, value))
                {
                    _computer.Price = value;
                }
            }
        }

        
        public ICommand UpdateCommand => new RelayCommand(_ => UpdateComputer());
        public ICommand ShowSpecsCommand => new RelayCommand(_ => ShowComputerSpecs());
        public ICommand ResetCommand => new RelayCommand(_ => ResetComputer());

        private void InitializeDefaults()
        {
            try
            {
                SelectedProcessor = new Processor
                {
                    Brand = Manufacturer.Intel,
                    Model = "i7-12700K",
                    FrequencyGHz = 3.6
                };
                RamSize = 16;
                SelectedMemoryType = MemoryType.DDR4;
                StorageSize = 512;
                SelectedStorageType = StorageType.NVMe;
                Price = 1500m;
            }
            catch (InvalidComponentException ex)
            {
                HandleException(ex);
            }
        }

        private void UpdateComputer()
        {
            try
            {
                ValidateAndUpdateComponents();
                Status = $"Last updated: {DateTime.Now:T}";
                OnPropertyChanged(nameof(_computer));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void ValidateAndUpdateComponents()
        {
            _computer.CPU = SelectedProcessor ?? 
                throw new InvalidProcessorException("Processor must be selected");

            _computer.Memory = new Ram
            {
                SizeGB = RamSize,
                Type = SelectedMemoryType
            };

            _computer.StorageGB = StorageSize;
            _computer.StorageType = SelectedStorageType;
            _computer.Price = Price;
        }

        private void ShowComputerSpecs()
        {
            try
            {
                var specs = $"Full Specifications:\n{_computer}\n" +
                          $"RAM in HEX: {_computer.Memory.ToHex()}";
                ShowNativeMessageBox("Computer Specifications", specs);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void ResetComputer()
        {
            try
            {
                _computer = new Computer();
                InitializeDefaults();
                OnPropertyChanged(nameof(_computer));
                Status = "System reset to defaults";
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            string message = ex switch
            {
                InvalidStorageException ise =>
                    $"Storage Error: {ise.Message}",
        
                InvalidComponentException ice =>
                    $"Component Error ({ice.ComponentName}): {ice.Message}",
        
                _ => $"Unexpected error: {ex.Message}"
            };

            ShowNativeMessageBox("Validation Error", message);
            Status = $"Error: {message}";
        }

        private void ShowWelcomeMessage()
        {
            ShowNativeMessageBox("Computer Configuration App",
                "Секс");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        private void ShowNativeMessageBox(string title, string message)
        {
            MessageBox(IntPtr.Zero, message, title, 0x00000040);
        }
    
    
    
}