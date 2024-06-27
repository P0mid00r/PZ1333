using Avalonia.Controls;
using PZ_13_19.ViewModels;

namespace PZ_13_19.Views;

public partial class MainWindow : Window
{
    public static Window Context { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        Context = this;
    }
}
