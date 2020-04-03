using System.Timers;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public enum GameState
    {
        PLAYING,
        ENDED
    }

    public enum TimerState
    {
        RUNNING,
        STOPPED
    }

    public class HomePageViewModel : BaseViewModel
    {
        private int _countseconds = 1800;
        public GameState _gameState = GameState.PLAYING;
        private TimerState _timerState = TimerState.STOPPED;
        private Timer _timer = new Timer();
        public Command StartGameCommand => new Command(ExecuteStartGameTimer);

        public HomePageViewModel()
        {
            _timer.Elapsed += TimerElapsedEvent;

            ButtonText = "START";
            // Set default timer text on launch
            TimerText = "30:00";
        }

        #region Properties
        string _timerText;
        public string TimerText
        {
            get => _timerText;
            set
            {
                _timerText = value;
                OnPropertyChanged();
            }
        }

        string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            _countseconds--;
            DisplayTimeFormat();
            if (_countseconds == 0)
            {
                _timer.Stop();
                RunTimerCountDown();
                _timer.Start();
            }
        }

        private string DisplayTimeFormat()
        {
            int mins = _countseconds / 60;
            int seconds = _countseconds - mins * 60;
            return string.Format("{0}:{1}", mins.ToString("00"), seconds.ToString("00"));
        }

        private void ExecuteStartGameTimer()
        {
            if (_timerState == TimerState.STOPPED)
            {
                _timer.Start();
                _timerState = TimerState.RUNNING;
                ButtonText = "START";
            }
            else
            {
                _timer.Stop();
                _timerState = TimerState.STOPPED;
                RunTimerCountDown();
                ButtonText = "STOP";
                TimerText = DisplayTimeFormat();
            }
        }

        private void RunTimerCountDown()
        {
            switch (_gameState)
            {
                case GameState.PLAYING:
                    _countseconds--;
                    break;
                case GameState.ENDED:
                    break;
                default:
                    break;
            }
        }
    }
}