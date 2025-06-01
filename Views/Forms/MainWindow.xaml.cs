using EnglishTest.ViewModels;
using System.Windows;

namespace EnglishTest.Views.Forms
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
            _viewModel.InitializeСommand(ShowPage);   
        }
    }
}
