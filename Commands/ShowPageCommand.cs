using EnglishTest.Services;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnglishTest.Commands
{
    internal sealed class ShowPageCommand : ICommand
    {
        private readonly Frame _frame;
        private readonly CachePage _cachePage = new();

        public event EventHandler? CanExecuteChanged;

        public ShowPageCommand(Frame frame)
        {
            if (frame == null)
            { 
                throw new ArgumentNullException(nameof(frame)); 
            }

            _frame = frame;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter is Type pageType && typeof(Page).IsAssignableFrom(pageType);
        }

        public void Execute(object? parameter)
        {
            if (parameter is not Type pageType)
                return;

            string pageName = pageType.Name;

            try
            {
                _frame.Navigate(_cachePage.GetCache(pageName));
            }
            catch (Exception)
            {
                Page? pageInstance = Activator.CreateInstance(pageType) as Page;
                _cachePage.CreateCache(pageName, pageInstance);
                _frame.Navigate(pageInstance);
            }
        }

    }
}
