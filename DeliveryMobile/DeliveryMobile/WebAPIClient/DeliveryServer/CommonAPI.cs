
using DeliveryMobile.Base;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.WebAPIClient.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static DeliveryMobile.WebAPIClient.DeliveryServer.Base;

namespace DeliveryMobile.WebAPIClient.DeliveryServer
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
            catch (Exception ex) { }
            return null;
        }

        public static PreServerResponseData GetOrder(ServerConnectInfo svrInfo, long startOfMonth, long endOfMonth)
        {
            return DeliveryServerAPI.RequestApiProc<List<DeliveryOrder>>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.GET_ORDER, new Dictionary<string, string>() { { "startOfMonth", startOfMonth.ToString()}, { "endOfMonth", endOfMonth.ToString() } });
        }

        public static PreServerResponseData CreateOrder(ServerConnectInfo svrInfo, DeliveryOrder order)
        {
            return DeliveryServerAPI.RequestApiProc<DeliveryOrder>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.CREATE_ORDER, null, order);
        }

        public static PreServerResponseData DeleteOrder(ServerConnectInfo svrInfo)
        {
            return DeliveryServerAPI.RequestApiProc<DeliveryOrder>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.GET_ORDER);
        }

        public static PreServerResponseData UpdateOrder(ServerConnectInfo svrInfo)
        {
            return DeliveryServerAPI.RequestApiProc<DeliveryOrder>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.GET_ORDER);
        }

        public static PreServerResponseData GetAllCages(ServerConnectInfo svrInfo)
        {
            return DeliveryServerAPI.RequestApiProc<List<Cages>>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.GET_ALL_CAGES);
        }
    }
}
