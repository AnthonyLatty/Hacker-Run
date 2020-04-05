using HackerRun.Shared.Views;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public Command StartGameCommand => new Command(ExecuteStartGameTimer);

        public HomePageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            // Set default timer text on launch
            TimerText = "30:00";
        }

        private void ExecuteStartGameTimer()
        {
            Navigation.PushAsync(new PhaseOnePage());
        }
    }
}