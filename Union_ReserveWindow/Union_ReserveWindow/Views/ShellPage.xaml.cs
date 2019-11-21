using System;

using Union_ReserveWindow.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Union_ReserveWindow.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        private ShellViewModel ViewModel => DataContext as ShellViewModel;

        public Frame ShellFrame => shellFrame;

        public ShellPage()
        {
            InitializeComponent();
            App.connecter.CompleteAction += Connecter_CompleteAction;
        }

        private void Connecter_CompleteAction(object sender, int data)
        {
            App.market.GetDataAsync();
            this.navigationView.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        public void SetRootFrame(Frame frame)
        {
            shellFrame.Content = frame;
            navigationViewHeaderBehavior.Initialize(frame);
            ViewModel.Initialize(frame, navigationView);
        }
    }
}
