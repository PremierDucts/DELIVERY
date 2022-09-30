using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.ServerManager.PremierDuctsServer.APIModels
{
    public class Pickup
    {
        public String Name { get; set; } = "";
        public String Phone { get; set; } = "";
        public String Email { get; set; } = "";
        public String CompanyName { get; set; } = "";
        public String AddressDetail { get; set; } = "";
        public String PostalCode { get; set; } = "";
        public String City { get; set; } = "";
        public String State { get; set; } = "";
        public String Country { get; set; } = "";
        public String Notes { get; set; } = "";
        public bool IsDefault { get; set; }
        public long PlanningTime { get; set; }
    }
}
