using DeliveryMobile.Base;
using DeliveryMobile.Models;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventCalendarDeliveryPage : ContentPage
    {
        private EventCalendarDeliveryViewModel ViewModel = null;
        private List<SwipeView> swipeViews { set; get; } = null;
        private Event eventSelect { set; get; } = null;
        public EventCalendarDeliveryPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new EventCalendarDeliveryViewModel();
            swipeViews = new List<SwipeView>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.UpdateData();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (swipeViews.Count == 1)
            {
                swipeViews[0].Close();
                swipeViews.Remove(swipeViews[0]);
            }
        }
        #region [Event handel]
        private void ButtonCalendar_Clicked(object sender, System.EventArgs e)
        {
            ViewModel.IsVisibleCalendar = !ViewModel.IsVisibleCalendar;
        }

        private void ButtonAddAccordion_Clicked(object sender, System.EventArgs e)
        {
            HandelAddOrUpdate(new Event(new DeliveryOrder()), false);
        }

        private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            if (swipeViews.Count == 1)
            {
                swipeViews[0].Close();
                swipeViews.Remove(swipeViews[0]);
            }
        }

        private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            var obj = sender as SwipeView;
            if (obj == null)
                return;
            swipeViews.Add(obj);
        }

        private void SwipeEditItem_Invoked(object sender, System.EventArgs e)
        {
            var obj = sender as SwipeItem;
            if (obj == null)
                return;
            eventSelect = obj.BindingContext as Event;
            if (eventSelect == null)
                return;
            HandelAddOrUpdate(eventSelect, true);
        }

        private void SwipePrint_Invoked(object sender, EventArgs e)
        {

        }

        private async void HandelAddOrUpdate(Event ev, bool isUpdate)
        {
            ViewModel.IsRunningAnimation = true;
            await Task.Delay(1);
            var accordionPage = new AccordionPage(ev.Config, isUpdate);
            accordionPage.ViewModel.JobNo = "Delivery";
            await Shell.Current.Navigation.PushModalAsync(accordionPage);
            ViewModel.IsRunningAnimation = false;
        }
        private void ButtonPrint_Tapped(object sender, EventArgs e)
        {

        }

        private void ButtonEdit_Tapped(object sender, EventArgs e)
        {
            var obj = sender as Label;
            if (obj == null)
                return;
            eventSelect = obj.BindingContext as Event;
            if (eventSelect == null)
                return;
            HandelAddOrUpdate(eventSelect,true);
        }

        #endregion

        private void ExpandedDelivery_Tapped(object sender, EventArgs e)
        {
            var obj = sender as Grid;
            var item = obj.BindingContext as Event;
            if (item == null)
                return;
            item.IsExpandedDelivery = !item.IsExpandedDelivery;
        }

        private void ExpandedDestination_Tapped(object sender, EventArgs e)
        {
            var obj = sender as Grid;
            var item = obj.BindingContext as Event;
            if (item == null)
                return;
            item.IsExpandedDestination = !item.IsExpandedDestination;
        }

        private void ExpandedItem_Tapped(object sender, EventArgs e)
        {
            var obj = sender as Grid;
            var item = obj.BindingContext as Event;
            if (item == null)
                return;
            item.IsExpandedItem = !item.IsExpandedItem;
        }

        private void SwipeDelete_Invoked(object sender, EventArgs e)
        {
            var obj = sender as SwipeItem;
            if (obj == null)
                return;
            eventSelect = obj.BindingContext as Event;
            if (eventSelect == null)
                return;
            ViewModel.DeleteOrder(eventSelect.Config.Id);
        }
    }
}