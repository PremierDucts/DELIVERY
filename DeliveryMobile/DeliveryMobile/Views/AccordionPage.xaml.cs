using DeliveryMobile.Base;
using DeliveryMobile.Models;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace DeliveryMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccordionPage : ContentPage
    {
        public AccordionViewModel ViewModel = null;
        public AccordionPage(DeliveryOrder cfg = null)
        {
            InitializeComponent();
            BindingContext = ViewModel = new AccordionViewModel(cfg);
        }
        #region [Event handel]
        private async void ButtonCancelAccordion_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void ButtonDesContact_Tapped(object sender, EventArgs e)
        {
            try
            {
                var result = await Contacts.PickContactAsync();
                if (result != null)
                {
                    var obj = sender as Frame;
                    if (obj != null)
                    {
                        var item = obj.BindingContext as Destination;
                        if (item != null)
                        {
                            var phones = new StringBuilder();
                            result.Phones.ForEach(phone =>
                            {
                                if (phones.Length == 0)
                                    phones.Append($"{phone}");
                                else
                                    phones.Append($" - {phone}");

                            });

                            var emails = new StringBuilder();
                            result.Emails.ForEach(email =>
                            {
                                if (emails.Length == 0)
                                    emails.Append($"{email}");
                                else
                                    emails.Append($" - {email}");

                            });

                            item.Phone = phones.ToString();
                            item.Name = result.DisplayName;
                            item.Email = emails.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void ButtonPicContact_Tapped(object sender, EventArgs e)
        {
            var result = await Contacts.PickContactAsync();
            if (result != null)
            {
                var phones = new StringBuilder();
                result.Phones.ForEach(phone =>
                {
                    if (phones.Length == 0)
                        phones.Append($"{phone}");
                    else
                        phones.Append($" - {phone}");

                });

                var emails = new StringBuilder();
                result.Emails.ForEach(email =>
                {
                    if (emails.Length == 0)
                        emails.Append($"{email}");
                    else
                        emails.Append($" - {email}");

                });

                ViewModel.Phone = phones.ToString();
                ViewModel.Name = result.DisplayName;
                ViewModel.Email = emails.ToString();
            }
        }


        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            #region Update value before create
            var listItem = new List<ItemDelivery>
            {
                new ItemDelivery()
                {
                     DepthDim = "test",
                     Description= "test",
                     Handle = "test",
                     Insulationarea = "test",
                     Itemno = "test",
                     Jobno = "test",
                     Lengthangle = "test",
                     Metalarea = "test",
                     StorageInfo = "test",
                     WidthDim = "test",
                }
            };
            ViewModel.Config.Items.AddRange(listItem);
            #endregion

            ViewModel.CreateOrder(ViewModel.Config);
            await Navigation.PopModalAsync();
        }

        private void ButtonAddDestination_Tapped(object sender, EventArgs e)
        {
            ViewModel.Destinations.Add(new Destination(new DeliveryPoint()));
            ViewModel.UpdateButtonSave();
        }

        private async void ButtonDelete_Tapped(object sender, EventArgs e)
        {
            if (await Application.Current.MainPage.DisplayAlert("", "Delete all destination?", "Yes", "Cancel"))
            {
                ViewModel.Destinations.Clear();
                ViewModel.UpdateButtonSave();
            }
        }

        private void ButtonAddStorage_Clicked(object sender, EventArgs e)
        {
            ViewModel.ListStorage.Add(new Storage());
        }
        #endregion


        private void Cage_Tapped(object sender, EventArgs e)
        {

        }
    }
}