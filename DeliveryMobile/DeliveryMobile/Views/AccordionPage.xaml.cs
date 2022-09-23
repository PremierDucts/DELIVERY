using DeliveryMobile.Base;
using DeliveryMobile.Models;
using DeliveryMobile.ViewModels;
using System;
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
        public AccordionPage(AccordionViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
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

                            item.DesPhone = phones.ToString();
                            item.DesContactName = result.DisplayName;
                            item.DesEmailAddress = emails.ToString();
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
                var obj = sender as Frame;
                if (obj != null)
                {
                    var item = obj.BindingContext as DeliveryInfo;
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

                        item.PicPhone = phones.ToString();
                        item.PicContactName = result.DisplayName;
                        item.PicEmailAddress = emails.ToString();
                    }
                }
            }
        }


        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            Global.Instance.IsSave = true;
            await Navigation.PopModalAsync();
        }

        private void ButtonAddDestination_Tapped(object sender, EventArgs e)
        {
            ViewModel.DeliveryInfos.Add(new DeliveryInfo());
            ViewModel.UpdateButtonSave();
        }

        private async void ButtonDelete_Tapped(object sender, EventArgs e)
        {
            if (await Application.Current.MainPage.DisplayAlert("", "Delete all destination?", "Yes", "Cancel"))
            {
                ViewModel.DeliveryInfos.Clear();
                ViewModel.UpdateButtonSave();
            }
        }

        private void ButtonAddStorage_Clicked(object sender, EventArgs e)
        {
            var obj = sender as Button;
            var item = obj.BindingContext as DeliveryInfo;
            item.ListStorage.Add(new Storage());
        }
        #endregion
    }
}