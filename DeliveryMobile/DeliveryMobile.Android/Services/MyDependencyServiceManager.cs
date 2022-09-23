using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveryMobile.Base;
using DeliveryMobile.Droid.Services;
using DeliveryMobile.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyDependencyServiceManager))]
namespace DeliveryMobile.Droid.Services
{
    public class MyDependencyServiceManager : IMyDependencyService
    {
        public void EnterFullScreen()
        {
            Window window = Platform.CurrentActivity.Window;
            window.AddFlags(WindowManagerFlags.Fullscreen);
        }

        public void ExitFullScreen()
        {
            Window window = Platform.CurrentActivity.Window;
            window.ClearFlags(WindowManagerFlags.Fullscreen);
        }

        public void LongShowToast(string msg)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Android.Widget.Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Long).Show();
            });
        }

        public void ShortShowToast(string msg)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Android.Widget.Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Short).Show();
            });
        }

        public void CloseApplication()
        {
            //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            var activity = (Activity)Android.App.Application.Context;
            activity.FinishAffinity();
        }

        public String GetPath(SPECIAL_FOLDER specialFolder, String customFolder)
        {
            var root = Android.OS.Environment.DirectoryDocuments;
            switch (specialFolder)
            {
                case SPECIAL_FOLDER.DOCUMENT:
                    root = Android.OS.Environment.DirectoryDocuments;
                    break;
                case SPECIAL_FOLDER.PICTURE:
                    root = Android.OS.Environment.DirectoryPictures;
                    break;
                case SPECIAL_FOLDER.VIDEO:
                    root = Android.OS.Environment.DirectoryMovies;
                    break;
                case SPECIAL_FOLDER.MUSIC:
                    root = Android.OS.Environment.DirectoryMusic;
                    break;
                case SPECIAL_FOLDER.DOWNLOAD:
                    root = Android.OS.Environment.DirectoryDownloads;
                    break;
                case SPECIAL_FOLDER.DCIM:
                    root = Android.OS.Environment.DirectoryDcim;
                    break;
                default:
                    root = Android.OS.Environment.DirectoryDocuments;
                    break;
            }
            return Android.OS.Environment.GetExternalStoragePublicDirectory(Path.Combine(root, customFolder)).AbsolutePath;
        }

    }
}