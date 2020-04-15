using System.Threading.Tasks;
using Acr.UserDialogs;
using HackerRun.Shared.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class LevelThreePageViewModel : BaseViewModel
    {
        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        private Command _navigateToFinalCommand;
        public Command NavigateToFinalCommand => _navigateToFinalCommand ?? (_navigateToFinalCommand = new Command(ExecuteFinalNavigation, CanExecuteNavigateToFinalCommand));

        public LevelThreePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private void ExecuteAppearingCommand()
        {
            var IsUserFailedBefore = Preferences.Get("FailedStatus", true);

            var UserGotBonusQuestion = Preferences.Get("GotBonusQuestion", true);

            if (IsUserFailedBefore)
            {
                // Increase timer speed
                _timer.Interval = LevelTwoPenaltyTime;
                DisplayCounter();
            }

            if (IsUserFailedBefore && UserGotBonusQuestion)
            {
                // users who got the bonus question correct
                _timer.Interval = NormalTimerInterval;
                DisplayCounter();
            }
            else
            {
                // Increase timer speed
                _timer.Interval = LevelTwoPenaltyTime;
                DisplayCounter();
            }
        }

        private void DisplayCounter()
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
        private string _questionOne;
        public string QuestionOne
        {
            get => _questionOne;
            set
            {
                _questionOne = value;
                OnPropertyChanged();
                NavigateToFinalCommand.ChangeCanExecute();
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
                NavigateToFinalCommand.ChangeCanExecute();
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
                NavigateToFinalCommand.ChangeCanExecute();
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
                NavigateToFinalCommand.ChangeCanExecute();
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
                NavigateToFinalCommand.ChangeCanExecute();
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
                NavigateToFinalCommand.ChangeCanExecute();
            }
        }

        private string _questionSevenOptions;
        public string QuestionSevenOptions
        {
            get => _questionSevenOptions;
            set
            {
                _questionSevenOptions = value;
                OnPropertyChanged();
                NavigateToFinalCommand.ChangeCanExecute();
            }
        }

        private string _questionEightOptions;
        public string QuestionEightOptions
        {
            get => _questionEightOptions;
            set
            {
                _questionEightOptions = value;
                OnPropertyChanged();
                NavigateToFinalCommand.ChangeCanExecute();
            }
        }

        private string _questionNineOptions;
        public string QuestionNineOptions
        {
            get => _questionNineOptions;
            set
            {
                _questionNineOptions = value;
                OnPropertyChanged();
                NavigateToFinalCommand.ChangeCanExecute();
            }
        }

        private string _questionTenOptions;
        public string QuestionTenOptions
        {
            get => _questionTenOptions;
            set
            {
                _questionTenOptions = value;
                OnPropertyChanged();
                NavigateToFinalCommand.ChangeCanExecute();
            }
        }
        #endregion

        private bool CanExecuteNavigateToFinalCommand()
        {
            return !string.IsNullOrEmpty(_questionOne) && !string.IsNullOrEmpty(_questionTwoOptions) && !string.IsNullOrEmpty(_questionThreeOptions) && !string.IsNullOrEmpty(_questionFiveOptions) && !string.IsNullOrEmpty(_questionSixOptions) && !string.IsNullOrEmpty(_questionSevenOptions) && !string.IsNullOrEmpty(_questionEightOptions) && !string.IsNullOrEmpty(_questionNineOptions) && !string.IsNullOrEmpty(_questionTenOptions);
        }

        private async void ExecuteFinalNavigation() 
        {
            string correctQuestionOneAnswer = "retrieve information";
            string correctQuestionTwoAnswer = "C. access codes or passwords";
            string correctQuestionThreeAnswer = "E. phone list or organizational chart";
            string correctQuestionFourAnswer = "A. Shred or burn documents";
            string correctQuestionFiveAnswer = "D. All of The Above";
            string correctQuestionSixAnswer = "D. All of The Above";
            string correctQuestionSevenAnswer = "C. Both A and B";
            string correctQuestionEightAnswer = "A. Content, Context, User";
            string correctQuestionNineAnswer = "D. All of The Above";
            string correctQuestionTenAnswer = "A. Paper Wrappers (Ketchup Packets)";


            if (QuestionOne == correctQuestionOneAnswer && QuestionTwoOptions == correctQuestionTwoAnswer && QuestionThreeOptions == correctQuestionThreeAnswer && QuestionFourOptions == correctQuestionFourAnswer && QuestionFiveOptions == correctQuestionFiveAnswer && QuestionSixOptions == correctQuestionSixAnswer && QuestionSevenOptions == correctQuestionSevenAnswer && QuestionEightOptions == correctQuestionEightAnswer && QuestionNineOptions == correctQuestionNineAnswer && QuestionTenOptions == correctQuestionTenAnswer)
            {
                // Save current count seconds
                Preferences.Set("current_count_seconds", CountSeconds);
                // Save current timer text
                Preferences.Set("current_timer", TimerText);

                using (UserDialogs.Instance.Loading("PROCESSING RESULTS"))
                {
                    _timer.Stop();

                    await Task.Delay(delayTime);

                    await Navigation.PushAsync(new RewardsPage());
                }
            }
            else
            {
                UserDialogs.Instance.Alert("One or more of your response is incorrect, hurry up and check your answers before time runs out ⏰", "Oops 🤕", "Ok");

                // Increase timer speed
                _timer.Interval = LevelThreePenaltyTime;
            }
        }
    }
}