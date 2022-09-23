using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.Settings.PremierDuctsServerSettings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.WebAPIClient.Utility
{
    public class ResponseData
    {
        public int Code { get; set; }
        public Object Data { get; set; }

        public ResponseData()
        {
            Code = int.MinValue;
            Data = null;
        }
        public bool IsFailed() { return Code == int.MinValue; }
        public void MakeFailed() { Code = int.MinValue; Data = ""; }
    }

    public class ServerConnectInfo
    {
        public String Address { set; get; } = "";
        public String Port { set; get; } = "";
        public String Token { set; get; } = "";
        public String UserName { set; get; } = "";
        public String Password { set; get; } = "";

        public ServerConnectInfo() { }
    }

    public class CommonFuncs
    {
        public static ResponseData RequestApi<T>(ServerConnectInfo svrInfo,
                String apiCommand, int timeOut, Dictionary<String, String> listParams = null, Object postObj = null)
        {
            var resData = new ResponseData();
            try
            {
                if (listParams == null)
                    listParams = new Dictionary<String, String>();
                if (!String.IsNullOrEmpty(Account.CurrentAccount.Token))
                    listParams["Token"] = Account.CurrentAccount.Token;

                String response = null;
                String requestUrl = $"https://{svrInfo.Address}/{apiCommand}";

                if (requestUrl.Contains("station/all/duration"))
                {
                    foreach (var item in listParams)
                    {
                        if (item.Key.Equals("jobNo"))
                        {
                            requestUrl = $"{requestUrl}/{item.Value}";
                            break;
                        }
                    }
                    listParams.Remove("jobNo");
                }

                if (postObj == null)
                    response = HttpClientUti.SendGetRequest(requestUrl, listParams, timeOut);
                else
                    response = HttpClientUti.SendPostRequest(requestUrl, postObj, listParams, timeOut);

                if (resData != null)
                {
                    resData = JsonConvert.DeserializeObject<ResponseData>(response);
                    if (resData != null)
                        ConvertData<T>(resData);
                    else
                        return new ResponseData { Data = "Can not parse response string!" };
                }
                else
                    resData.Data = "Connect Failed!";
            }
            catch (Exception ex)
            {
                resData.Data = ex.Message;
            }
            return resData;
        }

        private static bool ConvertData<T>(ResponseData resData)
        {
            try
            {
                if (typeof(T).IsValueType)
                    return true;
                else if (resData.Data.GetType() == typeof(JArray))
                    resData.Data = ((JArray)resData.Data).ToObject<T>();
                else if (resData.Data.GetType() == typeof(Object))
                    resData.Data = ((JObject)resData.Data).ToObject<T>();
                return true;
            }
            catch (Exception ex)
            {
                resData.Data = ex.Message;
                resData.MakeFailed();
                return false;
            }
        }
    }
}
