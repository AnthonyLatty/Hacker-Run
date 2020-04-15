using HackerRun.Shared.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class RewardsPageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        public Command ReturnToHomeCommand => new Command(ExecuteReturnToHomeCommand);

        public RewardsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        string _winningTimeText;
        public string WinningTimeText
        {
            get => _winningTimeText;
            set
            {
                _winningTimeText = value;
                OnPropertyChanged();
            }
        }

        private void ExecuteAppearingCommand()
        {
            // Get previous timer text
            var currentTimer = Preferences.Get("current_timer", TimerText);

            WinningTimeText = currentTimer;
        }

        private void ExecuteReturnToHomeCommand()
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