using System;
using stp.ViewModels.Master;

namespace stp.ViewModels
{
    internal class DebugViewModel : ViewModelBase
    {
        private string debugString;        
        /// <summary>
        /// Initializes a new instance of the DebugViewModel class.
        /// </summary>
        public DebugViewModel() { DebugString = "Your debug String here..."; }

        /// <summary>
        /// Gets or sets a debug String to prompt.
        /// </summary>
        public String DebugString
        {
            get { return debugString; }
            set
            {
                debugString = value;
                OnPropertyChanged("DebugString");
            }
        }
    }
}
