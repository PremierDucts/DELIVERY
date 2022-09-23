using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.Models
{
    public class Destination : BaseObservableModel
    {
        #region Destination
        private String _desAddress = "";
        public String DesAddress
        {
            get => _desAddress;
            set
            {
                _desAddress = value;
                OnPropertyChanged("DesAddress");
            }
        }

        private String _desContactName = "";
        public String DesContactName
        {
            get => _desContactName;
            set
            {
                _desContactName = value;
                OnPropertyChanged("DesContactName");
            }
        }

        private String _desCompanyName = "";
        public String DesCompanyName
        {
            get => _desCompanyName;
            set
            {
                _desCompanyName = value;
                OnPropertyChanged("DesCompanyName");
            }
        }

        private String _desPhone = "";
        public String DesPhone
        {
            get => _desPhone;
            set
            {
                _desPhone = value;
                OnPropertyChanged("DesPhone");
            }
        }

        private String _desEmailAddress = "";
        public String DesEmailAddress
        {
            get { return _desEmailAddress; }
            set
            {
                _desEmailAddress = value;
                OnPropertyChanged("DesEmailAddress");
            }
        }

        private String _desNotes = "";
        public String DesNotes
        {
            get { return _desNotes; }
            set
            {
                _desNotes = value;
                OnPropertyChanged("DesNotes");
            }
        }

        private DateTime _timeDestination = DateTime.Today;
        public DateTime TimeDestination
        {
            get => _timeDestination;
            set
            {
                _timeDestination = value;
                OnPropertyChanged("TimeDestination");
            }
        }
        #endregion
    }
}
