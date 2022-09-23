using DeliveryMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryMobile.ViewModels
{
    public class AccordionViewModel : BaseViewModel
    {
        #region Constructors

        public AccordionViewModel()
        {
            StorageDetailPressedCommand = new Command<StorageDetail>(StorageDetailOnPressed);
            StoragePressedCommand = new Command<Storage>(StorageOnPressed);
        }
        #endregion

        #region Properties
        public Command<StorageDetail> StorageDetailPressedCommand { get; private set; }
        public Command<Storage> StoragePressedCommand { get; private set; }

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
            get => DeliveryInfos.Count > 0;
        }

        private ObservableCollection<DeliveryInfo> _deliveryInfos = new ObservableCollection<DeliveryInfo>();
        public ObservableCollection<DeliveryInfo> DeliveryInfos
        {
            get => _deliveryInfos;
            set
            {
                _deliveryInfos = value;
                OnPropertyChanged("DeliveryInfos");
                UpdateButtonSave();
            }
        }
        public void UpdateButtonSave()
        {
            OnPropertyChanged("IsEnableButtonSave");
        }
        #endregion
        #region [Function]
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
            foreach (var de in DeliveryInfos)
            {
                foreach (var st in de.ListStorage)
                {
                    var objUnCheck = st.ListStorageDetail.Where(x => x.IsSelected == false).FirstOrDefault();
                    st.IsSelected = objUnCheck == null;
                }
            }
        }
        #endregion
    }
}
