using stp.ViewModels;
using stp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace stp.Commands.MainWindowCommands
{
    internal class ArchiveEmployeeCommand : ICommand
    {
        EmployeeListViewModel lvm;
        EmployeeCardViewModel cvm;

        public ArchiveEmployeeCommand(EmployeeListViewModel lvm, EmployeeCardViewModel cvm)
        {
            this.lvm = lvm;
            this.cvm = cvm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (lvm.SelectedItem != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            cvm.Employee = lvm.SelectedItem;

            EmployeeCardView empView = new EmployeeCardView();

            empView.DataContext = cvm;
            empView.ShowDialog();
        }
    }
}
