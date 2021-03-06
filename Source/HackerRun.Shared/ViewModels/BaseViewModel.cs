﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using HackerRun.Shared.Views;
using Xamarin.Essentials;
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

        public int LevelOnePenaltyTime = 150;
        public int LevelTwoPenaltyTime = 100;
        public int LevelThreePenaltyTime = 70;
        public int NormalTimerInterval = 1000;
        public int OriginalTime = 1800;
        public int delayTime = 2000;
        public GameState _gameState = GameState.PLAYING;
        public TimerState _timerState = TimerState.STOPPED;
        public Timer _timer = new Timer();

        public BaseViewModel()
        {
            // Adds interval to seconds
            _timer.Interval = NormalTimerInterval;
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
        #endregion
        

        public void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            CountSeconds--;
            TimerText = DisplayTimeFormat();
            if (CountSeconds == 0)
            {
                _timer.Stop();
                _gameState = GameState.ENDED;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Gets current MainPage type
                    var currentPage = App.Current.MainPage?.GetType();

                    if (currentPage != typeof(GameOverPage))
                    {
                        Application.Current.MainPage = new NavigationPage(new GameOverPage());
                    }
                });
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