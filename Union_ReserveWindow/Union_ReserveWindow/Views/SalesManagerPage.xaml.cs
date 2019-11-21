using System;

using Union_ReserveWindow.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Union_ReserveWindow.Views
{
    public sealed partial class SalesManagerPage : Page
    {
        private SalesManagerViewModel ViewModel => DataContext as SalesManagerViewModel;

        public SalesManagerPage()
        {
            InitializeComponent();
        }
    }
}
