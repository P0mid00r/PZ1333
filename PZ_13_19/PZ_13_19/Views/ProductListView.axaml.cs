using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using PZ_13_19.Models;
using PZ_13_19.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using static PZ_13_19.Models.Navigation;

namespace PZ_13_19.Views
{
    public partial class ProductListView : UserControl
    {
        public ProductListView()
        {
            InitializeComponent();

            switch (MainViewModel.Instance.UserEnter.Access)
            {
                case Access.User:
                    buttonAdd.IsEnabled = false;
                    buttonDelete.IsEnabled = false;
                    break;

                case Access.Admin:
                    buttonAdd.IsEnabled = true;
                    buttonDelete.IsEnabled = true;

                    buttonAdd.Click += ButtonAdd_Click;
                    buttonDelete.Click += ButtonDelete_Click;
                    break;
            }
            
            buttonExit.Click += (s, e) => Navigation.SetPage(Page.Authorization);
        }

        private void ButtonAdd_Click(object? sender, RoutedEventArgs e) 
            => Navigation.SetPage(Page.ProductAdd);

        private void ButtonDelete_Click(object? sender, RoutedEventArgs e)
        {
            Product product = productListBox.SelectedItem as Product;
            if (product is not null)
            {
                using DataBase db = new();
                MainViewModel.Instance.Products.Remove(product);
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
