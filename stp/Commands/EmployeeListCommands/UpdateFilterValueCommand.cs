﻿using stp.ViewModels;
using System;
using System.Windows.Input;

namespace stp.Commands.EmployeeListCommands
{
    internal class UpdateFilterValueCommand : ICommand
    {
        private EmployeeListViewModel employeeListViewModel;

        public UpdateFilterValueCommand(EmployeeListViewModel vm)
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
            return (String.IsNullOrWhiteSpace(employeeListViewModel.FilterValue)) ? true : false;
        }

        public void Execute(object parameter)
        {
            employeeListViewModel.FilterValue = "*";
        }
    }
}
