using DeliveryMobile.CoreUti;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.Models
{
    public class Destination : BaseObservableModel
    {
        #region Contructor
        public Destination(DeliveryPoint cfg)
        {
            if (cfg != null)
            {
                Config = ObjectExtension.CloneByJson(cfg);
                LoadDataFromConfig();
            }
              
        }
        #endregion

        #region Property
        public DeliveryPoint Config { get; set; } = new DeliveryPoint();

        public String AddressDetail
        {
            get => Config.AddressDetail;
            set
            {
                Config.AddressDetail = value;
                OnPropertyChanged("AddressDetail");
            }
        }

        public String Name
        {
            get => Config.Name;
            set
            {
                Config.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public String CompanyName
        {
            get => Config.CompanyName;
            set
            {
                Config.CompanyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public String Phone
        {
            get => Config.Phone;
            set
            {
                Config.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public String Email
        {
            get { return Config.Email; }
            set
            {
                Config.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public String Notes
        {
            get { return Config.Notes; }
            set
            {
                Config.Notes = value;
                OnPropertyChanged("Notes");
            }
        }

        public String City
        {
            get { return Config.City; }
            set
            {
                Config.City = value;
                OnPropertyChanged("City");
            }
        }

        public String Country
        {
            get { return Config.Country; }
            set
            {
                Config.Country = value;
                OnPropertyChanged("Country");
            }
        }

        public bool IsDefault
        {
            get { return Config.IsDefault; }
            set
            {
                Config.IsDefault = value;
                OnPropertyChanged("IsDefault");
            }
        }

        public String PostalCode
        {
            get { return Config.PostalCode; }
            set
            {
                Config.PostalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        public String State
        {
            get { return Config.State; }
            set
            {
                Config.State = value;
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
        public bool _isExpandedDestination = false;
        public bool IsExpandedDestination
        {
            get { return _isExpandedDestination; }
            set
            {
                _isExpandedDestination = value;
                OnPropertyChanged("IsExpandedDestination");
            }
        }

        #endregion

        #region Function
        private void LoadDataFromConfig()
        {
            PlanningTime = UtilityFunctions.ConvertLongToDateTime(Config.PlanningTime);
        }
        #endregion
    }
}
