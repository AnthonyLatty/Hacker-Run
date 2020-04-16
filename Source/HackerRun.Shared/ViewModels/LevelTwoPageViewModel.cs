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
                TimerText = DisplayTimeFormat();
            }
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
                NavigateToLevelThreeCommand.ChangeCanExecute();
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
                NavigateToLevelThreeCommand.ChangeCanExecute();
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
                NavigateToLevelThreeCommand.ChangeCanExecute();
            }
        }

        private string _questionFourOptions;
        public string QuestionFourOptions
        {
            get => _questionFourOptions;
            set
            {
                _questionFourOptions = value;
                OnPropertyChanged();
                NavigateToLevelThreeCommand.ChangeCanExecute();
            }
        }

        private string _questionFiveOptions;
        public string QuestionFiveOptions
        {
            get => _questionFiveOptions;
            set
            {
                _questionFiveOptions = value;
                OnPropertyChanged();
                NavigateToLevelThreeCommand.ChangeCanExecute();
            }
        }

        private string _questionSixOptions;
        public string QuestionSixOptions
        {
            get => _questionSixOptions;
            set
            {
                _questionSixOptions = value;
                OnPropertyChanged();
                NavigateToLevelThreeCommand.ChangeCanExecute();
            }
        }

        private string _bonusQuestionOptions;
        public string BonusQuestionOptions
        {
            get => _bonusQuestionOptions;
            set
            {
                _bonusQuestionOptions = value;
                OnPropertyChanged();
                NavigateToLevelThreeCommand.ChangeCanExecute();
            }
        }
        #endregion

        private bool CanExecuteNavigateToLevelThreeCommand()
        {
            return !string.IsNullOrEmpty(_questionOneOptions) && !string.IsNullOrEmpty(_questionTwoOptions) && !string.IsNullOrEmpty(_questionThreeOptions) && !string.IsNullOrEmpty(_questionFourOptions) && !string.IsNullOrEmpty(_questionFiveOptions) && !string.IsNullOrEmpty(_questionSixOptions);
        }

        private async void ExecuteLevelThreeNavigation()
        {
            string correctQuestionOne = "B. Encryption";
            string correctQuestionTwo = "A. Social Engineers";
            string correctQuestionThree = "A. To gain vital personal information";
            string correctQuestionFour = "C. Act first and think later";
            string correctQuestionFive = "D. All of the above";
            string correctQuestionSix = "D. Following employees into restricted areas";

            // Validation without bonus question
            if (QuestionOneOptions == correctQuestionOne && QuestionTwoOptions == correctQuestionTwo && QuestionThreeOptions == correctQuestionThree && QuestionFourOptions == correctQuestionFour && QuestionFiveOptions == correctQuestionFive && QuestionSixOptions == correctQuestionSix)
            {
                // Save current count seconds
                Preferences.Set("current_count_seconds", CountSeconds);
                // Save current timer text
                Preferences.Set("current_timer", TimerText);

                using (UserDialogs.Instance.Loading("LOADING LEVEL 3"))
                {
                    _timer.Stop();

                    await Task.Delay(delayTime);

                    await Navigation.PushAsync(new LevelThreePage());
                }
            }
            else
            {
                UserDialogs.Instance.Alert("One or more of your response is incorrect, hurry up and check your answers before time runs out ⏰", "Oops 🤕", "Ok");

                // Increase timer speed
                _timer.Interval = LevelTwoPenaltyTime;
            }
        }
    }
}