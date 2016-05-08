using stp.Data;
using stp.Models;
using stp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace stp.Commands.EmployeeListCommands
{
    internal class SearchEmployeeCommand : ICommand
    {
        private EmployeeListViewModel vm;

        public SearchEmployeeCommand(EmployeeListViewModel vm)
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
            if ((vm.SelectedComboBoxItem == null) || String.IsNullOrWhiteSpace(vm.FilterValue))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            if (vm.FilterValue == "*")
            {
                vm.ItemSource = DataManager.Instance.SelectFromEmployees();

                if (vm.ItemSource.Count == 0)
                {
                    MessageBox.Show("Kein Treffer!");
                }
            }
            else
            {
                vm.ItemSource = DataManager.Instance.SelectFromEmployees(vm.SelectedComboBoxItem.Value, vm.FilterValue);

                if (vm.ItemSource.Count == 0)
                {
                    MessageBox.Show("Kein Treffer!");
                }
            }           
        }
    }
}
