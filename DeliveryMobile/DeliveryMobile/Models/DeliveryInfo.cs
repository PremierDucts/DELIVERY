using DeliveryMobile.CoreUti;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeliveryMobile.Models
{
    public class DeliveryInfo : BaseObservableModel
    {
        public DeliveryInfo(DeliveryOrder cfg = null)
        {
            if (cfg != null)
                Config = ObjectExtension.CloneByJson(cfg);
        }

        public DeliveryOrder Config { get; set; } = new DeliveryOrder();

        #region Picup
        public String PicAddress
        {
            get => Config.Pickup.AddressDetail;
            set
            {
                Config.Pickup.AddressDetail = value;
                OnPropertyChanged("PicAddress");
            }
        }

        public String PicContactName
        {
            get => Config.Pickup.Name;
            set
            {
                Config.Pickup.Name = value;
                OnPropertyChanged("PicContactName");
            }
        }

        public String PicCompanyName
        {
            get => Config.Pickup.CompanyName;
            set
            {
                Config.Pickup.CompanyName = value;
                OnPropertyChanged("PicCompanyName");
            }
        }

        public String PicPhone
        {
            get => Config.Pickup.Phone;
            set
            {
                Config.Pickup.Phone = value;
                OnPropertyChanged("PicPhone");
            }
        }

        public String PicEmailAddress
        {
            get { return Config.Pickup.Email; }
            set
            {
                Config.Pickup.Email = value;
                OnPropertyChanged("PicEmailAddress");
            }
        }

        public String PicNotes
        {
            get { return Config.Pickup.Notes; }
            set
            {
                Config.Pickup.Notes = value;
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

        public DateTime TimeDelivery
        {
            get => UtilityFunctions.ConvertLongToDateTime(Config.Pickup.PlanningTime);
            set
            {
                Config.Pickup.PlanningTime = value.Ticks;
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
