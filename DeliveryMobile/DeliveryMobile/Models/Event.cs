using DeliveryMobile.CoreUti;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DeliveryMobile.Models
{
    public class Event : BaseObservableModel
    {
        public Event(DeliveryOrder cfg)
        {
            if (cfg != null)
                Config = ObjectExtension.CloneByJson(cfg);
            DeliveryInfo = new DeliveryInfo(Config);
        }
        public DeliveryOrder Config { get; set; } = new DeliveryOrder();
        public string JobNo { get; set; } = "";
        public DateTime TimeDelivery { get; set; } = DateTime.Today;
        public Color Color { get; set; }
        public Color CurrentDayColor { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; } = null;

    }
}
