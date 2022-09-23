using DeliveryMobile.Services;
using DeliveryMobile.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace DeliveryMobile.Base
{
    public static class LogWriter
    {
        private static String _logFolder = null;
        private static String LogFolder
        {
            get
            {
                if (_logFolder == null)
                    _logFolder = SaveFile.GetPath(SPECIAL_FOLDER.DOCUMENT, "DeliveryLogs");
                UtilityFunctions.CreateDirectory(_logFolder, false);
                return _logFolder;
            }
        }

        private static String FilePath
        {
            get
            {
                return Path.Combine(LogFolder, $"{DateTime.Now.ToString("yyyy_MM_dd")}_DeliveryLog.txt");
            }
        }

        private static Object lockWriteLog = new Object();
        public static void WriteLog(String log, Exception ex = null)
        {
            try
            {
                lock (lockWriteLog)
                {
                    var errorMessage = $"Time: {DateTime.Now}\n{log}\n";
                    if (ex != null)
                        errorMessage = $"{errorMessage}{ex.Message}\n{ex.StackTrace}\n";
                    File.AppendAllText(FilePath, $"{errorMessage}\n");
                }
            }
            catch { }
        }
    }
}
