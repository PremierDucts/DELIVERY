using DeliveryMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.Base
{
    public class Global
    {
        #region [Singleton]
        private Global() { }

        private static Global _instance;
        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Global();
                }
                return _instance;
            }
        }
        #endregion

        public bool IsSave { get; set; } = false;
        #region [Login]
        public String Address { get; set; } = "app.premierducts.com.au/authenticate.php";
        public String Username { get; set; } = "testnsw";
        public String Token { get; set; } = "c7cd706fa62e37656eb7604218b076003f2d0c79dfd64ceaa880f09d11c47bf929941a34dccaae1bc04d3b2732a48ba6187c94bc23f48d04b2c8639188d0b56e";

        #endregion

        #region [Address API]
        public String DeliveryAddress { get; set; } = "phat2.premierducts.com.au";
        public String DeliveryAddressQLD { get; set; } = "qlddata.y.fo/dashboard";
        #endregion
    }
}
