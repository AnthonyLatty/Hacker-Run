using HackerRun.Shared.Views;
using Xamarin.Forms;

namespace HackerRun.Shared
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Initialize Material plugin
            XF.Material.Forms.Material.Init(this);

            MainPage = new NavigationPage(new IntroPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}