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
using Microsoft.Phone.Scheduler;

namespace PersonaHealth
{
    public partial class DosageReminder : PhoneApplicationPage
    {
        public DosageReminder()
        {
            InitializeComponent();
            this.btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime _Date = dpkDate.Value.Value;
            TimeSpan _Time = tpkTime.Value.Value.TimeOfDay;
            _Date = _Date.Date + _Time;
            String _Content = txtContent.Text;
            if (_Date < DateTime.Now)
                MessageBox.Show("Your time is not match !\nPlease Enter again !");
            else if (String.IsNullOrEmpty(_Content))
                MessageBox.Show("Your task can't be empty !\n Please enter to do task !");
            else
            {
                ScheduledAction _OldReminder = ScheduledActionService.Find("TodoReminder"); if (_OldReminder != null)
                    ScheduledActionService.Remove(_OldReminder.Name);
                Reminder _Reminder = new Reminder("TodoReminder")
                {
                    BeginTime = _Date,
                    Title = "Reminder",
                    Content = _Content,
                };
                ScheduledActionService.Add(_Reminder);
                MessageBox.Show("Set Reminder Completed");
            }
        }

    }
}