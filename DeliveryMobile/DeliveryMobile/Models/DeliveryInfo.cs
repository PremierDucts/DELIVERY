using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeliveryMobile.Models
{
    public class DeliveryInfo : BaseObservableModel
    {
        #region Picup
        private String _picAddress = "";
        public String PicAddress
        {
            get => _picAddress;
            set
            {
                _picAddress = value;
                OnPropertyChanged("PicAddress");
            }
        }

        private String _picContactName = "";
        public String PicContactName
        {
            get => _picContactName;
            set
            {
                _picContactName = value;
                OnPropertyChanged("PicContactName");
            }
        }

        private String _picCompanyName = "";
        public String PicCompanyName
        {
            get => _picCompanyName;
            set
            {
                _picCompanyName = value;
                OnPropertyChanged("PicCompanyName");
            }
        }

        private String _picPhone = "";
        public String PicPhone
        {
            get => _picPhone;
            set
            {
                _picPhone = value;
                OnPropertyChanged("PicPhone");
            }
        }

        private String _picEmailAddress = "";
        public String PicEmailAddress
        {
            get { return _picEmailAddress; }
            set
            {
                _picEmailAddress = value;
                OnPropertyChanged("PicEmailAddress");
            }
        }

        private String _picNotes = "";
        public String PicNotes
        {
            get { return _picNotes; }
            set
            {
                _picNotes = value;
                OnPropertyChanged("PicNotes");
            }
        }
        #endregion

        private ObservableCollection<Destination> _destinations = new ObservableCollection<Destination>();
        public ObservableCollection<Destination> Destinations
        {
            get => _destinations;
            set
            {
                _destinations = value;
                OnPropertyChanged("Destinations");
            }
        }

        private ObservableCollection<Storage> _listStorage = new ObservableCollection<Storage>();
        public ObservableCollection<Storage> ListStorage
        {
            get => _listStorage;
            set
            {
                _listStorage = value;
                OnPropertyChanged("ListStorage");
            }
        }

        private DateTime _timeDelivery = DateTime.Today;
        public DateTime TimeDelivery
        {
            get => _timeDelivery;
            set
            {
                _timeDelivery = value;
                OnPropertyChanged("TimeDelivery");
            }
        }
        private String _filePath = "";
        public String FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged("FilePath");
            }
        }
    }

}
