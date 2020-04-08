using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views.Levels
{
    public partial class LevelOnePage : ContentPage
    {
        public LevelOnePage()
        {
            InitializeComponent();
            BindingContext = new LevelOnePageViewModel(Navigation);
        }
    }
}