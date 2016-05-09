using stp.Common;
using stp.ViewModels;
using stp.Views;
using System;
using System.Windows.Input;

namespace stp.Commands.MainWindowCommands
{
    internal class ShowEmployeeCommand : ICommand
    {
        EmployeeListViewModel employeeListViewModel;
        EmployeeCardViewModel employeeCardViewModel;
        public ShowEmployeeCommand(EmployeeListViewModel lvm, EmployeeCardViewModel cvm)
        {
            this.employeeListViewModel = lvm;
            this.employeeCardViewModel = cvm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return (employeeListViewModel.SelectedItem != null) ? true : false;
        }

        public void Execute(object parameter)
        {
            employeeCardViewModel.Employee = employeeListViewModel.SelectedItem;
            employeeCardViewModel.IsViewMode = true;

            EmployeeCardView empView = new EmployeeCardView();

            empView.DataContext = employeeCardViewModel;
            empView.ShowDialog();
        }
    }
}
