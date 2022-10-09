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
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using static DeliveryMobile.WebAPIClient.DeliveryServer.Base;

namespace DeliveryMobile.ViewModels
{
    public class AccordionViewModel : BaseViewModel
    {
        #region Constructors
        public AccordionViewModel(DeliveryOrder cfg = null, bool isUpdate = false)
        {
            IsUpdate = isUpdate;
            StorageDetailPressedCommand = new Command<StorageDetail>(StorageDetailOnPressed);
            StoragePressedCommand = new Command<CagesViewModel>(StorageOnPressed);
            StorageExpandPressedCommand = new Command<CagesViewModel>(StorageExpanOnPressed);
            if (cfg != null)
            {
                Config = ObjectExtension.CloneByJson(cfg);
                LoadDataFromConfig();
            }
            #region [Awaiting when load data]
            MessagingCenter.Subscribe<String>("ACCORDION_VIEW_BUSY", "ACCORDION_VIEW_BUSY", (str) => IsRunningAnimation = true);
            MessagingCenter.Subscribe<String>("ACCORDION_VIEW_NO_BUSY", "ACCORDION_VIEW_NO_BUSY", (str) => IsRunningAnimation = false);
            #endregion
        }
        #endregion

        #region Properties
        public Command<StorageDetail> StorageDetailPressedCommand { get; private set; }
        public Command<CagesViewModel> StoragePressedCommand { get; private set; }
        public Command<CagesViewModel> StorageExpandPressedCommand { get; private set; }

        public DeliveryOrder Config { get; set; } = new DeliveryOrder();
        public bool IsUpdate { get; set; } = false;
        public Dictionary<String, String> DicItemSelected { get; set; } = new Dictionary<String, String>();

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
        private bool _isRunningAnimation = false;
        public bool IsRunningAnimation
        {
            get => _isRunningAnimation;
            set
            {
                _isRunningAnimation = value;
                OnPropertyChanged("IsRunningAnimation");
            }
        }



        public bool IsEnableButtonSave
        {
            get => Destinations.Count > 0;
        }

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

        private ObservableCollection<CagesViewModel> _cages = new ObservableCollection<CagesViewModel>();
        public ObservableCollection<CagesViewModel> Cages
        {
            get => _cages;
            set
            {
                _cages = value;
                OnPropertyChanged("Cages");
            }
        }

        #endregion

        #region [Function]
        public void AddDestination()
        {
            Destinations.Add(new Destination(new DeliveryPoint()));
            UpdateButtonSave();
        }
        public void UpdateButtonSave()
        {
            OnPropertyChanged("IsEnableButtonSave");
        }

        private void LoadDataFromConfig()
        {
            DicItemSelected = new Dictionary<string, String>();
            Destinations = new ObservableCollection<Destination>();
            Cages = new ObservableCollection<CagesViewModel>();
            foreach (var des in Config.DeliveryPoints)
                Destinations.Add(new Destination(des));
            var listStorageInfo = new List<String>();
            foreach (var item in Config.Items)
            {
                DicItemSelected[item.Itemno] = item.Itemno;
                if (!listStorageInfo.Contains(item.StorageInfo))
                    listStorageInfo.Add(item.StorageInfo);
            }

            Cages.Add(new CagesViewModel() { StorageInfo = "Cage" });
            Cages.Add(new CagesViewModel() { StorageInfo = "Pallet" });
            Cages.Add(new CagesViewModel() { StorageInfo = "Ground" });
            Cages.Add(new CagesViewModel() { StorageInfo = "Rego" });

            foreach (var storageInfo in listStorageInfo)
            {
                var storage = new CagesViewModel();
                if (storageInfo.Contains("Cage"))
                {
                    var cage = Cages.Where(x => x.StorageInfo == "Cage").FirstOrDefault();
                    cage.CageName = storageInfo.Replace("Cage", "")?.Trim();
                    cage.LoadItemInfo(storageInfo, DicItemSelected);
                }
                else if (storageInfo.Contains("Pallet"))
                {
                    var pallet = Cages.Where(x => x.StorageInfo == "Pallet").FirstOrDefault();
                    pallet.CageName = storageInfo.Replace("Pallet", "")?.Trim();
                    pallet.LoadItemInfo(storageInfo, DicItemSelected);
                }
                else if (storageInfo.Contains("Ground"))
                {
                    var ground = Cages.Where(x => x.StorageInfo == "Ground").FirstOrDefault();
                    ground.CageName = storageInfo.Replace("Ground", "")?.Trim();
                    ground.LoadItemInfo(storageInfo, DicItemSelected);
                }
                else
                {
                    var rego = Cages.Where(x => x.StorageInfo == "Rego").FirstOrDefault();
                    rego.CageName = storageInfo.Replace("Rego", "")?.Trim();
                    rego.LoadItemInfo(storageInfo, DicItemSelected);
                }
            }
            CheckedStorageDetail();
            PlanningTime = UtilityFunctions.ConvertLongToDateTime(Config.PickupPoint.PlanningTime);
        }

        public void StorageDetailOnPressed(StorageDetail obj)
        {
            obj.IsSelected = !obj.IsSelected;
            CheckedStorageDetail();
        }
        public void StorageOnPressed(CagesViewModel obj)
        {
            obj.IsSelected = !obj.IsSelected;
            foreach (var sd in obj.ListStorageDetail)
                sd.IsSelected = obj.IsSelected;
        }

        public void StorageExpanOnPressed(CagesViewModel obj)
        {
            obj.IsExpandedListItem = !obj.IsExpandedListItem;
            if (obj.IsExpandedListItem)
                obj.LoadItemInfo($"{obj.StorageInfo} {obj.CageName?.Trim()}", DicItemSelected);
            else
            {
                DicItemSelected = new Dictionary<string, string>();
                foreach (var item in obj.ListStorageDetail)
                {
                    if (item.IsSelected)
                        DicItemSelected[item.Itemno] = item.Itemno;
                }
            }
        }
        public void CheckedStorageDetail()
        {
            foreach (var st in Cages)
            {
                var objUnCheck = st.ListStorageDetail.Where(x => x.IsSelected == false).FirstOrDefault();
                st.IsSelected = (st.ListStorageDetail.Count > 0 && objUnCheck == null);
            }
        }
        public async void AddOrUpdateOrder(DeliveryOrder order)
        {
            IsRunningAnimation = true;
            await Task.Delay(1);
            var result = new PreServerResponseData();
            if (IsUpdate)
                result = CommonAPI.UpdateOrder(new ServerConnectInfo { Address = Global.Instance.DeliveryAddress }, order);
            else
                result = CommonAPI.CreateOrder(new ServerConnectInfo { Address = Global.Instance.DeliveryAddress }, order);
            if (result.Code == PRE_SERVER_RETURN_CODE.Created || result.Code == PRE_SERVER_RETURN_CODE.Accepted)
            {
                MessagingCenter.Send<String>("UPDATE_ORDER", "UPDATE_ORDER");
                await Shell.Current.Navigation.PopModalAsync();
            }
            IsRunningAnimation = false;
            await Shell.Current.DisplayToastAsync(result.Code.ToString());
        }

        public async void DeleteOrder(String id)
        {
            IsRunningAnimation = true;
            await Task.Delay(1);
            var result = CommonAPI.DeleteOrder(new ServerConnectInfo { Address = Global.Instance.DeliveryAddress }, id);
            if (result.Code == PRE_SERVER_RETURN_CODE.Ok)
            {
                MessagingCenter.Send<String>("UPDATE_ORDER", "UPDATE_ORDER");
                await Shell.Current.Navigation.PopModalAsync();
            }
            IsRunningAnimation = false;
            await Shell.Current.DisplayToastAsync(result.Code.ToString());
        }

        #endregion
    }

    public class CagesViewModel : BaseViewModel
    {
        private String _storageInfo = "";
        public String StorageInfo
        {
            get { return _storageInfo; }
            set
            {
                _storageInfo = value;
                OnPropertyChanged("StorageInfo");
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

        private ObservableCollection<StorageGroup> _groupList = new ObservableCollection<StorageGroup>();
        public ObservableCollection<StorageGroup> GroupList
        {
            get => _groupList;
            set
            {
                _groupList = value;
                OnPropertyChanged("GroupList");
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

        private bool _isExpandedListItem = false;
        public bool IsExpandedListItem
        {
            get => _isExpandedListItem;
            set
            {

                _isExpandedListItem = value;
                OnPropertyChanged("IsExpandedListItem");
            }
        }

        private String _cageName = "";
        public String CageName
        {
            get { return _cageName; }
            set
            {
                _cageName = value;
                OnPropertyChanged("CageName");
            }
        }
        #region [Method]
        public void CheckIsSelected() => IsSelected = (ListStorageDetail.Count > 0 && ListStorageDetail.Where(x => x.IsSelected == false).FirstOrDefault() == null);

        public void CheckIsSelectedItem(Dictionary<string, String> dicItemSelected)
        {
            foreach (var item in ListStorageDetail)
            {
                if (dicItemSelected.ContainsKey(item.Itemno))
                    item.IsSelected = true;
            }
        }
        public async void LoadItemInfo(String storageInfo, Dictionary<string, String> dicItemSelected)
        {
            MessagingCenter.Send<String>("ACCORDION_VIEW_BUSY", "ACCORDION_VIEW_BUSY");
            await Task.Delay(1);
            var items = GetAllItem(storageInfo);
            if (items != null)
            {
                ListStorageDetail = new ObservableCollection<StorageDetail>();
                GroupList = new ObservableCollection<StorageGroup>();
                foreach (var cfg in items)
                {
                    await Task.Delay(1);
                    ListStorageDetail.Add(new StorageDetail(cfg));
                }
                var listJobNo = new List<String>();
                foreach (var key in items)
                {
                    if (!listJobNo.Contains(key.Jobno))
                        listJobNo.Add(key.Jobno);
                }
                foreach (var jobNo in listJobNo)
                {
                    var listItemGr = ListStorageDetail.Where(x => x.Jobno == jobNo).ToList();
                    GroupList.Add(new StorageGroup(jobNo, listItemGr));
                }

            }
            CheckIsSelectedItem(dicItemSelected);
            CheckIsSelected();
            MessagingCenter.Send<String>("ACCORDION_VIEW_NO_BUSY", "ACCORDION_VIEW_NO_BUSY");
        }

        private List<ItemDelivery> GetAllItem(String storageInfo)
        {
            var result = CommonAPI.GetAllItem(new ServerConnectInfo { Address = Global.Instance.DeliveryAddressQLD }, storageInfo);
            if (result.Code != PRE_SERVER_RETURN_CODE.SUCCESS)
                return new List<ItemDelivery>();
            return result.Data as List<ItemDelivery>;
        }
        #endregion
    }

}
