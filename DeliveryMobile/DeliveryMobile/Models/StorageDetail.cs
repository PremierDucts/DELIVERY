using DeliveryMobile.CoreUti;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeliveryMobile.Models
{

    public class StorageGroup : ObservableCollection<StorageDetail>
    {
        public string JobNo { get; private set; }
        public int CountItem { get; private set; }

        public StorageGroup(string jobNo, int countItem)
            : base()
        {
            JobNo = jobNo;
            CountItem = countItem;
        }

        public StorageGroup(string jobNo, List<StorageDetail> source)
            : base(source)
        {
            JobNo = jobNo;
            CountItem = source.Count;
        }
    }
    
    public class StorageDetail : BaseObservableModel
    {
        #region Contructor
        public StorageDetail(ItemDelivery cfg)
        {
            if (cfg != null)
                Config = ObjectExtension.CloneByJson(cfg);
        }
        #endregion

        #region Property
        public ItemDelivery Config { get; set; } = new ItemDelivery();


        public String StorageInfo
        {
            get { return Config.StorageInfo; }
            set
            {
                Config.StorageInfo = value;
                OnPropertyChanged("StorageInfo");
            }
        }

        public String Jobno
        {
            get { return Config.Jobno; }
            set
            {
                Config.Jobno = value;
                OnPropertyChanged("Jobno");
            }
        }

        public String Itemno
        {
            get { return Config.Itemno; }
            set
            {
                Config.Itemno = value;
                OnPropertyChanged("Itemno");
            }
        }

        public String Handle
        {
            get { return Config.Handle; }
            set
            {
                Config.Handle = value;
                OnPropertyChanged("Handle");
            }
        }

        public String Insulationarea
        {
            get { return Config.Insulationarea; }
            set
            {
                Config.Insulationarea = value;
                OnPropertyChanged("Insulationarea");
            }
        }

        public String Metalarea
        {
            get { return Config.Metalarea; }
            set
            {
                Config.Metalarea = value;
                OnPropertyChanged("Metalarea");
            }
        }

        public String WidthDim
        {
            get { return Config.WidthDim; }
            set
            {
                Config.WidthDim = value;
                OnPropertyChanged("WidthDim");
            }
        }
        public String DepthDim
        {
            get { return Config.DepthDim; }
            set
            {
                Config.DepthDim = value;
                OnPropertyChanged("DepthDim");
            }
        }
        public String Lengthangle
        {
            get { return Config.Lengthangle; }
            set
            {
                Config.Lengthangle = value;
                OnPropertyChanged("Lengthangle");
            }
        }
        public String Description
        {
            get { return Config.Description; }
            set
            {
                Config.Description = value;
                OnPropertyChanged("Description");
            }
        }

        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        #endregion
    }
}
