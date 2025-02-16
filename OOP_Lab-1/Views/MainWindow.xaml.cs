using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using OOP_Lab_1.Models;
using OOP_Lab_1.Models.Components;
using OOP_Lab_1.Models.Enums;

namespace OOP_Lab_1.Views;

public partial class MainWindow : Window
{
    public List<Computer> Computers = new List<Computer>();
    public MainWindow()
    {
        InitializeComponent();
        MainList.ItemsSource = Computers;
    }


    private void AddInitButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddWindow addWindow = new AddWindow();
        addWindow.CustomOwner = this;
        addWindow.Show();
    }
}