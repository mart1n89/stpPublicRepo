using stp.Commands.EmployeeListCommands;
using stp.Common;
using stp.Data;
using stp.Models;
using stp.ViewModels.Master;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace stp.ViewModels
{
    internal class EmployeeListViewModel : ViewModelBase
    {
        private string filterValue;
        private CustomComboBoxItem selectedComboBoxItem;

        private Employee selectedItem;
        private ObservableCollection<Employee> employeeItemSource;

        /// <summary>
        /// Initializes a new instance of the EmployeeViewModel class.
        /// </summary>
        public EmployeeListViewModel()
        {
            employeeItemSource = DataManager.Instance.SelectFromEmployees();

            SearchEmployees = new SearchEmployeeCommand(this);
            UpdateFilterValue = new UpdateFilterValueCommand(this);

            FilterValue = "*";
        }

        public ObservableCollection<Employee> ItemSource
        {
            get { return employeeItemSource; }
            set
            {
                employeeItemSource = value;
                OnPropertyChanged("ItemSource");
            }
        }

        public Employee SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ICommand SearchEmployees
        {
            get;
            private set;
        }

        public ICommand UpdateFilterValue
        {
            get;
            private set;
        }

        public String FilterValue
        {
            get { return filterValue; }
            set
            {
                filterValue = value;
                OnPropertyChanged("FilterValue");
            }
        }

        public CustomComboBoxItem SelectedComboBoxItem
        {
            get { return selectedComboBoxItem; }
            set
            {
                selectedComboBoxItem = value;
                OnPropertyChanged("SelectedComboBoxItem");
            }
        }

    }
}
