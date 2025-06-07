using EnglishTest.ViewModels;
using System.Windows;

namespace EnglishTest.Views.Forms
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
            _viewModel.InitializeСommand();
        }
    }
}
