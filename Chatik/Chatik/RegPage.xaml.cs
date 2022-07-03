using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chatik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPage : ContentPage
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private async void RequestRegister(string username, string password)
        {
            ServerStatus result = await ChatClient.Instance.Register(username, password);

            switch (result)
            {
                case ServerStatus.SUCCESS:
                    await DisplayAlert("Завершено", "Регистрация успешна", "Войти");
                    await Navigation.PopAsync();
                    break;
                case ServerStatus.ERROR_REG_LOGIN_EXISTS:
                    await DisplayAlert("Ошибка", "Логин уже существует", "Закрыть");
                    break;
                case ServerStatus.ERROR_UNKNOWN:
                    await DisplayAlert("Ошибка", "Неизвестная ошибка", "Закрыть");
                    break;
                default:
                    break;
            }
        }

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            if (usernameEntry.Text == null || usernameEntry.Text.Length == 0)
            {
                DisplayAlert("Ошибка", "Имя не может быть пустым", "Закрыть");
                return;
            }

            if (passwordEntry.Text == null || passwordEntry.Text.Length == 0)
            {
                DisplayAlert("Ошибка", "Пароль не может быть пустым", "Закрыть");
                return;
            }

            if (passwordEntry.Text != passwordCheckEntry.Text)
            {
                DisplayAlert("Ошибка", "Пароли не совпадают", "Закрыть");
                return;
            }

            RequestRegister(usernameEntry.Text, passwordEntry.Text);
        }
    }
}