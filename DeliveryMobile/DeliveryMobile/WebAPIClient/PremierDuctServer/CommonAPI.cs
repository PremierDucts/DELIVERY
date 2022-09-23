
using DeliveryMobile.Base;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.WebAPIClient.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static DeliveryMobile.WebAPIClient.PremierDuctServer.Base;

namespace DeliveryMobile.WebAPIClient.PremierDuctServer
{
    public class CommonAPI
    {
        public static LoginResponse Login(ServerConnectInfo svrInfo)
        {
            try
            {
                var result = HttpClientUti.SendPostRequestLogin(svrInfo);
                if (result != null)
                    return JsonConvert.DeserializeObject<LoginResponse>(result);
            }
            catch (Exception ex){}
            return null;
        }
    }
}
