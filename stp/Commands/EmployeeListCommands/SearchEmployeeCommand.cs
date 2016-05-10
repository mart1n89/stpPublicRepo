using stp.Data;
using stp.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace stp.Commands.EmployeeListCommands
{
    internal class SearchEmployeeCommand : ICommand
    {
        private EmployeeListViewModel employeeListViewModel;

        public SearchEmployeeCommand(EmployeeListViewModel vm)
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
            if ((employeeListViewModel.SelectedComboBoxItem == null) 
                || String.IsNullOrWhiteSpace(employeeListViewModel.FilterValue))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            if (employeeListViewModel.FilterValue == "*")
            {
                if (employeeListViewModel.IsChecked)
                    employeeListViewModel.ItemSource = DataManager.Instance.SelectArchivedFromEmployees();
                else
                    employeeListViewModel.ItemSource = DataManager.Instance.SelectFromEmployees();

                if (employeeListViewModel.ItemSource.Count == 0)
                    MessageBox.Show("Kein Treffer!");
            }
            else
            {
                if (employeeListViewModel.IsChecked)
                    employeeListViewModel.ItemSource = DataManager.Instance.SelectArchivedFromEmployees(
                        employeeListViewModel.SelectedComboBoxItem.Value, employeeListViewModel.FilterValue);
                else
                    employeeListViewModel.ItemSource = DataManager.Instance.SelectFromEmployees(
                        employeeListViewModel.SelectedComboBoxItem.Value, employeeListViewModel.FilterValue);

                if (employeeListViewModel.ItemSource.Count == 0)
                    MessageBox.Show("Kein Treffer!");
            }           
        }
    }
}
