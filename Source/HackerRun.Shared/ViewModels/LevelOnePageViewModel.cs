using HackerRun.Shared.Views.Levels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class LevelOnePageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        public Command NavigateToLevelTwoCommand => new Command(ExecuteLevelTwoNavigation);

        public LevelOnePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private void ExecuteAppearingCommand()
        {
            if (_timerState == TimerState.STOPPED)
            {
                CountSeconds = 1800;
                _timer.Start();
                _timerState = TimerState.RUNNING;
                RunTimerCountDown();
                TimerText = DisplayTimeFormat();
            }
        }

        private void ExecuteLevelTwoNavigation()
        {
            // Save current count seconds
            Preferences.Set("current_count_seconds", CountSeconds);
            Navigation.PushAsync(new LevelTwoPage());
        }
    }
}