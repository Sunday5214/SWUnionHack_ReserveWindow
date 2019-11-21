using System;

using Union_ReserveWindow.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Union_ReserveWindow.Views
{
    public sealed partial class TableManagerPage : Page
    {
        private TableManagerViewModel ViewModel => DataContext as TableManagerViewModel;

        public TableManagerPage()
        {
            InitializeComponent();
        }
    }
}
