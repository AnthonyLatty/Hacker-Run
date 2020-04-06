using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views.Levels
{
    public partial class LevelOnePage : ContentView
    {
        public LevelOnePage()
        {
            InitializeComponent();
            BindingContext = new LevelOnePageViewModel(Navigation);
        }
    }
}