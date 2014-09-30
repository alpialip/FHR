
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using PersonaHealth.ViewModels;

namespace PersonaHealth
{
    public partial class Medication : PhoneApplicationPage
    {
        SampleAppointmentSource appointmentsSource = new SampleAppointmentSource();

        public Medication()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(FirstLook_Loaded);
        }

        void FirstLook_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayAppointmentsForDate(DateTime.Now.Date);
        }

        private void DisplayAppointmentsForDate(DateTime date)
        {
            appointmentsSource.FetchData(date, date.AddDays(1));
            this.AppointmentsList.ItemsSource = appointmentsSource.GetAppointments((IAppointment appointment) =>
            {
                DateTime currentAppointmentStart = appointment.StartDate;
                DateTime currentAppointmentEnd = appointment.EndDate;
                DateTime requiredAppointmentsStartDate = date.Date;
                DateTime requiredAppointmentsEndDate = date.Date.AddDays(1);

                if (requiredAppointmentsEndDate > currentAppointmentStart && requiredAppointmentsStartDate < currentAppointmentEnd)
                {
                    return true;
                }

                return false;
            });
        }

        private void RadCalendar_SelectedValueChanged(object sender, ValueChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
            {
                this.AppointmentsList.ItemsSource = null;
                return;
            }
            DisplayAppointmentsForDate((e.NewValue as DateTime?).Value);
        }
    }
}
