using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeliveryMobile.Models
{
    public class Storage : BaseObservableModel
    {
        private String _name = "";
        public String Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private int _amount = 0;
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }
        private bool _isSelected = true;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        private ObservableCollection<StorageDetail> _listStorageDetail = new ObservableCollection<StorageDetail>();
        public ObservableCollection<StorageDetail> ListStorageDetail
        {
            get => _listStorageDetail;
            set
            {
                _listStorageDetail = value;
                OnPropertyChanged("ListStorageDetail");
            }
        }
    }

}
