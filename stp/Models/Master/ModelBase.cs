using System;
using System.ComponentModel;

namespace stp.Models.Master
{
    internal abstract class ModelBase : INotifyPropertyChanged, IDataErrorInfo
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

        #region IDataErrorInfo members
        public string this[string columnName]
        {
            get
            {
                return "string";
            }
        }

        public string Error
        {
            get
            {
                return "string";
            }
        }
        #endregion
    }
}
