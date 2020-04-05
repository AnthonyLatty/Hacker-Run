using HackerRun.Shared.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace HackerRun.Shared.ViewModels
{
    public class PhaseOnePageViewModel : BaseViewModel
    {
        public ObservableCollection<EmailOptions> Options { get; set; }

        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        public Command DisappearingCommand => new Command(ExecuteDisappearingCommand);

        public PhaseOnePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            populateEmail();
        }

        private void populateEmail()
        {
            Options = new ObservableCollection<EmailOptions>()
            {
                new EmailOptions
                {
                    OptionTitle="The message is sent from a public email domain"
                },

                new EmailOptions
                {
                    OptionTitle="The domain name is misspelled"
                },

                new EmailOptions
                {
                    OptionTitle="The email is poorly written"
                },

                new EmailOptions
                {
                    OptionTitle="It includes suspicious attachments or links"
                },

                new EmailOptions
                {
                    OptionTitle="All of the above( correct answer)"
                }
            };
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

        
        

        //public List<string> Images { get; set; }
    }
}