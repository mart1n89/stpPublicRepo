using stp.Common;
using stp.Models;
using stp.ViewModels.Master;

namespace stp.ViewModels
{
    internal class EmployeeCardViewModel : ViewModelBase
    {
        private bool isViewMode;
        private Employee employee;
        public EmployeeCardViewModel(Employee emp)
        {
            employee = emp;
        }

        public Employee Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        public bool IsViewMode
        {
            get { return isViewMode; }
            set
            {
                isViewMode = value;
                OnPropertyChanged("IsViewMode");
            }
        }
    }
}
