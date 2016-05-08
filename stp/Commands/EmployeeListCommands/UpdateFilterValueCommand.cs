using stp.ViewModels;
using System;
using System.Windows.Input;

namespace stp.Commands.EmployeeListCommands
{
    internal class UpdateFilterValueCommand : ICommand
    {
        private EmployeeListViewModel vm;

        public UpdateFilterValueCommand(EmployeeListViewModel vm)
        {
            this.vm = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (!String.IsNullOrWhiteSpace(vm.FilterValue))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            vm.FilterValue = "*";
        }
    }
}
