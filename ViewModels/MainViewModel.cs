using EnglishTest.Commands;
using EnglishTest.Interfaces;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnglishTest.ViewModels
{
    internal sealed class MainViewModel : ViewModelBase, IInitialization
    {
        public ICommand? Command { get; private set; }

        public Task InitializeServicesAsync()
        {
            throw new NotImplementedException();
        }

        public void InitializeСommand(object paramter)
        {
            if (paramter == null || paramter is not Frame frame)
            {
                return;
            }

            Command = new ShowPageCommand(frame);
        }
    }
}
