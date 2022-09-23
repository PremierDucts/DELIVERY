using DeliveryMobile.Base;
using DeliveryMobile.Models;
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
        private AccordionPage accordionPage = new AccordionPage(new AccordionViewModel());
        public EventCalendarDeliveryPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new EventCalendarDeliveryViewModel();
            swipeViews = new List<SwipeView>();
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
            HandelAdd();
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
            HandelEdit(eventSelect);
        }

        private void AccordionPage_Disappearing(object sender, System.EventArgs e)
        {
            if (Global.Instance.IsSave)
            {
                if (accordionPage.ViewModel != null)
                {
                    if (!String.IsNullOrEmpty(accordionPage.ViewModel.JobNo))
                        eventSelect.DeliveryInfos = accordionPage.ViewModel.DeliveryInfos;
                    else
                    {
                        ViewModel.Events.Add(new Event()
                        {
                            JobNo = "New Item",
                            DeliveryInfos = accordionPage.ViewModel.DeliveryInfos
                        });
                    }
                }

            }
        }

        private void SwipePrint_Invoked(object sender, EventArgs e)
        {

        }
        private async void HandelEdit(Event ev)
        {
            ViewModel.IsRunningAnimation = true;
            await Task.Delay(1);
            var viewModelAccordionPage = new AccordionViewModel()
            {
                DeliveryInfos = ev.DeliveryInfos,
                JobNo = ev.JobNo,
            };
            accordionPage = new AccordionPage(viewModelAccordionPage);
            accordionPage.Disappearing += AccordionPage_Disappearing;
            await Shell.Current.Navigation.PushModalAsync(accordionPage);
            ViewModel.IsRunningAnimation = false;
        }

        private async void HandelAdd()
        {
            ViewModel.IsRunningAnimation = true;
            await Task.Delay(1);
            accordionPage = new AccordionPage(new AccordionViewModel());
            accordionPage.Disappearing += AccordionPage_Disappearing;
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
            HandelEdit(eventSelect);
        }
        #endregion


    }
}