using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using HackerRun.Shared.Views;
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

    public enum GameplayLevelStatus
    {
        Waiting,
        LevelOneCompleted,
        LevelTwoCompleted,
        LevelThreeCompleted
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        // Navigation property inherited in view models
        public INavigation Navigation { get; set; }

        public int delayTime = 5;
        public GameplayLevelStatus _gameplayLevelStatus = GameplayLevelStatus.Waiting;
        public GameState _gameState = GameState.PLAYING;
        public TimerState _timerState = TimerState.STOPPED;
        public Timer _timer = new Timer();

        public BaseViewModel()
        {
            // Adds interval to seconds
            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsedEvent;
        }

        #region Properties
        int _countSeconds;
        public int CountSeconds
        {
            get => _countSeconds;
            set
            {
                _countSeconds = value;
                OnPropertyChanged();
            }
        }

        int _updatedTimeWithDelay;
        public int UpdatedTimeWithDelay
        {
            get => _updatedTimeWithDelay;
            set
            {
                _updatedTimeWithDelay = value;
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
            CountSeconds--;
            TimerText = DisplayTimeFormat();
            if (CountSeconds == 0)
            {
                _timer.Stop();
                _gameState = GameState.ENDED;
                RunTimerCountDown();
            }
            else if (_gameplayLevelStatus == GameplayLevelStatus.LevelThreeCompleted)
            {
                _timer.Stop();
                _gameState = GameState.ENDED;
                RunTimerCountDown();
            }
        }

        public void RunTimerCountDown()
        {
            // Gets current MainPage type when in ViewModel
            var currentPage = App.Current.MainPage?.GetType();

            switch (_gameState)
            {
                case GameState.PLAYING:
                    CountSeconds--;
                    break;
                case GameState.ENDED:
                    switch (_gameplayLevelStatus)
                    {
                        case GameplayLevelStatus.LevelOneCompleted:
                            // Display Game over page
                            if (currentPage == null || currentPage != typeof(GameOverPage))
                            {
                                App.Current.MainPage = new GameOverPage();
                            }
                            break;
                        case GameplayLevelStatus.LevelTwoCompleted:
                            if (currentPage == null || currentPage != typeof(GameOverPage))
                            {
                                App.Current.MainPage = new GameOverPage();
                            }
                            break;
                        case GameplayLevelStatus.LevelThreeCompleted:
                            // Display rewards page
                            if (currentPage == null || currentPage != typeof(RewardsPage))
                            {
                                App.Current.MainPage = new RewardsPage();
                            }
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public string DisplayTimeFormat()
        {
            int mins = CountSeconds / 60;
            int seconds = CountSeconds - mins * 60;
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