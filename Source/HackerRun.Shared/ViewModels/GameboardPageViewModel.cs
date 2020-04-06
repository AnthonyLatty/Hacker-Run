using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class GameboardPageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);

        public GameboardPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private void ExecuteAppearingCommand()
        {
            if (_timerState == TimerState.STOPPED)
            {
                _timer.Start();
                _timerState = TimerState.RUNNING;
                RunTimerCountDown();
                TimerText = DisplayTimeFormat();
            }
        }
    }
}