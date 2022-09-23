using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.WebAPIClient.PremierDuctServer
{
    public class Base
    {
        public enum PRE_SERVER_RETURN_CODE
        {
            #region General Group
            SUCCESS = 0,
            FAIL,
            COMMAND_NOT_FOUND,
            TOKEN_INVALID_OR_EXPIRED,
            ACCESS_DENIED,
            INVALID_PARAM,
            API_NOT_SUPPORT,
            INCOMPATIBLE_VERSION,
            PLATFROM_NOT_SUPPORT,
            INTERNAL_ERROR,
            INVALID_DATA,
            #endregion

            #region appuser database
            APPUSER_WRONG_PASSWORD_USERNAME = 100000,
            APPUSER_CANNOT_SAVE_TOKEN,
            APPUSER_CANNOT_GET_USER_FOR_REPORT,
            APPUSER_CANNOT_GET_OFFLINE_USER,
            APPUSER_CANNOT_GET_TOKEN_REQUEST,
            #endregion

            #region premier database
            PREMIERDB_DATA_IS_NULL = 200000,
            #endregion
        }

        public class PreServerResponseData
        {
            public PRE_SERVER_RETURN_CODE Code { get; set; }
            public Object Data { get; set; }

            public PreServerResponseData()
            {
                this.Code = PRE_SERVER_RETURN_CODE.FAIL;
                this.Data = "";
            }
        }

        public enum PREMIER_DUCTS_SERVER_API_TYPE
        {
            #region [COMMON]
            LOGIN = 0,
            #endregion

            #region [APP_USER]
            APP_USER_GET_ONLINE_USER,
            APP_USER_GET_OFFLINE_USER,
            #endregion

            #region [PREMIER_DUCTS]
            PREMIER_DUCTS_GET_ALL_JOBTIMING,
            PREMIER_DUCTS_GET_ALL_JOBTIMING_DETAIL_BY_DATE,
            PREMIER_DUCTS_GET_STATION_DATA,
            PREMIER_DUCTS_GET_ALL_JOBTIMING_DATES,
            PREMIER_DUCTS_GET_ALL_DURATION_STATION,
            #endregion

            #region [QLD_DATA]
            QLD_GET_ALL,
            QLD_TOTAL_ALL_M2
            #endregion

        }

        public class PremierDuctsServerApiBase
        {
            public static Dictionary<PREMIER_DUCTS_SERVER_API_TYPE, String> HttpCommands = new Dictionary<PREMIER_DUCTS_SERVER_API_TYPE, String>()
            {
                #region [COMMON]
                {PREMIER_DUCTS_SERVER_API_TYPE.LOGIN, "" },
                #endregion

                #region [APP_USER]
               
                {PREMIER_DUCTS_SERVER_API_TYPE.APP_USER_GET_OFFLINE_USER, "user/getOfflineUsers" },
                {PREMIER_DUCTS_SERVER_API_TYPE.APP_USER_GET_ONLINE_USER, "user/getOnlineUsers" },
                #endregion

                #region [PREMIER_DUCTS]
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_JOBTIMING, "jobtiming/data/detail" },
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_JOBTIMING_DETAIL_BY_DATE, "jobtiming/all/data/by_date"},

                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_STATION_DATA, "station/all"},
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_JOBTIMING_DATES, "jobtiming/list/dates" },
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_DURATION_STATION, "station/all/duration" },

                #endregion

                #region [QLD_DATA]
                {PREMIER_DUCTS_SERVER_API_TYPE.QLD_GET_ALL, "dashboard/get/all/qldata"},
                {PREMIER_DUCTS_SERVER_API_TYPE.QLD_TOTAL_ALL_M2, "dashboard/total/all/m2"},
                #endregion
            };
        }
    }
}
