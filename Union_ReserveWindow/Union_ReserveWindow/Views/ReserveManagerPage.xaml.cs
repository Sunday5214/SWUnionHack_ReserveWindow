using System;

using Union_ReserveWindow.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Union_ReserveWindow.Views
{
    public sealed partial class ReserveManagerPage : Page
    {
        private ReserveManagerViewModel ViewModel => DataContext as ReserveManagerViewModel;

        public ReserveManagerPage()
        {
            InitializeComponent();
        }
    }
}
