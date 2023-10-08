using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Planter.Helpers;
using Planter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Planter.ViewModels.Pages
{
    public class LandingViewModel : ViewModelBase
    {
        public ICommand NavigateToGitHubCommand { get; private set; }

        public ICommand NavigateToGitHubReleasesCommand { get; private set; }

        public ICommand NavigateToUserManualCommand { get; private set; }

        public ICommand NavigateToNextInteractionCommand { get; private set; }

        public LandingViewModel()
        {
            Title = "Landing Page";
            Description = "A Planter landing page";

            NavigateToGitHubCommand = new RelayCommand(OnNavigatingToGitHub);
            NavigateToGitHubReleasesCommand = new RelayCommand(OnNavigatingToGitHubReleases);
            NavigateToUserManualCommand = new RelayCommand(OnNavigatingToUserManual);
            NavigateToNextInteractionCommand = new RelayCommand(OnNavigatingToNextInteraction);
        }

        private void OnNavigatingToGitHub()
        {
            UriHelper.Open("https://github.com/root-square/planter");
        }

        private void OnNavigatingToGitHubReleases()
        {
            UriHelper.Open("https://github.com/root-square/planter/releases");
        }

        private void OnNavigatingToUserManual()
        {
            UriHelper.Open("https://github.com/root-square/planter");
        }

        private void OnNavigatingToNextInteraction()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("./Views/Pages/TargetSelectorPage.xaml"));
        }
    }
}
