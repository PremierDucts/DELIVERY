using DeliveryMobile.Base;
using DeliveryMobile.CoreUti;
using DeliveryMobile.Models;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.Services;
using DeliveryMobile.Utility;
using DeliveryMobile.WebAPIClient.DeliveryServer;
using DeliveryMobile.WebAPIClient.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using static DeliveryMobile.WebAPIClient.DeliveryServer.Base;

namespace DeliveryMobile.ViewModels
{
    public class AccordionViewModel : BaseViewModel
    {
        #region Constructors
        public AccordionViewModel(DeliveryOrder cfg = null)
        {
            StorageDetailPressedCommand = new Command<StorageDetail>(StorageDetailOnPressed);
            StoragePressedCommand = new Command<Storage>(StorageOnPressed);
            if (cfg != null)
            {
                Config = ObjectExtension.CloneByJson(cfg);
                LoadDestinationFromConfig();
            }
        }
        #endregion

        #region Properties
        public Command<StorageDetail> StorageDetailPressedCommand { get; private set; }
        public Command<Storage> StoragePressedCommand { get; private set; }

        public DeliveryOrder Config { get; set; } = new DeliveryOrder();

        private String _jobNo = "New Delivery";
        public String JobNo
        {
            get => _jobNo;
            set
            {
                _jobNo = value;
                OnPropertyChanged("JobNo");
            }

        }


        public bool IsEnableButtonSave
        {
            get => Destinations.Count > 0;
        }

        #region Picup
        public String AddressDetail
        {
            get => Config.Pickup.AddressDetail;
            set
            {
                Config.Pickup.AddressDetail = value;
                OnPropertyChanged("AddressDetail");
            }
        }

        public String Name
        {
            get => Config.Pickup.Name;
            set
            {
                Config.Pickup.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public String CompanyName
        {
            get => Config.Pickup.CompanyName;
            set
            {
                Config.Pickup.CompanyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public String Phone
        {
            get => Config.Pickup.Phone;
            set
            {
                Config.Pickup.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public String Email
        {
            get { return Config.Pickup.Email; }
            set
            {
                Config.Pickup.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public String Notes
        {
            get { return Config.Pickup.Notes; }
            set
            {
                Config.Pickup.Notes = value;
                OnPropertyChanged("Notes");
            }
        }

        public String City
        {
            get { return Config.Pickup.City; }
            set
            {
                Config.Pickup.City = value;
                OnPropertyChanged("City");
            }
        }

        public String Country
        {
            get { return Config.Pickup.Country; }
            set
            {
                Config.Pickup.Country = value;
                OnPropertyChanged("Country");
            }
        }

        public bool IsDefault
        {
            get { return Config.Pickup.IsDefault; }
            set
            {
                Config.Pickup.IsDefault = value;
                OnPropertyChanged("IsDefault");
            }
        }

        public String PostalCode
        {
            get { return Config.Pickup.PostalCode; }
            set
            {
                Config.Pickup.PostalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        public String State
        {
            get { return Config.Pickup.State; }
            set
            {
                Config.Pickup.State = value;
                OnPropertyChanged("State");
            }
        }

        public DateTime PlanningTime
        {
            get => UtilityFunctions.ConvertLongToDateTime(Config.Pickup.PlanningTime);
            set
            {
                Config.Pickup.PlanningTime = value.Ticks;
                OnPropertyChanged("PlanningTime");
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

        #endregion

        #region [Function]

        public void UpdateButtonSave()
        {
            OnPropertyChanged("IsEnableButtonSave");
        }

        private void LoadDestinationFromConfig()
        {
            Destinations = new ObservableCollection<Destination>();
            foreach (var des in Config.DeliveryPoints)
                Destinations.Add(new Destination(des));
        }

        public void StorageDetailOnPressed(StorageDetail obj)
        {
            obj.IsSelected = !obj.IsSelected;
            CheckedStorageDetail();
        }
        public void StorageOnPressed(Storage obj)
        {
            obj.IsSelected = !obj.IsSelected;
            foreach (var sd in obj.ListStorageDetail)
                sd.IsSelected = obj.IsSelected;
        }

        public void CheckedStorageDetail()
        {
            foreach (var st in ListStorage)
            {
                var objUnCheck = st.ListStorageDetail.Where(x => x.IsSelected == false).FirstOrDefault();
                st.IsSelected = objUnCheck == null;
            }
        }
        public void CreateOrder(DeliveryOrder order)
        {
            var result = CommonAPI.CreateOrder(new ServerConnectInfo { Address = Global.Instance.DeliveryAddress }, order);
            if (result.Code != PRE_SERVER_RETURN_CODE.Ok)
                Toast.ShowInThread(result.Code.ToString());
        }

        #endregion
    }
    
    public class CagesViewModel : BaseViewModel
    {
        public CagesViewModel(Cages cfg)
        {
            if (cfg != null)
            {
                Config = ObjectExtension.CloneByJson(cfg);
            }
        }

        public Cages Config { get; set; } = new Cages();
        public String ResetDay
        {
            get { return Config.ResetDay; }
            set
            {
                Config.ResetDay = value;
                OnPropertyChanged("ResetDay");
            }
        }
        public String ResetTime
        {
            get { return Config.ResetTime; }
            set
            {
                Config.ResetTime = value;
                OnPropertyChanged("ResetTime");
            }
        }

        public String StorageInfo
        {
            get { return Config.StorageInfo; }
            set
            {
                Config.StorageInfo = value;
                OnPropertyChanged("StorageInfo");
            }
        }
    }
}
