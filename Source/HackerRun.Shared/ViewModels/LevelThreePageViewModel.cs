﻿using System;
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
        #endregion

        private bool CanExecuteNavigateToFinalCommand()
        {
            return !string.IsNullOrEmpty(_questionOne) && !string.IsNullOrEmpty(_questionTwoOptions) && !string.IsNullOrEmpty(_questionThreeOptions);
        }

        private async void ExecuteFinalNavigation() 
        {
            string correctQuestionOneAnswer = "retrieve information";
            string correctQuestionTwoAnswer = "C. access codes or passwords";
            string correctQuestionThreeAnswer = "E. phone list or organizational chart";


            if (QuestionOne == correctQuestionOneAnswer && QuestionTwoOptions==correctQuestionTwoAnswer && QuestionThreeOptions==correctQuestionThreeAnswer)
            {
                // Save current count seconds
                Preferences.Set("current_count_seconds", CountSeconds);
                // Save current timer text
                Preferences.Set("current_timer", TimerText);

                using (UserDialogs.Instance.Loading("PROCESSING RESULTS"))
                {
                    _timer.Stop();

                    await Task.Delay(TimeSpan.FromSeconds(delayTime));

                    await Navigation.PushAsync(new RewardsPage());
                }
            }
            else
            {
                UserDialogs.Instance.Alert("One or more of your response is incorrect, hurry up and check your answers before time runs out ⏰", "Oops 🤕", "Ok");
            }
        }
    }
}