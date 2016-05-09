using System;
using System.Windows;
using System.Windows.Input;

namespace stp.Commands.MainWindowCommands
{
    internal class CloseApplicationCommand : ICommand
    {
        public CloseApplicationCommand() { }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return (Application.Current != null) ? true : false;
        }

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
