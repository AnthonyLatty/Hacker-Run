using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class PhaseOnePageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        public Command DisappearingCommand => new Command(ExecuteDisappearingCommand);

        public PhaseOnePageViewModel(INavigation navigation)
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

        private void ExecuteDisappearingCommand()
        {
            //...
        }
    }
}