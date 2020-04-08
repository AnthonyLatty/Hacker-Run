using HackerRun.Shared.Views.Levels;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class IntroPageViewModel : BaseViewModel
    {
        public Command StartGameCommand => new Command(ExecuteStartGameTimer);

        public IntroPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private void ExecuteStartGameTimer()
        {
            Navigation.PushAsync(new LevelOnePage());
        }
    }
}