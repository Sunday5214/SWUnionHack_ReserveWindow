using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Union_ReserveWindow.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataSquareControl : Page
    {
        public DataSquareControl()
        {
            this.InitializeComponent();
            Loaded += DataSquareControl_Loaded;
        }

        private void DataSquareControl_Loaded(object sender, RoutedEventArgs e)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(ImagePath,UriKind.RelativeOrAbsolute));
            TextBlock text = new TextBlock();
            text.Text = MarketName;
            TextBlock address = new TextBlock();
            address.Text = Address;
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(text);
            stackPanel.Children.Add(address);
            
            
            GridMy.Children.Add(stackPanel);
        }
        #region DP
        public static readonly DependencyProperty MarketNameProperty =
        DependencyProperty.Register
        (
            "MarketName",
            typeof(string),
            typeof(DataSquareControl),
            new PropertyMetadata
            (
                null,
                new PropertyChangedCallback(MarketNameChanged)
            )
        );

        public string MarketName
        {
            get
            {
                return (string)GetValue(MarketNameProperty);
            }
            set
            {
                SetValue(MarketNameProperty, value);
            }
        }

        private static void MarketNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public static readonly DependencyProperty AddressProperty =
        DependencyProperty.Register
        (
            "Address",
            typeof(string),
            typeof(DataSquareControl),
            new PropertyMetadata
            (
                null,
                new PropertyChangedCallback(AddressChanged)
            )
        );

        public string Address
        {
            get
            {
                return (string)GetValue(AddressProperty);
            }
            set
            {
                SetValue(AddressProperty, value);
            }
        }

        private static void AddressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register
            (
                "ImagePath",
                typeof(string),
                typeof(DataSquareControl),
                new PropertyMetadata
                (
                    null,
                    new PropertyChangedCallback(ImagePathChange)
                )
            );

        public string ImagePath
        {
            get
            {
                return (string)GetValue(ImagePathProperty);
            }
            set
            {
                SetValue(ImagePathProperty, value);
            }
        }

        private static void ImagePathChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }
        #endregion
    }
}
