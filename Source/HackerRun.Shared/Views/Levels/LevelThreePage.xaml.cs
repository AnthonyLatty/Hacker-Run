using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views.Levels
{
    public partial class LevelThreePage : ContentPage
    {
        public LevelThreePage()
        {
            InitializeComponent();
            BindingContext = new LevelThreePageViewModel(Navigation);
        }
    }
}