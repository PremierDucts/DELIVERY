using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.ServerManager.PremierDuctsServer.APIModels
{
    public class Pickup
    {
        public String Id { get; set; } = "";
        public String Name { get; set; } = "";
        public String Phone { get; set; } = "";
        public String Email { get; set; } = "empty@gmail.com";
        public String CompanyName { get; set; } = "empty";
        public String AddressDetail { get; set; } = "empty";
        public String PostalCode { get; set; } = "empty";
        public String City { get; set; } = "empty";
        public String State { get; set; } = "empty";
        public String Country { get; set; } = "empty";
        public String Notes { get; set; } = "empty";
        public bool IsDefault { get; set; } = false;
        public long PlanningTime { get; set; } = DateTime.Now.Ticks;
    }
}
