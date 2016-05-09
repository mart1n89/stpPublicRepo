using stp.Common;
using stp.Data;
using stp.ViewModels;
using stp.Views;
using System;
using System.Windows.Input;

namespace stp.Commands.MainWindowCommands
{
    internal class ArchiveEmployeeCommand : ICommand
    {
        EmployeeListViewModel employeeListViewModel;
        EmployeeCardViewModel employeeCardViewModel;

        public ArchiveEmployeeCommand(EmployeeListViewModel lvm, EmployeeCardViewModel cvm)
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
            DataManager.Instance.ArchiveFromEmployee(employeeListViewModel.SelectedItem.Id);
            employeeListViewModel.ItemSource = DataManager.Instance.SelectFromEmployees();
        }
    }
}
