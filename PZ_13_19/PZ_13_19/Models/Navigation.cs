using Avalonia.Controls;
using PZ_13_19.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_13_19.Models
{
    public static class Navigation
    {
        private static AutorizationView autorizationView;
        private static RegistrationView registrationView;
        //private static ProductListView productListView;
        private static ProductAddView productAddView;

        public static void SetPage(Page page)
        {
            MainWindow.Context.Content = page switch
            {
                Page.Authorization => autorizationView ??= new AutorizationView(),
                Page.Registration => registrationView ??= new RegistrationView(),
                Page.ProductList => new ProductListView(),
                Page.ProductAdd => productAddView ??= new ProductAddView()
            };
        }

        public enum Page
        {
            Authorization,
            Registration,
            ProductList,
            ProductAdd
        }
    }
}
