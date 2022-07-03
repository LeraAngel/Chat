using Xamarin.Forms;

namespace Chatik
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ChatClient.Instance.Initialize();
            MainPage = new NavigationPage(new LoginPage())
            {
                BarTextColor= Color.White,
                BarBackgroundColor= Color.DarkOrange,
            };
        }

        protected override void OnStart(){}

        protected override void OnSleep(){}

        protected override void OnResume(){}
    }
}
