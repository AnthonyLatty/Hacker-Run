using Xamarin.Forms;

namespace HackerRun.Shared.ViewModels
{
    public class LevelOnePageViewModel : BaseViewModel
    {
        public Command NavigateToLevelTwoCommand => new Command(ExecuteLevelTwoNavigation);

        public LevelOnePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private void ExecuteLevelTwoNavigation()
        {
            // Hide level 1
            IsLevelOneVisible = false;

            // Show level 2
            IsLevelTwoVisible = true;
        }
    }
}