using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using HackerRun.Shared.Views.Levels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class LevelTwoPageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        private Command _navigateToLevelThreeCommand;
        public Command NavigateToLevelThreeCommand => _navigateToLevelThreeCommand ?? (_navigateToLevelThreeCommand = new Command(ExecuteLevelThreeNavigation, CanExecuteNavigateToLevelThreeCommand));

        public LevelTwoPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private void ExecuteAppearingCommand()
        {
            // Get previous count seconds
            var currentCountSeconds = Preferences.Get("current_count_seconds", CountSeconds);
            // Get previous timer text
            var currentTimer = Preferences.Get("current_timer", TimerText);

            // Assign values from preference
            CountSeconds = currentCountSeconds;
            TimerText = currentTimer;

            if (_timerState == TimerState.STOPPED)
            {
                _timer.Start();
                _timerState = TimerState.RUNNING;
                RunTimerCountDown();
                TimerText = DisplayTimeFormat();
            }
        }

        private bool CanExecuteNavigateToLevelThreeCommand()
        {
            // Add validation check here for each control in level 2
            return true;
        }

        private async void ExecuteLevelThreeNavigation()
        {
            // Do final checks here also to ensure the values passed from the CanExecuteNavigateToLevelThreeCommand method is actually true


            // Save current count seconds
            Preferences.Set("current_count_seconds", CountSeconds);
            // Save current timer text
            Preferences.Set("current_timer", TimerText);

            using (UserDialogs.Instance.Loading("LOADING LEVEL 3"))
            {
                _timer.Stop();
                _gameplayLevelStatus = GameplayLevelStatus.LevelTwoCompleted;

                await Task.Delay(TimeSpan.FromSeconds(delayTime));

                await Navigation.PushAsync(new LevelThreePage());
            }
        }
    }
}