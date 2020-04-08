using HackerRun.Shared.Views.Levels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class LevelTwoPageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        public Command NavigateToLevelThreeCommand => new Command(ExecuteLevelThreeNavigation);

        public LevelTwoPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private void ExecuteAppearingCommand()
        {
            // Get previous count seconds
            var currentCountSeconds = Preferences.Get("current_count_seconds", CountSeconds);

            // Assign new count seconds
            CountSeconds = currentCountSeconds;

            if (_timerState == TimerState.STOPPED)
            {
                _timer.Enabled = true;
                _timerState = TimerState.RUNNING;
                RunTimerCountDown();
                TimerText = DisplayTimeFormat();
            }
        }

        private void ExecuteLevelThreeNavigation()
        {
            // Save current count seconds
            Preferences.Set("current_count_seconds", CountSeconds);
            Navigation.PushAsync(new LevelThreePage());
        }
    }
}