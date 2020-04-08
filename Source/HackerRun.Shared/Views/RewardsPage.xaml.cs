using Xamarin.Forms;

namespace HackerRun.Shared.Views
{
    public partial class RewardsPage : ContentPage
    {
        public RewardsPage()
        {
            InitializeComponent();
        }

        void ReturnToHome_Clicked(object sender, System.EventArgs e)
        {
            // Gets current MainPage type
            var currentPage = App.Current.MainPage?.GetType();

            if (currentPage == null || currentPage != typeof(IntroPage))
            {
                App.Current.MainPage = new NavigationPage(new IntroPage());
            }
        }
    }
}