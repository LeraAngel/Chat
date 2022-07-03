using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chatik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void RequestLogin(string username, string password)
        {
            ServerStatus result = await ChatClient.Instance.Login(username, password);

            switch (result)
            {
                case ServerStatus.SUCCESS:
                    await Navigation.PushAsync(new ChatPage());
                    break;
                case ServerStatus.ERROR_LOGIN_BAD_LOGIN:
                    await DisplayAlert("Ошибка", "Неверный логин или пароль", "Закрыть");
                    break;
                case ServerStatus.ERROR_UNKNOWN:
                    await DisplayAlert("Ошибка", "Неизвесная ошибка", "Закрыть");
                    break;
                default:
                    break;
            }
        }

        private void OnButtonLoginClicked(object sender, EventArgs e)
        {
            if (usernameEntry.Text == null || usernameEntry.Text.Length == 0)
            {
                DisplayAlert("Ошибка", "Введите логин", "Закрыть");
                return;
            }

            if (passwordEntry.Text == null || passwordEntry.Text.Length == 0)
            {
                DisplayAlert("Ошибка", "Введите пароль", "Закрыть");
                return;
            }

            RequestLogin(usernameEntry.Text, passwordEntry.Text);
        }

        private void OnButtonSignUpClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegPage());
        }
    }
}