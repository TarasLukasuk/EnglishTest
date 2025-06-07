using EnglishTest.ViewModels;
using System.Windows;

namespace EnglishTest.Views.Forms
{
    public partial class VerificationWindow : Window
    {
        private MainViewModel _viewModel = new();

        public VerificationWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
            _viewModel.InitializeСommand();
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e) => PasswordWatermark.Visibility = string.IsNullOrEmpty(Password.Password) ? Visibility.Visible : Visibility.Collapsed;
    }
}
