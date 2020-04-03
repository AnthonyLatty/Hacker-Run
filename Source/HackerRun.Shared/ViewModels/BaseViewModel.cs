using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Navigation property inherited in view models
        public INavigation Navigation { get; set; }

        public BaseViewModel()
        {
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