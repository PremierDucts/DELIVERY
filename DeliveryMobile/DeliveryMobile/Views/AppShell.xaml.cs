using DeliveryMobile.Base;
using DeliveryMobile.ViewModels;
using DeliveryMobile.WebAPIClient.DeliveryServer;
using DeliveryMobile.WebAPIClient.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            if (CommonAPI.Login(new ServerConnectInfo { Address = Global.Instance.Address, UserName = Global.Instance.Username, Token = Global.Instance.Token }) == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("", "Access denied", "OK");
                    if (Device.RuntimePlatform == Device.Android)
                        Process.GetCurrentProcess().Kill();
                    else if (Device.RuntimePlatform == Device.iOS)
                        Thread.CurrentThread.Abort();
                });
            }
        }
    }
}
