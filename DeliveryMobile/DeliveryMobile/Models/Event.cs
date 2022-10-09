using DeliveryMobile.CoreUti;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.Utility;
using DeliveryMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryMobile.Models
{
    public class Event : BaseObservableModel
    {
        public Event(DeliveryOrder cfg)
        {
            if (cfg != null)
            {
                Config = ObjectExtension.CloneByJson(cfg);
                LoadDataFromConfig();
            }
        }
        #region Property
        private bool _isExpandedDelivery = false;
        public bool IsExpandedDelivery
        {
            get => _isExpandedDelivery;
            set
            {
                _isExpandedDelivery = value;
                OnPropertyChanged("IsExpandedDelivery");
            }
        }

        private bool _isExpandedDestination = false;
        public bool IsExpandedDestination
        {
            get => _isExpandedDestination;
            set
            {
                _isExpandedDestination = value;
                OnPropertyChanged("IsExpandedDestination");
            }
        }

        private bool _isExpandedItem = false;
        public bool IsExpandedItem
        {
            get => _isExpandedItem;
            set
            {
                _isExpandedItem = value;
                OnPropertyChanged("IsExpandedItem");
            }
        }

        public DeliveryOrder Config { get; set; } = new DeliveryOrder();
        public Color Color { get; set; }
        public Color CurrentDayColor { get; set; }

        #region Picup
        public String AddressDetail
        {
            get => Config.PickupPoint.AddressDetail;
            set
            {
                Config.PickupPoint.AddressDetail = value;
                OnPropertyChanged("AddressDetail");
            }
        }

        public String Name
        {
            get => Config.PickupPoint.Name;
            set
            {
                Config.PickupPoint.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public String CompanyName
        {
            get => Config.PickupPoint.CompanyName;
            set
            {
                Config.PickupPoint.CompanyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public String Phone
        {
            get => Config.PickupPoint.Phone;
            set
            {
                Config.PickupPoint.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public String Email
        {
            get { return Config.PickupPoint.Email; }
            set
            {
                Config.PickupPoint.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public String Notes
        {
            get { return Config.PickupPoint.Notes; }
            set
            {
                Config.PickupPoint.Notes = value;
                OnPropertyChanged("Notes");
            }
        }

        public String City
        {
            get { return Config.PickupPoint.City; }
            set
            {
                Config.PickupPoint.City = value;
                OnPropertyChanged("City");
            }
        }

        public String Country
        {
            get { return Config.PickupPoint.Country; }
            set
            {
                Config.PickupPoint.Country = value;
                OnPropertyChanged("Country");
            }
        }

        public bool IsDefault
        {
            get { return Config.PickupPoint.IsDefault; }
            set
            {
                Config.PickupPoint.IsDefault = value;
                OnPropertyChanged("IsDefault");
            }
        }

        public String PostalCode
        {
            get { return Config.PickupPoint.PostalCode; }
            set
            {
                Config.PickupPoint.PostalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        public String State
        {
            get { return Config.PickupPoint.State; }
            set
            {
                Config.PickupPoint.State = value;
                OnPropertyChanged("State");
            }
        }

        private DateTime _planningTime = DateTime.Now;
        public DateTime PlanningTime
        {
            get => _planningTime;
            set
            {
                _planningTime = value;
                OnPropertyChanged("PlanningTime");
            }
        }
        #endregion
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

        #region Method
        private void LoadDataFromConfig()
        {
            Destinations = new ObservableCollection<Destination>();
            ListStorageDetail = new ObservableCollection<StorageDetail>();
            
            foreach (var des in Config.DeliveryPoints)
                Destinations.Add(new Destination(des));

            foreach (var cfg in Config.Items)
                ListStorageDetail.Add(new StorageDetail(cfg));
            PlanningTime = UtilityFunctions.ConvertLongToDateTime(Config.PickupPoint.PlanningTime);
        }
        #endregion

    }
}
