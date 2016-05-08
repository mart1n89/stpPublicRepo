using stp.Commands.MainWindowCommands;
using stp.ViewModels.Master;
using stp.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace stp.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private bool isTabEmployeeSelected;
        private bool isTabCourseSelected;

        private UserControl activeUserControl;
        
        private DebugView debugView;
        private DebugViewModel debugViewModel;

        private EmployeeListView employeeView;
        private EmployeeListViewModel employeeListViewModel;
        private EmployeeCardViewModel employeeCardViewModel;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            debugView = new DebugView();
            debugViewModel = new DebugViewModel();

            employeeView = new EmployeeListView();
            employeeListViewModel = new EmployeeListViewModel();

            employeeCardViewModel = new EmployeeCardViewModel(null);

            ActiveUserControl = employeeView;
            ActiveUserControl.DataContext = employeeListViewModel;

            CloseApplication = new CloseApplicationCommand();

            EditEmployeeCommand = new EditEmployeeCommand(employeeListViewModel, employeeCardViewModel);
            ShowEmployeeCommand = new ShowEmployeeCommand(employeeListViewModel, employeeCardViewModel);
            ArchiveEmployeeCommand = new ArchiveEmployeeCommand(employeeListViewModel, employeeCardViewModel);
        }

        /// <summary>
        /// Gets or sets a UserControl in MainWindow.
        /// </summary>
        public UserControl ActiveUserControl
        {
            get { return activeUserControl; }
            set
            {
                activeUserControl = value;
                OnPropertyChanged("ActiveUserControl");
            }
        }

        /// <summary>
        /// Indicates whether Course Tab is selected or not.
        /// </summary>
        public bool IsTabCourseSelected
        {
            get { return isTabCourseSelected; }
            set
            {
                isTabCourseSelected = value;
                OnPropertyChanged("IsTabCourseSelected");

                ActiveUserControl = debugView;
                ActiveUserControl.DataContext = debugViewModel;
            }
        }

        /// <summary>
        /// Indicates whether Employee Tab is selected or not.
        /// </summary>
        public bool IsTabEmployeeSelected
        {
            get { return isTabEmployeeSelected; }
            set
            {
                isTabEmployeeSelected = value;
                OnPropertyChanged("IsTabEmployeeSelected");

                ActiveUserControl = employeeView;
                ActiveUserControl.DataContext = employeeListViewModel;
            }
        }

        public ICommand CloseApplication
        {
            get;
            private set;
        }

        public ICommand EditEmployeeCommand
        {
            get;
            private set;
        }
        public ICommand ShowEmployeeCommand
        {
            get;
            private set;
        }
        public ICommand ArchiveEmployeeCommand
        {
            get;
            private set;
        }


    }
}
