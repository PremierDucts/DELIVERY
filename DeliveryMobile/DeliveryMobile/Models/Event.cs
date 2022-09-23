using DeliveryMobile.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DeliveryMobile.Models
{
    public class Event : BaseObservableModel
    {
        public string JobNo { get; set; } = "";
        public DateTime TimeDelivery { get; set; } = DateTime.Today;
        public Color Color { get; set; }
        public Color CurrentDayColor { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; } = new DeliveryInfo();

    }
}
