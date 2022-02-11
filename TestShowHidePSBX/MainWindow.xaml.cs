namespace TestShowHidePSBX
{
    using System;
    using System.Windows;
    using System.IO;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;

    public partial class MainWindow : Window
    {

        private readonly BitmapImage showImage = new BitmapImage(
            new Uri(Path.Combine("/", "Resources", "Show.jpg"), UriKind.Relative));
        private readonly BitmapImage hideImage = new BitmapImage(
            new Uri(Path.Combine("/", "Resources", "Hide.jpg"), UriKind.Relative));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }

        private void ShowPassword()
        {
            ImgShowHide.Source = hideImage;
            txtVisiblePasswordbox.Visibility = Visibility.Visible;
            txtPasswordbox.Visibility = Visibility.Collapsed;
            txtVisiblePasswordbox.Text = txtPasswordbox.Password;
        }

        private void HidePassword()
        {
            ImgShowHide.Source = showImage;
            txtVisiblePasswordbox.Visibility = Visibility.Collapsed;
            txtPasswordbox.Visibility = Visibility.Visible;
            txtPasswordbox.Focus();
        }

        private void txtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPasswordbox.Password.Length > 0)
            {
                ImgShowHide.Visibility = Visibility.Visible;
                HidePassword();
            }
            else
            {
                ImgShowHide.Visibility = Visibility.Collapsed;
            }
        }
    }
}
