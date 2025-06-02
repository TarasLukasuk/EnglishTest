using EnglishTest.Services;
using System.Windows;
using System.Windows.Input;

namespace EnglishTest.Commands
{
    internal sealed class ShowPageCommand : ICommand
    {
        private readonly CacheWindow _cacheWindow = new();

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return parameter is Type windowType && typeof(Window).IsAssignableFrom(windowType);
        }

        public void Execute(object? parameter)
        {
            if (parameter is not Type windowType)
                return;

            string windowName = windowType.Name;

            Window? windowInstance = Activator.CreateInstance(windowType) as Window;

            try
            {
                _cacheWindow.GetCache(windowName).Show();
            }
            catch (Exception)
            {
                _cacheWindow.CreateCache(windowName, windowInstance);
                _cacheWindow.GetCache(windowName).Show();
            }
        }

    }
}
