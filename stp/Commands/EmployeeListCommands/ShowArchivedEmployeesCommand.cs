using stp.Data;
using stp.ViewModels;
using System;
using System.Windows.Input;

namespace stp.Commands.EmployeeListCommands
{
    internal class ShowArchivedEmployeesCommand : ICommand
    {
        private EmployeeListViewModel employeeListViewModel;

        public ShowArchivedEmployeesCommand(EmployeeListViewModel vm)
        {
            this.employeeListViewModel = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (employeeListViewModel.IsChecked)
                employeeListViewModel.ItemSource = DataManager.Instance.SelectArchivedFromEmployees();
            else
                employeeListViewModel.ItemSource = DataManager.Instance.SelectFromEmployees();                      
        }
    }
}
