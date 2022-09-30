using DeliveryMobile.Base;
using DeliveryMobile.Models;
using DeliveryMobile.ServerManager.PremierDuctsServer.APIModels;
using DeliveryMobile.Services;
using DeliveryMobile.WebAPIClient.DeliveryServer;
using DeliveryMobile.WebAPIClient.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;
using static DeliveryMobile.WebAPIClient.DeliveryServer.Base;

namespace DeliveryMobile.ViewModels
{
    public class EventCalendarDeliveryViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<EventDay> EventCalendar { get; set; } = new Calendar<EventDay>()
        {
            SelectedDates = new ObservableRangeCollection<DateTime>(),
            SelectionAction = SelectionAction.Replace,
            SelectionType = SelectionType.Single
        };
        public static readonly Random Random = new Random();
        public List<Color> Colors { get; } = new List<Color>() { Color.Red, Color.Orange, Color.Yellow, Color.FromHex("#00A000"), Color.Blue, Color.FromHex("#8010E0") };
        public List<Color> ColorsOnDay { get; } = new List<Color>() { Color.Red, Color.Orange, Color.Blue, Color.Brown, Color.Blue, Color.CadetBlue, Color.DarkMagenta, Color.Aqua, Color.Coral, Color.YellowGreen, Color.SeaGreen, Color.DeepPink };
        public ObservableRangeCollection<Event> Events { get; } = new ObservableRangeCollection<Event>();
        public ObservableRangeCollection<Event> SelectedEvents { get; } = new ObservableRangeCollection<Event>();

        public DateTime CurrentDay => DateTime.Now;

        private bool _isVisibleCalendar = true;
        public bool IsVisibleCalendar
        {
            get { return _isVisibleCalendar; }
            set
            {
                _isVisibleCalendar = value;
                OnPropertyChanged("IsVisibleCalendar");
            }
        }

        private bool _isRunningAnimation = false;
        public bool IsRunningAnimation
        {
            get { return _isRunningAnimation; }
            set
            {
                _isRunningAnimation = value;
                OnPropertyChanged("IsRunningAnimation");
            }
        }
        #endregion

        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ChangeDateSelectionCommand { get; set; }
        #endregion

        #region Constructors
        public EventCalendarDeliveryViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
            var orders = GetOrder();
            foreach (var item in orders) { }
            foreach (Event Event in Events)
            {
                Event.TimeDelivery = DateTime.Today.AddDays(Random.Next(-20, 21)).AddSeconds(Random.Next(86400));
                Event.Color = Colors[Random.Next(6)];
            }

            EventCalendar.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
            EventCalendar.DaysUpdated += EventCalendar_DaysUpdated;
            var index = 0;
            foreach (var Day in EventCalendar.Days)
            {
                var listEvents = Events.Where(x => x.TimeDelivery.Date == Day.DateTime.Date);
                var color = ColorsOnDay[Random.Next(12)];
                foreach (var ev in listEvents)
                    ev.CurrentDayColor = color;
                Day.Events.ReplaceRange(listEvents);
                index++;
            }
        }

        private void SelectedDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SelectedEvents.ReplaceRange(Events.Where(x => EventCalendar.SelectedDates.Any(y => x.TimeDelivery.Date == y.Date)).OrderBy(x => x.TimeDelivery).ThenBy(z => z.TimeDelivery.TimeOfDay));
        }
        #endregion

        #region Methods

        private List<DeliveryOrder> GetOrder()
        {
            var result = CommonAPI.GetOrder(new ServerConnectInfo { Address = Global.Instance.DeliveryAddress }, 1661996551, 1664502151);
            if (result.Code != PRE_SERVER_RETURN_CODE.Ok)
                return new List<DeliveryOrder>();
           return result.Data as List<DeliveryOrder>;
        }

        private void EventCalendar_DaysUpdated(object sender, EventArgs e)
        {
            foreach (var Day in EventCalendar.Days)
            {
                Day.Events.ReplaceRange(Events.Where(x => x.TimeDelivery.Date == Day.DateTime.Date));
            }
        }
        public void NavigateCalendar(int Amount)
        {
            EventCalendar?.NavigateCalendar(Amount);
        }
        public void ChangeDateSelection(DateTime DateTime)
        {
            EventCalendar?.ChangeDateSelection(DateTime);
        }
        #endregion
    }
}
