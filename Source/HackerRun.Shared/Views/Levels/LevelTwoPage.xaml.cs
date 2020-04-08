using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views.Levels
{
    public partial class LevelTwoPage : ContentPage
    {
        public LevelTwoPage()
        {
            InitializeComponent();
            BindingContext = new LevelTwoPageViewModel(Navigation);
        }
    }
}