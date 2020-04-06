using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views
{
    public partial class GameboardPage : ContentPage
    {
        public GameboardPage()
        {
            InitializeComponent();
            BindingContext = new GameboardPageViewModel(Navigation);
        }
    }
}