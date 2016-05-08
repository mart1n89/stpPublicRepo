using stp.Models;
using stp.ViewModels.Master;

namespace stp.ViewModels
{
    internal class EmployeeCardViewModel : ViewModelBase
    {
        Employee emp;
        public EmployeeCardViewModel(Employee emp)
        {
            this.emp = emp;
        }

        public Employee Employee
        {
            get { return emp; }
            set
            {
                emp = value;
                OnPropertyChanged("Employee");
            }
        }
    }
}
