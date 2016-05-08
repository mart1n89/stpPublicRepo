using System.ComponentModel;

namespace stp.ViewModels.Master
{
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler hander = PropertyChanged;

            if (hander != null)
            {
                hander(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
