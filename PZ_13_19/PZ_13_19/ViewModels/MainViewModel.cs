using Avalonia.Controls;
using DynamicData;
using PZ_13_19.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PZ_13_19.ViewModels;

public class MainViewModel : ViewModelBase
{
    private static MainViewModel? _instance;
    public static MainViewModel? Instance
    {
        get
        {
            if (_instance is null)
                _instance = new MainViewModel();
            return _instance;
        }
    }

    private User _userEnter;
    public User UserEnter 
    {
        get => _userEnter;
        set
        {
            _userEnter = value;
            OnPropertyChanged(nameof(UserEnter));
        }
    }

    private ObservableCollection<Product> _products;
    public ObservableCollection<Product> Products 
    { 
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged(nameof(Products));
        }
    }

    public MainViewModel() 
    {
        using (DataBase db = new())
        {
            Products = new ObservableCollection<Product>();
            Products.AddRange(db.Products.ToList());
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
