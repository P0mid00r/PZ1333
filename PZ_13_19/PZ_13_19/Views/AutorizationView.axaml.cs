using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Models;
using PZ_13_19.Models;
using PZ_13_19.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static PZ_13_19.Models.Navigation;

namespace PZ_13_19.Views
{
    public partial class AutorizationView : UserControl
    {
        public AutorizationView()
        {
            InitializeComponent();
        }

        public async void CheckInDataBase()
        {
            if (loginTextBlock?.Text?.Trim() != "" && passwordTextBlock?.Text?.Trim() != "")
            {
                using DataBase db = new();
                User user = db.Users.Where(user => user.Login == loginTextBlock.Text && user.Password == passwordTextBlock.Text).FirstOrDefault();
                if (user is not null)
                {
                    await MessageBoxManager.GetMessageBoxStandard(
                        title: "Оповещение", 
                        text: "Вы успешно вошли в систему!", 
                        icon: MsBox.Avalonia.Enums.Icon.Success).ShowAsPopupAsync(this);

                    loginTextBlock.Clear();
                    passwordTextBlock.Clear();

                    MainViewModel.Instance.UserEnter = user;
                    Navigation.SetPage(Page.ProductList);
                }
                else
                {
                    await MessageBoxManager.GetMessageBoxStandard(
                        title: "Ошибка",
                        text: "Вы не правильно ввели логин или пароль, повторите попытку через 10 секунд!", 
                        icon: MsBox.Avalonia.Enums.Icon.Error
                        ).ShowAsPopupAsync(this);
                }
            }
            else await MessageBoxManager.GetMessageBoxStandard(
                title: "Ошибка", 
                text: "Вы не заполнили все поля!", 
                icon: MsBox.Avalonia.Enums.Icon.Error
                ).ShowAsPopupAsync(this);
        }

        private void ButtonEnter_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
            => CheckInDataBase();

        private void ButtonRegistration_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
            => Navigation.SetPage(Page.Registration);
    }
}
