using Xamarin.Forms;
using HackerRun.Shared.ViewModels;

namespace HackerRun.Shared.Views
{
    public partial class RewardsPage : ContentPage
    {
        public RewardsPage()
        {
            InitializeComponent();

            BindingContext = new RewardsPageViewModel(Navigation);
        }
    }
}