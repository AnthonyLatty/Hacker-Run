using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomePageViewModel();
        }
    }
}