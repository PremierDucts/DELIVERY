using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.ServerManager.PremierDuctsServer.APIModels
{
    public class LoginResponse
    {
        public int Status { get; set; } = 0;
        public LoginInfo Resource { get; set; } = new LoginInfo();
    }

    public class LoginInfo
    {
        public String Role { get; set; } = "";
        public String Factory { get; set; } = "";
        public String Position { get; set; } = "";
        public String Company { get; set; } = "";
        public String Country { get; set; } = "";
        public String Manager { get; set; } = "";
        public String Name { get; set; } = "";
        public String ProfilePath { get; set; } = "";
        public String IsVerified { get; set; } = "";
    }
}
