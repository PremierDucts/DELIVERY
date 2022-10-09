using DeliveryMobile.Base;
using DeliveryMobile.Models;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public AccordionPage(DeliveryOrder cfg = null, bool isUpdate = false)
        {
            InitializeComponent();
            BindingContext = ViewModel = new AccordionViewModel(cfg, isUpdate);
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
                            item.Name = String.IsNullOrEmpty(result.DisplayName) ? "Empty name" : result.DisplayName;
                            item.Email = String.IsNullOrEmpty(emails.ToString()) ? "test@gmail.com" : emails.ToString();
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
                ViewModel.Name = String.IsNullOrEmpty(result.DisplayName) ? "Empty name" : result.DisplayName;
                ViewModel.Email = String.IsNullOrEmpty(emails.ToString()) ? "test@gmail.com" : emails.ToString();
            }
        }


        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            #region Update value before create
            var deliveryPoints = new List<DeliveryPoint>();
            foreach (var des in ViewModel.Destinations)
            {
                deliveryPoints.Add(new DeliveryPoint
                { 
                    Name = des.Name,
                    AddressDetail = des.AddressDetail,
                    City = des.City,
                    CompanyName = des.CompanyName,
                    Country = des.Country,
                    Email = des.Email,
                    IsDefault = des.IsDefault,
                    Notes = des.Email,
                    Phone = des.Phone,
                    PlanningTime = des.PlanningTime.Ticks,
                    PostalCode = des.PostalCode,
                    State = des.State
                });
            }

            var listItem = new List<ItemDelivery>();
            foreach (var storage in ViewModel.Cages)
            {
                foreach (var item in storage.ListStorageDetail)
                {
                    if (item.IsSelected)
                        listItem.Add(item.Config);
                }
            }

            ViewModel.Config.Items.Clear();
            ViewModel.Config.DeliveryPoints.Clear();

            ViewModel.Config.PickupPoint.PlanningTime = ViewModel.PlanningTime.Ticks;
            ViewModel.Config.DeliveryPoints.AddRange(deliveryPoints);
            ViewModel.Config.Items.AddRange(listItem);
            #endregion

            ViewModel.AddOrUpdateOrder(ViewModel.Config);
        }

        private void ButtonAddDestination_Tapped(object sender, EventArgs e) => ViewModel.AddDestination();

        private async void ButtonDelete_Tapped(object sender, EventArgs e)
        {
            if (await Application.Current.MainPage.DisplayAlert("", "Delete delivery?", "Yes", "Cancel"))
            {
                ViewModel.DeleteOrder(ViewModel.Config.Id);
            }
        }
        #endregion

        private void ExpandedDelivery_Tapped(object sender, EventArgs e)
        {
            ViewModel.IsExpandedDelivery = !ViewModel.IsExpandedDelivery;
        }

        private void ExpandedDestination_Tapped(object sender, EventArgs e)
        {
            var obj = sender as Frame;
            var des = obj.BindingContext as Destination;
            if (des == null)
                return;
            des.IsExpandedDestination = !des.IsExpandedDestination;
        }
    }
}