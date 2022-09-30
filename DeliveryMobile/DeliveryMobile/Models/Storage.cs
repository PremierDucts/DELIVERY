using DeliveryMobile.Base;
using DeliveryMobile.CoreUti;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.ViewModels;
using DeliveryMobile.WebAPIClient.DeliveryServer;
using DeliveryMobile.WebAPIClient.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static DeliveryMobile.WebAPIClient.DeliveryServer.Base;

namespace DeliveryMobile.Models
{
    public class Storage : BaseObservableModel
    {
        #region Contructor
        public Storage()
        {
            LoadCages();
        }
        #endregion

        #region Property

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
        private int _selectedIndexCage = 0;
        public int SelectedIndexCage
        {
            get { return _selectedIndexCage; }
            set
            {
                _selectedIndexCage = value;
                OnPropertyChanged("SelectedIndexCage");
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
        #endregion

        #region Method
        private void LoadCages()
        {

            var cagesList = GetAllCages().Where(x => x.StorageInfo != "NULL"
                                                    && x.StorageInfo != ""
                                                    && x.StorageInfo != null
                                                    && x.ResetDay != "EMPTY"
                                                    && x.ResetTime != "EMPTY"
                                                    && x.ResetDay != ""
                                                    && x.ResetTime != ""
                                                    && x.ResetDay != null
                                                    && x.ResetTime != null).ToList();
            if (cagesList != null)
            {
                Cages = new ObservableCollection<CagesViewModel>();
                foreach (var cage in cagesList)
                    Cages.Add(new CagesViewModel(cage));
            }
        }

        private List<Cages> GetAllCages()
        {
            var result = CommonAPI.GetAllCages(new ServerConnectInfo { Address = Global.Instance.DeliveryAddressQLD });
            if (result.Code != PRE_SERVER_RETURN_CODE.SUCCESS)
                return new List<Cages>();
            return result.Data as List<Cages>;
        }
        #endregion

    }

}
