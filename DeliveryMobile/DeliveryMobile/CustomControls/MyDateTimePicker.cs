using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DeliveryMobile.CustomControls
{
    public class MyDateTimePicker : ContentView, INotifyPropertyChanged
    {
        private Label _label { get; set; } = new Label() { WidthRequest = 300, FontSize = 18, TextColor = Color.Black, FontAttributes = FontAttributes.None };
        private DatePicker _datePicker { get; set; } = new DatePicker() { IsVisible = false };
        private TimePicker _timePicker { get; set; } = new TimePicker() { IsVisible = false };
        private string _stringFormat { get; set; }
        private TimeSpan _time
        {
            get { return TimeSpan.FromTicks(DateTime.Ticks); }
            set { DateTime = new DateTime(DateTime.Date.Ticks).AddTicks(value.Ticks); }
        }
        private DateTime _date
        {
            get { return DateTime.Date; }
            set { DateTime = new DateTime(DateTime.TimeOfDay.Ticks).AddTicks(value.Ticks); }
        }

        public string StringFormat { get { return _stringFormat ?? "dd/MM/yyyy HH:mm"; } set { _stringFormat = value; } }
        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); OnPropertyChanged(nameof(DateTime)); }
        }

        public static BindableProperty DateTimeProperty = BindableProperty.Create(nameof(DateTime), typeof(DateTime), typeof(MyDateTimePicker), DateTime.Now, BindingMode.TwoWay, propertyChanged: DTPropertyChanged);

        public MyDateTimePicker()
        {
            Content = new StackLayout()
            {
                Children = { _datePicker, _timePicker, _label }
            };

            _datePicker.SetBinding(DatePicker.DateProperty, nameof(_date));
            _timePicker.SetBinding(TimePicker.TimeProperty, nameof(_time));
            _timePicker.Unfocused += (sender, args) => _time = _timePicker.Time;
            _datePicker.Focused += (s, a) => UpdateEntryText();

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => _datePicker.Focus())
            });

            var _labelTapGestureRecognizer = new TapGestureRecognizer();
            _labelTapGestureRecognizer.Tapped += (s, e) => {
                Device.BeginInvokeOnMainThread(() => _datePicker.Focus());
            };
            _label.GestureRecognizers.Add(_labelTapGestureRecognizer);
            _datePicker.Unfocused += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _timePicker.Focus();
                    _date = _datePicker.Date;
                    UpdateEntryText();
                });
            };
        }

        private void UpdateEntryText()
        {
            _label.Text = DateTime.ToString(StringFormat);
        }

        private static void DTPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var timePicker = bindable as MyDateTimePicker;
            timePicker.UpdateEntryText();
        }
    }
}
