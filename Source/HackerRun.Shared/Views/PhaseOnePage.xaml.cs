using HackerRun.Shared.ViewModels;
using Xamarin.Forms;

namespace HackerRun.Shared.Views
{
    public partial class PhaseOnePage : ContentPage
    {
        public PhaseOnePage()
        {
            InitializeComponent();

            BindingContext = new PhaseOnePageViewModel(Navigation);
        }
    }
}