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

            NavigateToGitHubCommand = new RelayCommand(OnNavigateToGitHub);
            NavigateToGitHubReleasesCommand = new RelayCommand(OnNavigateToGitHubReleases);
            NavigateToUserManualCommand = new RelayCommand(OnNavigateToUserManual);
            NavigateToNextInteractionCommand = new RelayCommand(OnNavigateToNextInteraction);
        }

        private void OnNavigateToGitHub()
        {
            UriHelper.Open("https://github.com/root-square/planter");
        }

        private void OnNavigateToGitHubReleases()
        {
            UriHelper.Open("https://github.com/root-square/planter/releases");
        }

        private void OnNavigateToUserManual()
        {
            UriHelper.Open("https://github.com/root-square/planter");
        }

        private void OnNavigateToNextInteraction()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("./Views/Pages/FileSelectorPage.xaml"));
        }
    }
}
