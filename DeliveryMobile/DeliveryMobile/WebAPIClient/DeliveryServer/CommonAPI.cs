
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
                PREMIER_DUCTS_SERVER_API_TYPE.GET_ORDER, HttpType.GET, new Dictionary<string, string>() { { "startOfMonth", startOfMonth.ToString() }, { "endOfMonth", endOfMonth.ToString() } });
        }

        public static PreServerResponseData CreateOrder(ServerConnectInfo svrInfo, DeliveryOrder order)
        {
            return DeliveryServerAPI.RequestApiProc<DeliveryOrder>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.CREATE_ORDER, HttpType.POST, null, order);
        }

        public static PreServerResponseData DeleteOrder(ServerConnectInfo svrInfo, String id)
        {
            return DeliveryServerAPI.RequestApiProc<DeliveryOrder>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.DELETE_ORDER, HttpType.DELETE, new Dictionary<string, string> { { "id", id } });
        }

        public static PreServerResponseData UpdateOrder(ServerConnectInfo svrInfo, DeliveryOrder order)
        {
            return DeliveryServerAPI.RequestApiProc<DeliveryOrder>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.UPDATE_ORDER, HttpType.PUT, new Dictionary<string, string> { { "id", order.Id } }, order);
        }

        public static PreServerResponseData GetAllCages(ServerConnectInfo svrInfo)
        {
            return DeliveryServerAPI.RequestApiProc<List<Cages>>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.GET_ALL_CAGES, HttpType.GET);
        }

        public static PreServerResponseData GetAllItem(ServerConnectInfo svrInfo, String cageName)
        {
            return DeliveryServerAPI.RequestApiProc<List<ItemDelivery>>(svrInfo,
                PREMIER_DUCTS_SERVER_API_TYPE.GET_ALL_ITEM, HttpType.GET, new Dictionary<string, string>() { { "cageName", cageName } });
        }
    }
}
