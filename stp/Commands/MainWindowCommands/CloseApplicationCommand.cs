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
            if (Application.Current == null)
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
