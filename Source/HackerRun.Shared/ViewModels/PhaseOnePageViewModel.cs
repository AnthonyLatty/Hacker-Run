using HackerRun.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace HackerRun.Shared.ViewModels
{
    public class PhaseOnePageViewModel : BaseViewModel
    {
        public List<string> Options { get; set; }

        public Command AppearingCommand => new Command(ExecuteAppearingCommand);
        public Command DisappearingCommand => new Command(ExecuteDisappearingCommand);

        public PhaseOnePageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            PopulateOptions();
        }

        private void PopulateOptions()
        {
            Options = new List<string>()
            {
                "A. The message is sent from a public email domain",
                "B. The domain name is misspelled",
                "C. The email is poorly written",
                "D. It includes suspicious attachments or links",
                "E. All of the above( correct answer)"
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