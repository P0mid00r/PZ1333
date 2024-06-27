using Avalonia.Controls;
using MsBox.Avalonia;
using PZ_13_19.Models;
using PZ_13_19.ViewModels;
using static PZ_13_19.Models.Navigation;

namespace PZ_13_19.Views
{
    public partial class ProductAddView : UserControl
    {
        public ProductAddView()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
            => Navigation.SetPage(Page.ProductList);

        private async void ButtonAddProduct_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (nameTextBlock.Text.Trim() != "" 
                && descriptionTextBlock.Text.Trim() != "" 
                && priceTextBlock.Text.Trim() != "" 
                && countTextBlock.Text.Trim() != ""
                )
            {
                using DataBase db = new DataBase();
                Product product = new Product()
                {
                    Name = nameTextBlock.Text,
                    Description = descriptionTextBlock.Text,
                    Price = float.Parse(priceTextBlock.Text),
                    Count = int.Parse(countTextBlock.Text),
                    Image = new byte[100] // Заглушка
                };
                db.Products.Add(product);
                MainViewModel.Instance.Products.Add(product);
                db.SaveChanges();

                nameTextBlock.Clear();
                descriptionTextBlock.Clear();
                priceTextBlock.Clear();
                countTextBlock.Clear();

                await MessageBoxManager.GetMessageBoxStandard(title: "Успешно", text: "Товар успешно добавлен!", icon: MsBox.Avalonia.Enums.Icon.Success).ShowAsPopupAsync(this);
            }
        }
    }
}
