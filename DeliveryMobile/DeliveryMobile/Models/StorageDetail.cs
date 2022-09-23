using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.Models
{
    public class StorageDetail : BaseObservableModel
    {
        public string BGColor { get; set; }
        public string jobno { get; set; }
        public string jobnoHiding { get; set; }
        public string itemInStorage { get; set; }
        public string totalPacked { get; set; }
        public string packedLabel { get; set; }
        public string itemno { get; set; }
        public string dimension { get; set; }
        public string insulationSpec { get; set; }
        public string notes { get; set; }
        public string storageID { get; set; }
        public string resetDay { get; set; }
        public string resetTime { get; set; }
        public string packingID { get; set; }
        public string pathId { get; set; }
        public string handle { get; set; } //=> List
        public string filename { get; set; } //=>List
        public string pathValue { get; set; }
        public string jobReference { get; set; }
        public string qty { get; set; }

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
    }

}
