using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views
{
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();

            BindingContext = new IntroPageViewModel(Navigation);
        }
    }
}