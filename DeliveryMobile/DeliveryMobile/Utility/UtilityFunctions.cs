using DeliveryMobile.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeliveryMobile.Utility
{
    public class UtilityFunctions
    {
        public static bool CreateDirectory(String path, bool isWriteLog = true)
        {
            try
            {
                try
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    return true;
                }
                catch (Exception ex)
                {
                    if (isWriteLog)
                        LogWriter.WriteLog("CreateDirectory failed: " + path + "\n" + ex.Message + "\n" + ex.StackTrace);
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
