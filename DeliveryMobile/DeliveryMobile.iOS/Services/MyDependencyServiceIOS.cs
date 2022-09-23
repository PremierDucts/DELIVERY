using DeliveryMobile.Base;
using DeliveryMobile.iOS.Services;
using DeliveryMobile.Services;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UIKit;
using static System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(MyDependencyServiceIOS))]
namespace DeliveryMobile.iOS.Services
{
    class MyDependencyServiceIOS : IMyDependencyService
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;
        public void EnterFullScreen()
        {
            //dismissMessage();
            if (alert != null)
            {
                alert.DismissViewController(true, null);

            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

        public void ExitFullScreen()
        {
            // dismissMessage();
            if (alert != null)
            {
                alert.DismissViewController(false, null);
            }
        }

        public void ResetNotification()
        {
            UIKit.UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }

        public void LongShowToast(string msg)
        {
            ShowAlert(msg, LONG_DELAY);
        }

        public void ShortShowToast(string msg)
        {
            ShowAlert(msg, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        public void CloseApplication()
        {
            Thread.CurrentThread.Abort();
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

        public String GetPath(SPECIAL_FOLDER specialFolder, String customFolder)
        {
            var root = SpecialFolder.MyDocuments;
            switch (specialFolder)
            {
                case SPECIAL_FOLDER.DOCUMENT:
                    root = SpecialFolder.MyDocuments;
                    break;
                case SPECIAL_FOLDER.PICTURE:
                    root = SpecialFolder.MyPictures;
                    break;
                case SPECIAL_FOLDER.VIDEO:
                    root = SpecialFolder.MyVideos;
                    break;
                case SPECIAL_FOLDER.MUSIC:
                    root = SpecialFolder.MyMusic;
                    break;
                case SPECIAL_FOLDER.DOWNLOAD:
                    root = SpecialFolder.MyDocuments;
                    break;
                case SPECIAL_FOLDER.DCIM:
                    root = SpecialFolder.MyPictures;
                    break;
                default:
                    root = SpecialFolder.MyDocuments;
                    break;
            }
            return Path.Combine(GetFolderPath(root), customFolder);
        }
    }
}