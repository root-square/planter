using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Planter.Helpers;
using Planter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Planter.ViewModels.Pages
{
    public class TargetSelectorViewModel : ViewModelBase
    {
        private string _targetPathA = string.Empty;
        
        public string TargetPathA
        {
            get => _targetPathA;
            set => SetProperty(ref _targetPathA, value);
        }

        private string _targetPathB = string.Empty;

        public string TargetPathB
        {
            get => _targetPathB;
            set => SetProperty(ref _targetPathB, value);
        }

        // T : A / F : B
        private bool _baseTarget = true;

        public bool BaseTarget
        {
            get => _baseTarget;
            set => SetProperty(ref _baseTarget, value);
        }

        public ICommand ExploreCommand { get; private set; }

        public ICommand NavigateToPrevInteractionCommand { get; private set; }

        public ICommand NavigateToNextInteractionCommand { get; private set; }

        public TargetSelectorViewModel()
        {
            Title = LocalizationHelper.GetText("TARGET_SELECTOR_PAGE_TITLE");
            Description = LocalizationHelper.GetText("TARGET_SELECTOR_PAGE_DESC");

            ExploreCommand = new RelayCommand<string>(OnExploring);
            NavigateToPrevInteractionCommand = new RelayCommand(OnNavigatingToPrevInteraction);
            NavigateToNextInteractionCommand = new RelayCommand(OnNavigatingToNextInteraction);
        }

        private void OnExploring(string? path)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;

            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok && dialog.FileName != null)
            {
                if (string.Compare(path, "TARGET_A", true) == 0)
                {
                    TargetPathA = dialog.FileName;
                }
                else if (string.Compare(path, "TARGET_B", true) == 0)
                {
                    TargetPathB = dialog.FileName;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void OnNavigatingToPrevInteraction()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("./Views/Pages/LandingPage.xaml"));
        }

        private void OnNavigatingToNextInteraction()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("./Views/Pages/FileMatcherPage.xaml"));
        }
    }
}
