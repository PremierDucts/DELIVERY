using DeliveryMobile.Base;
using DeliveryMobile.Settings.PremierDuctsServerSettings;
using Newtonsoft.Json;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.Settings.BaseSettings
{
    public enum ENUM_SETTINGS
    {
        #region Local Settings
        PREMIER_DUCTS_SERVER_SETTING = 0,
        #endregion
    }

    [Serializable]
    public class BaseSetting
    {
        [JsonIgnore]
        public Object LockFileCfg { set; get; } = new Object();
        [JsonIgnore]
        public ENUM_SETTINGS ConfigType { set; get; }

        [JsonIgnore]
        public bool IsConfigChanged { set; get; } = false;

        public BaseSetting()
        {
            if (GetType() == typeof(PremierDuctsServerSetting))
                ConfigType = ENUM_SETTINGS.PREMIER_DUCTS_SERVER_SETTING;
        }

        public void CheckForSaveConfig()
        {
            if (IsConfigChanged)
            {
                IsConfigChanged = false;
                SaveConfig();
            }
        }

        public void SaveConfig()
        {
            lock (this.LockFileCfg)
            {
                try
                {
                    String encryptStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this)));
                    if (encryptStr != null)
                        CrossSettings.Current.AddOrUpdateValue(ConfigType.ToString(), encryptStr);
                }
                catch (Exception ex) { LogWriter.WriteLog($"SaveConfig '{ConfigType.ToString()}': {ex.Message}\n{ex.StackTrace}"); }
            }
        }

        public Object LoadCfg()
        {
            lock (LockFileCfg)
            {
                BaseSetting usingCfg = this;
                try
                {
                    var encryptStr = CrossSettings.Current.GetValueOrDefault(ConfigType.ToString(), String.Empty);
                    if (!String.IsNullOrEmpty(encryptStr))
                    {
                        String jsonStr = Encoding.UTF8.GetString(Convert.FromBase64String(encryptStr));
                        if (jsonStr != null)
                        {
                            var cfg = JsonConvert.DeserializeObject(jsonStr, GetType()) as BaseSetting;
                            if (cfg != null)
                            {
                                cfg.ConfigType = ConfigType;
                                usingCfg = cfg;
                                return cfg;
                            }
                        }
                    }
                }
                catch (Exception ex) { LogWriter.WriteLog($"LoadCfg '{ConfigType}': {ex.Message}\n{ex.StackTrace}"); }
                return null;
            }
        }
    }
}
