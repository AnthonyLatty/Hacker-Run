using System.Threading.Tasks;
using Acr.UserDialogs;
using HackerRun.Shared.Views.Levels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class LevelOnePageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        private Command _navigateToLevelTwoCommand;
        public Command NavigateToLevelTwoCommand => _navigateToLevelTwoCommand ?? (_navigateToLevelTwoCommand = new Command(ExecuteLevelTwoNavigation, CanExecuteNavigateToLevelTwoCommand));

        public LevelOnePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        #region Public Properties
        private string _questionOneOptions;
        public string QuestionOneOptions
        {
            get => _questionOneOptions;
            set
            {
                _questionOneOptions = value;
                OnPropertyChanged();
                NavigateToLevelTwoCommand.ChangeCanExecute();
            }
        }

        private string _questionTwoOptions;
        public string QuestionTwoOptions
        {
            get => _questionTwoOptions;
            set
            {
                _questionTwoOptions = value;
                OnPropertyChanged();
                NavigateToLevelTwoCommand.ChangeCanExecute();
            }
        }

        private string _questionThreeOptions;
        public string QuestionThreeOptions
        {
            get => _questionThreeOptions;
            set
            {
                _questionThreeOptions = value;
                OnPropertyChanged();
                NavigateToLevelTwoCommand.ChangeCanExecute();
            }
        }
        #endregion

        private void ExecuteAppearingCommand()
        {
            if (_timerState == TimerState.STOPPED)
            {
                CountSeconds = OriginalTime;
                _timer.Start();
                _timerState = TimerState.RUNNING;
                TimerText = DisplayTimeFormat();
            }
        }

        private bool CanExecuteNavigateToLevelTwoCommand()
        {
            return !string.IsNullOrEmpty(_questionOneOptions) && !string.IsNullOrEmpty(_questionTwoOptions) && !string.IsNullOrEmpty(_questionThreeOptions);
        }

        private async void ExecuteLevelTwoNavigation()
        {
            string correctQuestionOneAnswer = "E. All of the above";
            string correctQuestionTwoAnswer = "C. SterlingGmail20.15";
            string correctQuestionThreeAnswer = "D. Use a VPN";

            if (QuestionOneOptions == correctQuestionOneAnswer && QuestionTwoOptions == correctQuestionTwoAnswer && QuestionThreeOptions == correctQuestionThreeAnswer)
            {
                // Save current count seconds
                Preferences.Set("current_count_seconds", CountSeconds);
                // Save current timer text
                Preferences.Set("current_timer", TimerText);

                using (UserDialogs.Instance.Loading("LOADING LEVEL 2"))
                {
                    _timer.Stop();

                    await Task.Delay(delayTime);

                    await Navigation.PushAsync(new LevelTwoPage());
                }
            }
            else
            {
                UserDialogs.Instance.Alert("One or more of your response is incorrect, hurry up and check your answers before time runs out ⏰", "Oops 🤕", "Ok");

                // Set failed status
                Preferences.Set("FailedStatus", true);

                // Increase timer speed
                _timer.Interval = LevelOnePenaltyTime;
            }
        }
    }
}