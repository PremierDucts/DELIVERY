using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.ServerManager.PremierDuctsServer.APIModels
{
    public class ItemDelivery
    {
        public String StorageInfo { get; set; } = "";
        public String Jobno { get; set; } = "";
        public String Itemno { get; set; } = "";
        public String Handle { get; set; } = "";
        public String Insulationarea { get; set; } = "";
        public String Metalarea { get; set; } = "";
        public String WidthDim { get; set; } = "";
        public String DepthDim { get; set; } = "";
        public String Lengthangle { get; set; } = "";
        public String Description { get; set; } = "";
    }
}
