using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.ServerManager.PremierDuctsServer.APIModels
{
    public class DeliveryOrder
    {
        public Pickup Pickup { get; set; } = new Pickup();
        public List<ItemDelivery> Items { get; set; } = new List<ItemDelivery>();
        public List<DeliveryPoint> DeliveryPoints { get; set; } = new List<DeliveryPoint>();
    }
}
