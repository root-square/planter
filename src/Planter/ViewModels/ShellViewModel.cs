using CommunityToolkit.Mvvm.Messaging;
using Planter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planter.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private string _navigationSource = string.Empty;

        public string NavigationSource
        {
            get => _navigationSource;
            set => SetProperty(ref _navigationSource, value);
        }

        private bool _isDialogOpen = false;

        public bool IsDialogOpen
        {
            get => _isDialogOpen;
            set => SetProperty(ref _isDialogOpen, value);
        }

        public ShellViewModel()
        {
            Title = "Shell Window";
            Description = "The main window which provides a navigation frame";

            Initialize();
        }

        private void Initialize()
        {
            // Sets the start-up page.
            NavigationSource = "./Views/Pages/LandingPage.xaml";

            // Subscribes the messenger to get navigation messages.
            WeakReferenceMessenger.Default.Register<NavigationMessage>(this, (recipient, message) =>
            {
                NavigationSource = message.Value;
            });
        }
    }
}
