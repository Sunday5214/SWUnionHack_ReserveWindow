using System;

using Union_ReserveWindow.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Union_ReserveWindow.Views
{
    public sealed partial class MarketManagerPage : Page
    {
        //private MarketManagerViewModel ViewModel => DataContext as MarketManagerViewModel;

        public MarketManagerPage()
        {
            InitializeComponent();
            Loaded += MarketManagerPage_Loaded;
        }

        private void MarketManagerPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DataContext = App.market;
        }
    }
}
