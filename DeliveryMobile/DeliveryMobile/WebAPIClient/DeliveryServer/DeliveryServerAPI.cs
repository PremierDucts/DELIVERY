using DeliveryMobile.WebAPIClient.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using static DeliveryMobile.WebAPIClient.DeliveryServer.Base;

namespace DeliveryMobile.WebAPIClient.DeliveryServer
{
    public static class DeliveryServerAPI
    {
        public static PreServerResponseData RequestApiProc<T>(ServerConnectInfo svrInfo,
            PREMIER_DUCTS_SERVER_API_TYPE apiType, Dictionary<String, String> listParams = null, Object postObj = null)
        {
            var res = CommonFuncs.RequestApi<T>(svrInfo, PremierDuctsServerApiBase.HttpCommands[apiType], GetApiTimeOut(apiType), listParams, postObj);
            if (res.IsFailed())
                return new PreServerResponseData { Code = PRE_SERVER_RETURN_CODE.FAIL, Data = res.Data };
            else
                return new PreServerResponseData { Code = (PRE_SERVER_RETURN_CODE)res.Code, Data = res.Data };
        }

        public static int GetApiTimeOut(PREMIER_DUCTS_SERVER_API_TYPE apiType)
        {
            switch (apiType)
            {
                default: return 10000;
            }
        }
    }
}
