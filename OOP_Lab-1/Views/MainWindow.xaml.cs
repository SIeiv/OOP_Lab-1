using System.Windows;
using OOP_Lab_1.Models;
namespace OOP_Lab_1.Views;

public partial class MainWindow
{
    public List<Computer> Computers = [];
    public MainWindow()
    {
        InitializeComponent();
        MainList.ItemsSource = Computers;
    }


    private void AddInitButton_OnClick(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddWindow(this);
        addWindow.Show();
    }
}