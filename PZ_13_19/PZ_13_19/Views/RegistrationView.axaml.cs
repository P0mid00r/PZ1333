using Avalonia.Controls;
using MsBox.Avalonia;
using PZ_13_19.Models;
using PZ_13_19.ViewModels;
using System.Linq;
using static PZ_13_19.Models.Navigation;

namespace PZ_13_19.Views
{
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private async void ButtonRegistration_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (fioTextBlock?.Text?.Trim() != "" && loginTextBlock?.Text?.Trim() != "" && passwordTextBlock?.Text?.Trim() != "")
            {
                using DataBase db = new();
                db.Users.Add(new User()
                {
                    FIO = fioTextBlock.Text,
                    Login = loginTextBlock.Text,
                    Password = passwordTextBlock.Text,
                    Access = (Access)comboBoxAccess.SelectedIndex
                });
                db.SaveChanges();
                
                fioTextBlock.Clear();
                loginTextBlock.Clear();
                passwordTextBlock.Clear();

                await MessageBoxManager.GetMessageBoxStandard(title: "Оповещение", text: "Вы успешно зарегистрировались!", icon: MsBox.Avalonia.Enums.Icon.Success).ShowAsPopupAsync(this);
                Navigation.SetPage(Page.Authorization);
            }
            else await MessageBoxManager.GetMessageBoxStandard(title: "Ошибка", text: "Вы не заполнили все поля!", icon: MsBox.Avalonia.Enums.Icon.Error).ShowAsPopupAsync(this);
        }

        private void ButtonClose_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Navigation.SetPage(Page.Authorization);
        }
    }
}
