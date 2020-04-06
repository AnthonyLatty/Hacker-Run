using System.ComponentModel;
using System.Runtime.CompilerServices;
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

    public class BaseViewModel : INotifyPropertyChanged
    {
        // Navigation property inherited in view models
        public INavigation Navigation { get; set; }

        private int _countseconds = 1800;
        public GameState _gameState = GameState.PLAYING;
        public TimerState _timerState = TimerState.STOPPED;
        public Timer _timer = new Timer();

        public BaseViewModel()
        {
            _timer.Elapsed += TimerElapsedEvent;
        }

        #region Properties
        bool _isLevelOneVisible = true;
        public bool IsLevelOneVisible
        {
            get => _isLevelOneVisible;
            set
            {
                _isLevelOneVisible = value;
                OnPropertyChanged();
            }
        }

        bool _isLevelTwoVisible = false;
        public bool IsLevelTwoVisible
        {
            get => _isLevelTwoVisible;
            set
            {
                _isLevelTwoVisible = value;
                OnPropertyChanged();
            }
        }

        bool _isLevelThreeVisible = false;
        public bool IsLevelThreeVisible
        {
            get => _isLevelThreeVisible;
            set
            {
                _isLevelThreeVisible = value;
                OnPropertyChanged();
            }
        }

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
        

        public void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            _countseconds--;
            TimerText = DisplayTimeFormat();
            if (_countseconds == 0)
            {
                _timer.Stop();
                _gameState = GameState.ENDED;
                RunTimerCountDown();
            }
        }

        public void RunTimerCountDown()
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

        public string DisplayTimeFormat()
        {
            int mins = _countseconds / 60;
            int seconds = _countseconds - mins * 60;
            return string.Format("{0}:{1}", mins.ToString("00"), seconds.ToString("00"));
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}