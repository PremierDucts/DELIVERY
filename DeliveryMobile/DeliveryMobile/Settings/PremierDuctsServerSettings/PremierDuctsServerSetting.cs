using DeliveryMobile.Settings.BaseSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.Settings.PremierDuctsServerSettings
{
    public class PremierDuctsServerSetting : BaseSetting
    {
        #region Instance
        private static Object LockInstance { set; get; } = new Object();
        private static PremierDuctsServerSetting _instance { set; get; } = null;
        [JsonIgnore]
        public static PremierDuctsServerSetting Instance
        {
            get
            {
                lock (LockInstance)
                {
                    if (_instance == null)
                    {
                        _instance = new PremierDuctsServerSetting();
                        Object cfg = _instance.LoadCfg();
                        if (cfg != null)
                            _instance = cfg as PremierDuctsServerSetting;
                    }
                    return _instance;
                }
            }
        }
        #endregion Instance

        public PremierDuctsServerCfg PremierDuctsServer { set; get; }

        public PremierDuctsServerSetting() => PremierDuctsServer = new PremierDuctsServerCfg();
    }
    public class PremierDuctsServerCfg
    {
        public String Id { set; get; } = Guid.NewGuid().ToString();
        public String Name { set; get; } = "Default Server";
        public String Address { set; get; } = "";
        public int HttpPort { set; get; } = 18000;
    }
}
