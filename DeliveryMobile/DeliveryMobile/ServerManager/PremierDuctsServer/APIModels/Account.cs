using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.ServerManager.PremierDuctsServer.APIModels
{
    public class Account
    {
        [JsonIgnore]
        public static Account CurrentAccount = new Account();

        public String Username { get; set; } = "";
        public String Password { get; set; } = "";
        public String Token { get; set; } = "xyz";
    }

    public enum ACCOUNT_TYPE
    {
        ADMIN = 0,
        MANAGER,
        END_USER,
    }
}
